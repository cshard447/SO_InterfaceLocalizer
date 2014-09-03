using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    class CTextData
    {
        public string filename;
        public string rusText;
        public string engText;
        public CTextData()
        {         
        }

        public CTextData(string _filename, string _rusText, string _engText)
        {
            filename = _filename;
            rusText = _rusText;
            engText = _engText;
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

            //FileStream rusFile = File.Open(rusPath, FileMode.Open);
            string test = File.ReadAllText(rusPath);

            textDict.Add(id, new CTextData(filename, test, "test"));
            id++;
            //rusFile.Close();
        }
    
    }
}
