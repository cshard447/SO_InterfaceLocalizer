using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace InterfaceLocalizer.Classes
{
    interface ITranslatable
    {
        string GetRusData();
        string GetEngData();
        string GetFilename();
        string GetPathString();
        void SetRusData(string rusData);
        void SetEngData(string engData);
        [System.Obsolete("Method is no longer due to transition to XmlPath class")]
        Stack<string> GetTags();
    }

    interface IManager
    {
        Dictionary<int, ITranslatable> GetFullDictionary();
        void ClearAllData();
        void AddFileToManager(string filename);
        void UpdateDataFromGridView(RadGridView gridView);
        void SaveDataToFile(bool english);
    }
}
