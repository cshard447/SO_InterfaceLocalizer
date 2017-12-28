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
        public KeyValueForGroups (string _key, string _language, string _text, string _filename) : base(_key, _language, _text, _filename)
        {
        }

        public override bool Troublesome(out TroubleType trouble)
        {
            // think about new way of detecting troubles
            trouble = TroubleType.duplicate;
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
            string language = CFileList.LanguageToFile.Where(u => u.Value == filename).First().Key;
            readKeyValueFile(language, filename);
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
