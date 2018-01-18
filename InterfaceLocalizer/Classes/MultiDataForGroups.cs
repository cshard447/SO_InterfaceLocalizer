﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace InterfaceLocalizer.Classes
{
    class MultiDataForGroups : CMultiData
    {
        public MultiDataForGroups(string _key, string language, string text, string _filename, XmlPath _path) 
            : base(_key, language, text, _filename, _path)
        {
        }

        public override bool Troublesome(out TroubleType trouble)
        {
            string group0 = CFileList.GroupedData.Keys.ElementAt(0);
            foreach (string language in CFileList.GroupedData[group0].Keys)
            {
                string key1 = group0 + ":" + language;
                string text = GetTranslation(key1);
                foreach (string group in CFileList.GroupedData.Keys)
                {
                    string key2 = group + ":" + language;
                    if (GetTranslation(key2) == Const.NO_DATA)
                    {
                        trouble = TroubleType.absence;
                        return true;
                    }
                    if (GetTranslation(key2) != text)
                    {
                        trouble = TroubleType.difference;
                        return true;
                    }
                }
            }
            trouble = TroubleType.none;
            return false;
        }

        public override object[] GetAsRow()
        {
            int i;
            object[] values = new object[8];
            values[0] = GetOriginalText();
            values[1] = Path.GetFileName(GetFilename());
            values[2] = GetPathString();

            for (i = 0; i < 4; i++)
            {
                string key = CFileList.FileToGroupAndLanguage.Values.ElementAt(i);
                values[i + 3] = GetTranslation(key);
            }
            TroubleType trouble;
            Troublesome(out trouble);
            values[i + 3] = Troubles.GetText(trouble);

            return values;
        }

        public override bool Add(ITranslatable addendum)
        {
            for (int i = 0; i < CFileList.FileToGroupAndLanguage.Count; i++)
            {
                string lang = CFileList.FileToGroupAndLanguage.Values.ElementAt(i);
                string text = addendum.GetTranslation(lang);
                if (text != Const.NO_DATA)
                    this.SetTranslation(lang, text);
            }
            return true;
        }
    }


    class MultiDataManagerForGroups : CMultiManager
    {
        public MultiDataManagerForGroups()
        { 
        }

        public override void AddFileToManager(string filename)
        {
            string groupAndLang = CFileList.FileToGroupAndLanguage[filename];
            parseXmlFile(groupAndLang, filename);
        }

        protected override void AddOrUpdate(string key, string language, string text, string filename, XmlPath xmlPath)
        {
            if (String.IsNullOrEmpty(key))
                key = xmlPath.GetPathAsString();

            if (xmlDict.ContainsKey(key))
                xmlDict[key].SetTranslation(language, text);
            else
                xmlDict.Add(key, new MultiDataForGroups(key, language, text, filename, xmlPath));
        }

        public override void UpdateDataFromGridView(RadGridView gridView)
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


        public override void SaveDataToFile(bool original)
        {
            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                string path = CFileList.LanguageToFile[language];
                if (Extension.Get(path) != Extensions.xml)
                    continue;
                XDocument doc = new XDocument();

                doc = XDocument.Load(path);
                IEnumerable<XElement> del = doc.Root.Descendants().ToList();
                del.Remove();
                doc.Save(path);

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
}