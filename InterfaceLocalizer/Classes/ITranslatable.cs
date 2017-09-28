using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace InterfaceLocalizer.Classes
{
    interface ITranslatable
    {
        string GetOriginalText();
        string GetTranslation(String key);
        string GetFilename();
        string GetPathString();
        void SetRusData(string rusData);
        void SetEngData(string engData);
        XElement GetPath();
    }

    interface IManager
    {
        Dictionary<int, ITranslatable> GetFullDictionary();
        void ClearAllData();
        void AddFileToManager(string filename);
        void UpdateDataFromGridView(RadGridView gridView);
        void SaveDataToFile(bool original);
    }
}
