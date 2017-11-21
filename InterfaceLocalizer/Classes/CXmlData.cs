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
    class CXmlData : ITranslatable
    {
        private string phrase;
        private Dictionary<string, string> translation;
        private string filename;
        private XmlPath xmlPath;

        public CXmlData(string _phrase, string _eng, string _filename, XmlPath _path)
        {
            translation = new Dictionary<string, string>();
            phrase = _phrase;
            translation["eng"] = _eng;
            filename = _filename;
            xmlPath = new XmlPath(_path);
        }

        public string GetOriginalText()
        {
            return phrase;
        }

        public string GetTranslation(String key)
        {
            return translation[key];
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

        public void SetOriginalText(string originalText)
        {
            phrase = originalText;
        }

        public void SetTranslation(String key, string translatedText)
        {
            translation[key] = translatedText;
        }

        public bool Troublesome(out TroubleType trouble)
        {
            trouble = TroubleType.none;
            if (GetTranslation("eng") == Const.NO_DATA || GetTranslation("eng") == "")
                trouble = TroubleType.absence;
            return (trouble != TroubleType.none);
        }

        public XElement GetPath()
        {
            return xmlPath.GetPathAsElement();
        }

        public object[] GetAsRow()
        {
            object[] values = new object[5];
            values[0] = 0;
            values[1] = Path.GetFileName(GetFilename());
            values[2] = GetPathString();
            values[3] = GetOriginalText();
            values[4] = GetTranslation("eng");
            return values;
        }

        public bool Add(ITranslatable addendum)
        {
            throw new NotImplementedException();
        }
    }

    //***************************************************************************************************

    class CDataManager : IManager
    {
        private Dictionary<object, ITranslatable> xmlDict = new Dictionary<object, ITranslatable>();
        int id = 0;
        
        public CDataManager()
        {
            id = 0;
        }

        public Dictionary<object, ITranslatable> GetFullDictionary()
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
            if (Extension.Get(filename) == Extensions.xml)
                addXmlToManager(filename);
            else if (Extension.Get(filename) == Extensions.json)
                addJsonToManager(filename);
        }

        private void addXmlToManager(string filename)
        {
            string rusPath = FolderDispatcher.OriginalPath() + filename;
            string engPath = FolderDispatcher.TranslationPath() + filename;
            XmlReader reader = new XmlTextReader(rusPath);
            XDocument engDoc = new XDocument();
            engDoc = XDocument.Load(engPath);
            parseXmlFile(reader, engDoc, filename);
        }

        private void addJsonToManager(string filename)
        {
            string rusPath = FolderDispatcher.OriginalPath() + filename;
            string engPath = FolderDispatcher.TranslationPath() + filename;
            System.IO.Stream stream;

            // preparing original file to xml
            stream = File.Open(rusPath, FileMode.Open);
            var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
            XElement root = XElement.Load(jsonReader);
            XDocument doc = new XDocument();
            doc.Add(root);
            XmlReader reader = doc.CreateReader();
            stream.Close();

            // preparing translated file to xml
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
                result = Const.NO_DATA;
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
                string originalText = gridView.Rows[row].Cells["columnTranslation0"].Value.ToString();
                string translation = gridView.Rows[row].Cells["columnTranslation1"].Value.ToString();

                if (!xmlDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                if (xmlDict[id].GetFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                xmlDict[id].SetOriginalText(originalText);
                xmlDict[id].SetTranslation("eng", translation);
            }            
        }

        public void SaveDataToFile(bool original)
        {
            string path = (original) ? (FolderDispatcher.OriginalPath()) : (FolderDispatcher.TranslationPath()); 
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
                    string value = (original) ? (text.GetOriginalText()) : (text.GetTranslation("eng"));

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
                    saveDataToJsonFile(original, file, doc);
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

        private void saveDataToJsonFile(bool original, string filename, XDocument doc)
        {
            string path = (original) ? (FolderDispatcher.OriginalPath()) : (FolderDispatcher.TranslationPath()); 

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

    }
}
