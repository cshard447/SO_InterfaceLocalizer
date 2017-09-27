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

        public CXmlData(string _phrase, string _eng, string _filename, XmlPath _path)
        {
            phrase = _phrase;
            filename = _filename;
            xmlPath = new XmlPath(_path);
            engPhrase = _eng;
        }

        public string GetRusData()
        {
            return phrase;
        }

        public string GetEngData()
        {
            return engPhrase;
        }

        public string GetFilename()
        {
            return filename;
        }

        public string GetPathString()
        {
            xmlPath.InvertIt();
            return xmlPath.GetPathAsString();
        }

        public void SetRusData(string rusData)
        {
            phrase = rusData;
        }

        public void SetEngData(string engData)
        {
            engPhrase = engData;
        }

        public XElement GetPath()
        {
            return xmlPath.GetPathAsElement();
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

        public Dictionary<int, ITranslatable> GetFullDictionary()
        {
            return xmlDict;
        }

        public void ClearAllData()
        {
            xmlDict.Clear();
            id = 0;
        }

        public void AddFileToManager(string filename)
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
            XmlPath myPath = new XmlPath();
            bool gotten = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        String tempAttr = (reader.HasAttributes) ? (reader.GetAttribute(0)) : ("");
                        myPath.Push(new PathAtom(reader.Name, tempAttr));
                        if (reader.IsEmptyElement)
                        {
                            eng = "";
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, myPath));
                            phrase = "";
                            eng = "";
                            myPath.Pop();
                        }
                        break;

                    case XmlNodeType.Text: // Нашли текст в элементе, сохраняем его
                        phrase = reader.Value.Trim();
                        gotten = true;
                        break;

                    case XmlNodeType.EndElement: // Нашли конец элемента, сохраняем данные в словарь
                        if (gotten)
                        {
                            XmlPath cpy = new XmlPath(myPath);
                            eng = getValueFromXml(engDoc, cpy);
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, myPath));
                            gotten = false;
                            phrase = "";
                            eng = "";
                        }
                        myPath.Pop();
                        break;
                }
            }        
        
        }

        private string getValueFromXml(XDocument doc, XmlPath path)
        {
            string result = "";
            try
            {
                XElement step1 = path.Pop().GetAtom(); ;
                IEnumerable<XElement> try1 = doc.Elements(step1.Name);

                while (path.Count() > 0)
                {
                    step1 = path.Pop().GetAtom();
                    try1 = try1.Elements(step1.Name);
                    if (step1.HasAttributes)
                        try1 = try1.Where(x => (string)x.Attribute("name") == step1.Attribute("name").Value.ToString()).ToArray();
                    else
                        try1 = try1.Where(x => x.HasAttributes == false).ToArray();
                        //try1 = try1.Where(x => x.Attributes().Count() == 0).ToArray();                        
                }

                result = try1.First().Value.ToString();
            }
            catch
            {
                result = "<NO DATA>";
            }
            result = result.Trim();
            return result;
        }

        public void UpdateDataFromGridView(RadGridView gridView)
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

                if (xmlDict[id].GetFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                xmlDict[id].SetRusData(rus);
                xmlDict[id].SetEngData(eng);
            }            
        }

        public void SaveDataToFile(bool english)
        {
            string path = Properties.Settings.Default.PathToFiles;
            path += (english) ? ("\\English\\") : ("\\Russian\\");
            bool json = false;
            foreach (string file in CFileList.CheckedFiles)
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
                    if (text.GetFilename() != file)
                        continue;
                    
                    XElement localPath = text.GetPath();
                    XElement noRoot = localPath.Descendants().First();
                    string value = (english) ? (text.GetEngData()) : (text.GetRusData());

                    XElement child = noRoot;
                    while (child.HasElements)
                    {
                        XName name = child.Descendants().First().Name;
                        child = child.Element(name);
                    }
                    
                    child.SetValue(value);
                    doc.Root.Add(noRoot);
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
                    settings.NewLineOnAttributes = false;
                    using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(path + file, settings))
                    {
                        doc.Save(w);
                    }
                }
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

        /*private XElement getXElement(string item, string value)
        {
            XElement el;
            if (value != "")
                el = new XElement(item, value);
            else 
                el = new XElement(item);
            return el;
        }*/

    }
}
