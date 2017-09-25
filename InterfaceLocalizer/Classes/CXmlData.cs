using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Web.Helpers;


namespace InterfaceLocalizer.Classes
{
    public class CXmlData : ITranslatable
    {
        private string phrase;
        private string engPhrase;
        private string filename;
        private XmlPath xmlPath;

        public CXmlData(string _phrase, string _eng, string _filename, Stack<string> _tags)
        {
            phrase = _phrase;
            filename = _filename;
            xmlPath = new XmlPath();
            engPhrase = _eng;
        }

        public CXmlData(string _phrase, string _eng, string _filename, XmlPath _path)
        {
            phrase = _phrase;
            filename = _filename;
            xmlPath = new XmlPath(_path);
            engPhrase = _eng;
        }

        public string getRusData()
        {
            return phrase;
        }

        public string getEngData()
        {
            return engPhrase;
        }

        public string getFilename()
        {
            return filename;
        }

        public string getTagsString()
        {
            xmlPath.InvertIt();
            return xmlPath.getPathAsString();
        }

        public void setRusData(string rusData)
        {
            phrase = rusData;
        }

        public void setEngData(string engData)
        {
            engPhrase = engData;
        }

        public Stack<string> getTags()
        {
            //* this function is obsolete and doesn't work
            Stack<string> temp = new Stack<string>();
            temp.Push(xmlPath.Pop().ToString());
            return temp;
        }
                
    }

    class CDataManager : IManager
    {
        private Dictionary<int, ITranslatable> xmlDict = new Dictionary<int, ITranslatable>();
        int id = 0;
        
        public CDataManager()
        {
            id = 0;
        }

        public Dictionary<int, ITranslatable> getFullDictionary()
        {
            return xmlDict;
        }

        public void clearAllData()
        {
            xmlDict.Clear();
            id = 0;
        }

        public void addFileToManager(string filename)
        {
            string ext = Path.GetExtension(filename);
            if (ext == ".xml")
                addXmlToManager(filename);
            else if (ext == ".json")
                addJsonToManager(filename);
        }

        private void addXmlToManager(string filename)
        {
            string rusPath = Properties.Settings.Default.PathToFiles + "\\Russian\\" + filename;
            string engPath = Properties.Settings.Default.PathToFiles + "\\English\\" + filename;
            //XmlTextReader reader = new XmlTextReader(rusPath);
            XmlReader reader = new XmlTextReader(rusPath);
            XDocument engDoc = new XDocument();
            engDoc = XDocument.Load(engPath);
            parseXmlFile(reader, engDoc, filename);
        }

        private void addJsonToManager(string filename)
        {
            string rusPath = Properties.Settings.Default.PathToFiles + "\\Russian\\" + filename;
            string engPath = Properties.Settings.Default.PathToFiles + "\\English\\" + filename;
            System.IO.Stream stream;

            // preparing russian file to xml
            stream = File.Open(rusPath, FileMode.Open);
            var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
            XElement root = XElement.Load(jsonReader);
            XDocument doc = new XDocument();
            doc.Add(root);
            XmlReader reader = doc.CreateReader();
            stream.Close();

            // preparing english file to xml;
            stream = File.Open(engPath, FileMode.Open);
            jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
            root = XElement.Load(jsonReader);
            XDocument engDoc = new XDocument();
            engDoc.Add(root);
            stream.Close();

            parseXmlFile(reader, engDoc, filename);
        }

        private void parseXmlFile(XmlReader reader, XDocument engDoc, string filename)
        {
            string phrase = "";
            string eng = "";
            String attr = "";
            Stack<string> tags = new Stack<string>();
            XmlPath myPath = new XmlPath();
            bool gotten = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        if (reader.HasAttributes)
                            attr = reader.GetAttribute(0);
                        tags.Push(reader.Name);                        
                        myPath.Push(new PathAtom(reader.Name, attr));
                        if (reader.IsEmptyElement)
                        {
                            eng = "";
                            Stack<string> copy = new Stack<string>(tags.ToArray());
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, copy));
                            phrase = "";
                            eng = "";
                            tags.Pop();
                        }
                        break;

                    case XmlNodeType.Text: // Нашли текст в элементе, сохраняем его
                        phrase = reader.Value.Trim();
                        gotten = true;
                        break;

                    case XmlNodeType.EndElement: // Нашли конец элемента, сохраняем данные в словарь
                        if (gotten)
                        {
                            //eng = getValueFromXml(engDoc, tags);
                            //Stack<string> copy = new Stack<string>(tags.ToArray());
                            //xmlDict.Add(id++, new CXmlData(phrase, eng, filename, copy));
                            
                            XmlPath cpy = new XmlPath(myPath);
                            eng = getValueFromXml(engDoc, cpy);
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, myPath));
                            myPath.Pop();
                            gotten = false;
                            phrase = "";
                            eng = "";
                            attr = "";
                        }
                        tags.Pop();
                        break;
                }
            }        
        
        }

        private string getValueFromXml(XDocument doc, XmlPath path)
        {
            string result = "";

            try
            {
                XName temp = path.Pop().getAtom().Name;
                XElement try1 = doc.Element(temp);

                XAttribute temp2 = path.Pop().getAtom().Attribute("name");
                XElement try2 = try1.Descendants().Where( x => (string)x.Attribute("name") == temp2.Value.ToString()).Single();
                result = try2.Value.ToString();
                //if (step1.HasAttributes)
                 //   step2 = step1.Descendants().Where(x => (string)x.Attribute("name") == step1.Attribute("name")).FirstOrDefault();

                //XElement step3 = step1.Element(
                /*if (ntags.Count == 1)
                    result = doc.Element(ntags.Pop()).Value.ToString();
                else if (ntags.Count == 2)
                    result = doc.Element(ntags.Pop()).Element(ntags.Pop()).Value.ToString();
                else if (ntags.Count == 3)
                    result = doc.Element(ntags.Pop()).Element(ntags.Pop()).Element(ntags.Pop()).Value.ToString();*/
            }
            catch
            {
                result = "<NO DATA>";
            }
            result = result.Trim();
            return result;
        }

        public void updateDataFromGridView(RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string tags = gridView.Rows[row].Cells["columnTags"].Value.ToString();
                string rus = gridView.Rows[row].Cells["columnRussianPhrase"].Value.ToString();
                string eng = gridView.Rows[row].Cells["columnEnglishPhrase"].Value.ToString();

                if (!xmlDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                if (xmlDict[id].getFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                xmlDict[id].setRusData(rus);
                xmlDict[id].setEngData(eng);
            }            
        }

        public void saveDataToFile(bool english)
        {
            string path = Properties.Settings.Default.PathToFiles;
            path += (english) ? ("\\English\\") : ("\\Russian\\");
            bool json = false;
            foreach (string file in CFileList.checkedFiles)
            {
                XDocument doc = new XDocument();
                if (Path.GetExtension(file) == ".json")
                {
                    json = true;
                    XElement el = new XElement("root");
                    doc.Add(el);
                }
                else 
                    json = false;

                if (!json)
                {
                    doc = XDocument.Load(path + file);
                    IEnumerable<XElement> del = doc.Root.Descendants().ToList();
                    del.Remove();
                    doc.Save(path + file);
                }

                foreach (CXmlData text in xmlDict.Values)
                {
                    if (text.getFilename() != file)
                        continue;

                    Stack<string> copy = new Stack<string>(text.getTags());
                    copy = GenericTest<string>.invertStack(copy);
                    string value = (english) ? (text.getEngData()) : (text.getRusData());
                    
                    if (copy.Count == 3)
                    {
                        string root = copy.Pop();
                        string chapter = copy.Pop();
                        string item = copy.Pop();

                        if (doc.Root.Descendants().Any(tag1 => tag1.Name == chapter && tag1.Descendants().Any()))
                            doc.Root.Element(chapter).Add(getXElement(item, value));
                        else
                            doc.Root.Add(new XElement(chapter, getXElement(item, value)));
                    }
                    else if (copy.Count == 2)
                    {
                        string root = copy.Pop();
                        string item = copy.Pop();
                        doc.Root.Add( getXElement(item,value) );
                    }
                }

                if (json)
                {
                    saveDataToJsonFile(english, file, doc);
                    continue;
                }
                else
                {
                    System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                    settings.Encoding = new UTF8Encoding(false);
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;
                    settings.NewLineOnAttributes = true;
                    using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(path + file, settings))
                    {
                        doc.Save(w);
                    }
                }
                //doc.Save(path + file);
            }
        }

        private void saveDataToJsonFile(bool english, string filename, XDocument doc)
        {
            string path = Properties.Settings.Default.PathToFiles;
            path += (english) ? ("\\English\\") : ("\\Russian\\");

            System.IO.Stream stream;
            stream = File.Open(path + filename, FileMode.Create);
            var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true);
            jsonWriter.WriteStartDocument();
            jsonWriter.WriteStartElement("root");
            jsonWriter.WriteAttributeString("type", "object");

            IEnumerable<XElement> elements = doc.Root.Elements().ToList();
            foreach (XElement chapter in elements)
            {
                jsonWriter.WriteStartElement(chapter.Name.ToString());
                jsonWriter.WriteAttributeString("type", "object");
                foreach (XElement element in elements.Descendants())
                {
                    jsonWriter.WriteElementString(element.Name.ToString(), element.GetDefaultNamespace().ToString(), element.Value);
                }
            }
            jsonWriter.WriteEndDocument();
            jsonWriter.Flush();
            stream.Close();
        }

        private XElement getXElement(string item, string value)
        {
            XElement el;
            if (value != "")
                el = new XElement(item, value);
            else 
                el = new XElement(item);
            return el;
        }

    }
}
