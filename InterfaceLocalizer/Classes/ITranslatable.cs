using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
