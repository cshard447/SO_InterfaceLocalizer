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
        string getRusData();
        string getEngData();
        string getFilename();
        string getTagsString();
        void setRusData(string rusData);
        void setEngData(string engData);
        Stack<string> getTags();
    }

    interface IManager
    {
        Dictionary<int, ITranslatable> getFullDictionary();
        void clearAllData();
        void addFileToManager(string filename);
        void updateDataFromGridView(RadGridView gridView);
        void saveDataToFile(bool english);
    }
}
