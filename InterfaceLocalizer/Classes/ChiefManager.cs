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

        public ChiefManager()
        {
            managerDict = new Dictionary<object, IManager>();
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
            IManager tempManager = ManagerFactory.CreateManager(WorkMode.multilang, filename);
            string newKey = tempManager.ToString();
            if (!managerDict.ContainsKey(newKey))
                managerDict.Add(newKey, tempManager);

            managerDict[newKey].AddFileToManager(filename);
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
