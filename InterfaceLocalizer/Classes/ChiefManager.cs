using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    class ChiefManager : IManager
    {
        private Dictionary<object, IManager> managerDict;
        private Dictionary<Extensions, string> FilenameToManagerName;

        public ChiefManager()
        {
            managerDict = new Dictionary<object, IManager>();
            IManager manager1 = new MultiDataManagerForGroups();
            IManager manager2 = new KeyValueManagerForGroups();
            managerDict.Add(manager1.ToString(), manager1);
            managerDict.Add(manager2.ToString(), manager2);

            FilenameToManagerName = new Dictionary<Extensions, string>();
            FilenameToManagerName.Add(Extensions.xml, manager1.ToString());
            FilenameToManagerName.Add(Extensions.strings, manager2.ToString());
            FilenameToManagerName.Add(Extensions.properties, manager2.ToString());
        }

        public Dictionary<object, ITranslatable> GetFullDictionary()
        {
            Dictionary<object, ITranslatable> textDict = new Dictionary<object, ITranslatable>();

            foreach (IManager manager in managerDict.Values)
            {
                var tempD = manager.GetFullDictionary();
                foreach (ITranslatable text in tempD.Values)
                { 
                    if (textDict.ContainsKey(text.GetOriginalText()))
                        textDict[text.GetOriginalText()].Add(text);
                    else
                        textDict.Add(text.GetOriginalText(), text);
                }
            }

            return textDict;
        }

        public void ClearAllData()
        {
            foreach (IManager manager in managerDict.Values)
                manager.ClearAllData();
        }

        public void AddFileToManager(string filename)
        {
            Extensions ext = Extension.Get(filename);
            string name = FilenameToManagerName[ext];
            managerDict[name].AddFileToManager(filename);
        }

        public void UpdateDataFromGridView(Telerik.WinControls.UI.RadGridView gridView)
        {
            foreach (IManager manager in managerDict.Values)
                manager.UpdateDataFromGridView(gridView);
        }

        public void SaveDataToFile(bool original)
        {
            foreach (IManager manager in managerDict.Values)
                manager.SaveDataToFile(false);
        }

        public void AddData(ITranslatable addendum)
        {
            foreach (IManager manager in managerDict.Values)
                manager.AddData(addendum);
        }
    }
}
