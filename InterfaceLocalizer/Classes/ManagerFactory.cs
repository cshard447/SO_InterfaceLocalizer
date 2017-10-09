using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    class ManagerFactory
    {
        public static IManager CreateManager(WorkMode mode, String filename)
        {
            string extension = Path.GetExtension(filename);
            switch (mode)
            {   
                case WorkMode.interfaces:
                    return new CDataManager();
                case WorkMode.gossip:
                    return new CTextManager();
                case WorkMode.multilang:
                    if (extension == ".xml")
                        return new CMultiManager();
                    else
                        return new CKeyValueManager();
            }
            return new CTextManager();
        }
    }
}
