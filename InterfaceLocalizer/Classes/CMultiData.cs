using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

using Telerik.WinControls.UI;
using System.Runtime.Serialization.Json;
using System.Web.Helpers;

namespace InterfaceLocalizer.Classes
{
    public class CMultiData : ITranslatable
    {
        private string phrase;
        private Dictionary<string, string> translation;
        private string filename;
        private XmlPath xmlPath;

        public CMultiData(string _phrase, Dictionary<string, string> data, string _filename, XmlPath _path)
        {
            translation = new Dictionary<string, string>(data);
            //translation = data;
            phrase = _phrase;
            filename = _filename;
            xmlPath = new XmlPath(_path);
        }

        public string GetOriginalText()
        {
            return phrase;
        }

        public string GetTranslation(String key)
        {
            if (translation.ContainsKey(key))
                return translation[key];
            else
                return "<NO DATA!>";
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

        public XElement GetPath()
        {
            return xmlPath.GetPathAsElement();
        }

    }

    //***************************************************************************************************

    class CMultiManager : IManager
    {
        private Dictionary<int, ITranslatable> xmlDict = new Dictionary<int, ITranslatable>();
        int id = 0;

        public CMultiManager()
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
            //else if (ext == ".json")
            //    addJsonToManager(filename);
        }

        private void addXmlToManager(string filename)
        {
            string originalPath = filename; // FolderDispatcher.OriginalPath() +
            XmlReader reader = new XmlTextReader(originalPath);

            Dictionary<string, XDocument> langsAndDocs = new Dictionary<string, XDocument>();

            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                string translationPath = CFileList.LanguageToFile[language];
                XDocument doc = new XDocument();
                doc = XDocument.Load(translationPath);
                langsAndDocs.Add(language, doc);
            }

            parseXmlFile(reader, langsAndDocs, filename);
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

            // convert
            //parseXmlFile(reader, engDoc, filename);
        }

        private void parseXmlFile(XmlReader reader, Dictionary<string, XDocument> translatedDocs, string filename)
        {
            string original = "";            
            XmlPath myPath = new XmlPath();
            bool gotten = false;
            Dictionary<string, string> translation = new Dictionary<string, string>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        String tempAttr = (reader.HasAttributes) ? (reader.GetAttribute(0)) : ("");
                        myPath.Push(new PathAtom(reader.Name, tempAttr));
                        if (reader.IsEmptyElement)
                        {
                            translation.Clear();
                            xmlDict.Add(id++, new CMultiData(original, translation, filename, myPath));
                            original = "";
                            translation.Clear();
                            myPath.Pop();
                        }
                        break;

                    case XmlNodeType.Text: // Нашли текст в элементе, сохраняем его
                        original = reader.Value.Trim();
                        gotten = true;
                        break;

                    case XmlNodeType.EndElement: // Нашли конец элемента, сохраняем данные в словарь
                        if (gotten)
                        {                            
                            foreach (string language in CFileList.LanguageToFile.Keys)
                            {
                                XmlPath cpy = new XmlPath(myPath);
                                string translatedText = getValueFromXml(translatedDocs[language], cpy);
                                translation.Add(language, translatedText);
                            }
                            xmlDict.Add(id++, new CMultiData(original, translation, filename, myPath));
                            gotten = false;
                            original = "";
                            translation.Clear();
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
                string originalText = gridView.Rows[row].Cells["columnOriginalPhrase"].Value.ToString();

                if (!xmlDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                //if (xmlDict[id].GetFilename() != filename)
                //    throw new System.ArgumentException("Имена файлов не совпадают!");

                xmlDict[id].SetOriginalText(originalText);

                for (int i = 1; i <= CFileList.LanguageToFile.Count(); i++)
                {
                    string columnName = "columnTranslation" + i.ToString();
                    string language = CFileList.LanguageToFile.Keys.ElementAt(i - 1);
                    string translation = gridView.Rows[row].Cells[columnName].Value.ToString();
                    xmlDict[id].SetTranslation(language, translation);
                }
            }
        }

        [System.Obsolete("Rewrite from XmlData to MultiData")]
        public void SaveDataToFile(bool original)
        {
            string path;// = (original) ? (FolderDispatcher.OriginalPath()) : (FolderDispatcher.TranslationPath());
            bool json = false;
            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                path = CFileList.LanguageToFile[language];
                XDocument doc = new XDocument();
                /*if (Path.GetExtension(file) == ".json")
                {
                    json = true;
                    XElement el = new XElement("root");
                    doc.Add(el);
                }
                else*/
                    json = false;

                if (!json)
                {
                    doc = XDocument.Load(path);
                    IEnumerable<XElement> del = doc.Root.Descendants().ToList();
                    del.Remove();
                    doc.Save(path);
                }

                foreach (CMultiData text in xmlDict.Values)
                {
                    //if (text.GetFilename() != file)
                        //continue;

                    XElement localPath = text.GetPath();
                    XElement noRoot = localPath.Descendants().First();
                    string value = (original) ? (text.GetOriginalText()) : (text.GetTranslation(language));

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
                    saveDataToJsonFile(original, path, doc);
                    continue;
                }
                else
                {
                    System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                    settings.Encoding = new UTF8Encoding(false);
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;
                    settings.NewLineOnAttributes = false;
                    using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(path, settings))
                    {
                        doc.Save(w);
                    }
                }
            }
        }

        [System.Obsolete("Rewrite from XmlData to MultiData")]
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
