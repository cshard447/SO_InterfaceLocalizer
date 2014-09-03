using System;
using System.IO;
using System.Linq;
using System.Text;
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

        public string getRusData()
        {
            return rusText;
        }

        public string getEngData()
        {
            return engText;
        }

        public string getFilename()
        {
            return filename;
        }

        public string getTagsString()
        {
            return "";
        }

        public void setRusData(string rusData)
        {
            rusText = rusData;
        }

        public void setEngData(string engData)
        {
            engText = engData;
        }
        public Stack<string> getTags()
        {
            return new Stack<string>();
        }
    }

    class CTextManager
    {
        private Dictionary<int, CTextData> textDict = new Dictionary<int, CTextData>();
        int id = 0;

        public CTextManager()
        {
            id = 0;
        }

        public Dictionary<int, CTextData> getTextDict()
        {
            return textDict;
        }
        public void clearAllData()
        {
            textDict.Clear();
            id = 0;
        }

        public void addFileToManager(string filename)
        {
            string rusPath = Properties.Settings.Default.PathToGossip + filename;
            string engPath = Properties.Settings.Default.PathToGossip + @"\English\" + filename;

            string rus = File.ReadAllText(rusPath);
            string eng = File.ReadAllText(engPath);
            textDict.Add(id, new CTextData(filename, rus, eng));
            id++;
        }

        public void updateTextsFromGridView(RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string rus = gridView.Rows[row].Cells["columnRussianPhrase"].Value.ToString();
                string eng = gridView.Rows[row].Cells["columnEnglishPhrase"].Value.ToString();

                if (!textDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                if (textDict[id].getFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                textDict[id].setRusData(rus);
                textDict[id].setEngData(eng);
            }
        }

        public void saveDataToFile(bool english)
        {
            string path = Properties.Settings.Default.PathToGossip;
            path += (english) ? (@"\English\") : ("");
        }
    
    }
}
