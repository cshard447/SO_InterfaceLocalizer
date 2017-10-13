using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InterfaceLocalizer.Classes
{
    class CTextData : ITranslatable
    {
        private string filename;
        private string rusText;
        private string engText;

        public CTextData(string _filename, string _rusText, string _engText)
        {
            filename = _filename;
            rusText = _rusText;
            engText = _engText;
        }

        public string GetOriginalText()
        {
            return rusText;
        }

        public string GetTranslation(String key)
        {
            return engText;
        }

        public string GetFilename()
        {
            return filename;
        }

        public string GetPathString()
        {
            return "";
        }

        public void SetOriginalText(string originalText)
        {
            rusText = originalText;
        }

        public void SetTranslation(String key, string translatedText)
        {
            engText = translatedText;
        }
        public bool Troublesome(out TroubleType trouble)
        {
            trouble = TroubleType.absence;
            return true;
        }

        public XElement GetPath()
        {
            return new XElement("test");
        }

        public object[] GetAsRow()
        {
            object[] values = new object[5];
            values[0] = 2;
            values[1] = Path.GetFileName(GetFilename());
            values[2] = GetPathString();
            values[3] = GetOriginalText();
            values[4] = GetTranslation("eng");
            return values;
        }
    }

    //***************************************************************************************************

    class CTextManager : IManager
    {
        private Dictionary<object, ITranslatable> textDict = new Dictionary<object, ITranslatable>();
        int id = 0;

        public CTextManager()
        {
            id = 0;
        }

        public Dictionary<object, ITranslatable> GetFullDictionary()
        {
            return textDict;
        }

        public void ClearAllData()
        {
            textDict.Clear();
            id = 0;
        }

        public void AddFileToManager(string filename)
        {
            string rusPath = FolderDispatcher.OriginalPath() + filename;
            string engPath = FolderDispatcher.TranslationPath() + filename;

            string rus = File.ReadAllText(rusPath);
            string eng = File.ReadAllText(engPath);
            textDict.Add(id, new CTextData(filename, rus, eng));
            id++;
        }

        public void UpdateDataFromGridView(RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string originalText = gridView.Rows[row].Cells["columnTranslation0"].Value.ToString();
                string translation = gridView.Rows[row].Cells["columnTranslation1"].Value.ToString();

                if (!textDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                if (textDict[id].GetFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                textDict[id].SetOriginalText(originalText);
                textDict[id].SetTranslation("default", translation);
            }
        }

        public void SaveDataToFile(bool original)
        {
            string path = (original) ? (FolderDispatcher.OriginalPath()) : (FolderDispatcher.TranslationPath());
            
            foreach (CTextData text in textDict.Values)
            {
                string value = (original) ? (text.GetOriginalText()) : (text.GetTranslation(""));
                string file = path + text.GetFilename();
                File.WriteAllText(file, value, Encoding.UTF8);
            }
        }

    }
}
