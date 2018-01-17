using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    class KeyValueForGroups : CKeyValue
    {
        public KeyValueForGroups (string _key, string _language, string _text, string _filename) 
            : base(_key, _language, _text, _filename)
        {
        }

        public override bool Troublesome(out TroubleType trouble)
        {
            trouble = TroubleType.difference;
            string group0 = CFileList.GroupedData.Keys.ElementAt(0);
            foreach (string language in CFileList.GroupedData[group0].Keys)
            {
                string key1 = group0 + ":" + language;
                string text = GetTranslation(key1);
                foreach (string group in CFileList.GroupedData.Keys)
                {
                    string key2 = group + ":" + language;
                    if (GetTranslation(key2) != text)
                        return true;
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
            values[2] = GetOriginalText();

            for (i = 0; i < 4; i++ )
            {
                string key = CFileList.FileToGroupAndLanguage.Values.ElementAt(i);
                values[i + 3] = GetTranslation(key);
            }

            TroubleType trouble;
            Troublesome(out trouble);
            values[i+3] = Troubles.GetText(trouble);

            return values;
        }

        public override bool Add(ITranslatable addendum)
        {
            for (int i = 0; i < CFileList.GetNumberOfFiles(); i++)
            {
                string lang = CFileList.FileToGroupAndLanguage.Values.ElementAt(i);
                string text = addendum.GetTranslation(lang);
                if (text != Const.NO_DATA)
                    this.SetTranslation(lang, text);
            }
            return true;
        }
    }


    class KeyValueManagerForGroups : CKeyValueManager
    {
        public KeyValueManagerForGroups()
            : base()
        { 
        }

        public override void AddFileToManager(string filename)
        {
            string groupAndLang = CFileList.FileToGroupAndLanguage[filename];
            readKeyValueFile(groupAndLang, filename);
        }

        protected override void readKeyValueFile(string language, string filename)
        {
            StreamReader reader = new StreamReader(filename);
            bool withQuotes = Extension.Get(filename) == Extensions.strings;
            while (!reader.EndOfStream)
            {
                string rawline = reader.ReadLine();
                if (String.IsNullOrEmpty(rawline))      // skip empty lines
                    continue;
                rawline = concatenateFurtherStrings(reader, rawline);
                rawline = convertCodepointsToChars(rawline);
                int indexOfEquality = rawline.IndexOf("=");
                if (indexOfEquality == -1)              // skip lines without '=' sign 
                    continue;
                int length = rawline.Length;
                string key = rawline.Substring(0, indexOfEquality).Trim();
                string value = rawline.Substring(indexOfEquality + 1, length - indexOfEquality - 1).Trim();
                if (withQuotes)
                {
                    key = removeQuotes(key);
                    value = removeQuotes(value);
                }
                if (!dict.ContainsKey(key))
                    dict.Add(key, new KeyValueForGroups(key, language, value, filename));
                else
                    dict[key].SetTranslation(language, value);
            }
        }

        public override void UpdateDataFromGridView(Telerik.WinControls.UI.RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                string id = gridView.Rows[row].Cells["columnID"].Value.ToString();
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string tags = gridView.Rows[row].Cells["columnTags"].Value.ToString();

                if (!dict.ContainsKey(id))
                    dict.Add(id, new CKeyValue(id, "", "", filename));

                for (int i = 0; i < CFileList.GetNumberOfFiles(); i++)
                {
                    string columnName = "columnTranslation" + i.ToString();
                    string language = CFileList.LanguageToFile.Keys.ElementAt(i);
                    string translation = gridView.Rows[row].Cells[columnName].Value.ToString();
                    dict[id].SetTranslation(language, translation);
                }
            }
        }

        public override void SaveDataToFile(bool original)
        {
            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                string filename = CFileList.LanguageToFile[language];
                Extensions ext = Extension.Get(filename);
                if (ext != Extensions.strings && ext != Extensions.properties)
                    continue;
                StreamWriter writer = new StreamWriter(filename);
                string EqualsSign = (ext == Extensions.properties) ? ("=") : (" = ");
                foreach (CKeyValue stuff in dict.Values)
                {
                    string newKey = stuff.GetOriginalText();
                    string newValue = stuff.GetTranslation(language);
                    if (ext == Extensions.strings)
                    {
                        newKey = addQuotes(newKey, false);
                        newValue = addQuotes(newValue, true);
                    }
                    string line = newKey + EqualsSign + newValue;
                    writer.WriteLine(line);
                }
                writer.Close();
            }
        }
    }
}
