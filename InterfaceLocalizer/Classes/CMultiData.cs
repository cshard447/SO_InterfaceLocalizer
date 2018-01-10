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
    class CMultiData : ITranslatable
    {
        private string key;
        private Dictionary<string, string> translation;
        private string filename;
        private XmlPath xmlPath;

        public CMultiData(string _key, string language, string text, string _filename, XmlPath _path)
        {
            key = _key;
            filename = _filename;
            xmlPath = new XmlPath(_path);
            translation = new Dictionary<string, string>();
            if (language != "")
                translation[language] = text;
        }

        public string GetOriginalText()
        {
            return key;
        }

        public string GetTranslation(String key)
        {
            if (translation.ContainsKey(key))
                return translation[key];
            else
                return Const.NO_DATA;
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
            throw new NotImplementedException();
        }

        public void SetTranslation(String language, string translatedText)
        {
            translation[language] = translatedText;
        }

        public virtual bool Troublesome(out TroubleType trouble)
        {
            trouble = TroubleType.none;
            if (translation.Count < CFileList.GetNumberOfFiles())
            {
                trouble = TroubleType.absence;
                return true;
            }

            var duplicateValues = translation.GroupBy(x => x.Value).Where(x => x.Count() > 1);
            if (duplicateValues.Count() > 0)
            {
                trouble = TroubleType.duplicate;
                return true;
            }

            return false;
        }

        public XElement GetPath()
        {
            return xmlPath.GetPathAsElement();
        }

        public virtual object[] GetAsRow()
        {
            object[] values = new object[7];
            values[0] = key;
            values[1] = Path.GetFileName(GetFilename());
            values[2] = GetPathString();
            for (int i = 0; i < CFileList.GetNumberOfFiles(); i++)
                values[i + 3] = GetTranslation(CFileList.LanguageToFile.Keys.ElementAt(i));
            return values;
        }

        public virtual bool Add(ITranslatable addendum)
        {
            for (int i = 0; i < CFileList.GetNumberOfFiles(); i++)
            {
                string lang = CFileList.LanguageToFile.Keys.ElementAt(i);
                string text = addendum.GetTranslation(lang);
                if (text != Const.NO_DATA)
                    this.SetTranslation(lang, text);
            }
            return true;
        }
    }

    //***************************************************************************************************

    class CMultiManager : IManager
    {
        protected Dictionary<object, ITranslatable> xmlDict;

        public CMultiManager()
        {
            xmlDict = new Dictionary<object, ITranslatable>();
        }

        public Dictionary<object, ITranslatable> GetFullDictionary()
        {
            return xmlDict;
        }

        public void ClearAllData()
        {
            xmlDict.Clear();
        }

        public virtual void AddFileToManager(string filename)
        {
            string language = CFileList.LanguageToFile.Where(u => u.Value == filename).First().Key;
            parseXmlFile(language, filename);
            //string ext = Path.GetExtension(translationPath);
            //else if (ext == ".json")
            //    addJsonToManager(translationPath);
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

        protected void parseXmlFile(string language, string filename)
        {
            XmlPath myPath = new XmlPath();
            string key = "";
            bool gotten = false;
            string text = "";
            XmlReader reader = new XmlTextReader(filename);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        String tempAttr = (reader.HasAttributes) ? (reader.GetAttribute(0)) : ("");
                        key = tempAttr;
                        myPath.Push(new PathAtom(reader.Name, tempAttr));
                        if (reader.IsEmptyElement)
                        {
                            AddOrUpdate(key, language, text, filename, myPath);
                            text = "";
                            myPath.Pop();
                        }
                        break;

                    case XmlNodeType.Text: // Нашли текст в элементе, сохраняем его
                        text = reader.Value.Trim();
                        gotten = true;
                        break;

                    case XmlNodeType.EndElement: // Нашли конец элемента, сохраняем данные в словарь
                        if (gotten)
                        {
                            AddOrUpdate(key, language, text, filename, myPath);
                            gotten = false;
                            text = "";
                            key = "";
                        }
                        myPath.Pop();
                        break;
                }
            }
        }

        protected virtual void AddOrUpdate(string key, string language, string text, string filename, XmlPath xmlPath)
        {
            if (String.IsNullOrEmpty(key))
                key = xmlPath.GetPathAsString();

            if (xmlDict.ContainsKey(key))
                xmlDict[key].SetTranslation(language, text);
            else
                xmlDict.Add(key, new CMultiData(key, language, text, filename, xmlPath));
        }

        public virtual void UpdateDataFromGridView(RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                string id = gridView.Rows[row].Cells["columnID"].Value.ToString();
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string tags = gridView.Rows[row].Cells["columnTags"].Value.ToString();

                if (!xmlDict.ContainsKey(id))
                {
                    XmlPath tempPath = new XmlPath();
                    tempPath.Push(new PathAtom("string", id));
                    tempPath.Push(new PathAtom("resources", ""));
                    xmlDict.Add(id, new CMultiData(id, "", "", filename, tempPath));
                }

                for (int i = 0; i < CFileList.GetNumberOfFiles(); i++)
                {
                    string columnName = "columnTranslation" + i.ToString();
                    string language = CFileList.LanguageToFile.Keys.ElementAt(i);
                    string translation = gridView.Rows[row].Cells[columnName].Value.ToString();
                    xmlDict[id].SetTranslation(language, translation);
                }
            }
        }

        public virtual void SaveDataToFile(bool original)
        {
            bool json = false;
            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                string path = CFileList.LanguageToFile[language];
                if (Extension.Get(path) != Extensions.xml)
                    continue;
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
                    string value = text.GetTranslation(language);
                    XElement localPath = text.GetPath();
                    XElement noRoot = localPath.Descendants().First();
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

        public void AddData(ITranslatable addendum)
        {
            xmlDict[addendum.GetOriginalText()].Add(addendum);
        }
    }

}
