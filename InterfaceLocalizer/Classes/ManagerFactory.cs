using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    public class ManagerFactory
    {
        public static IManager CreateManager(WorkMode mode, String filename)
        {
            switch (mode)
            {   
                case WorkMode.interfaces:
                    return new CDataManager();
                case WorkMode.gossip:
                    return new CTextManager();
                case WorkMode.multilang:
                    if (Extension.Get(filename) == Extensions.xml)
                        return new CMultiManager();
                    else
                        return new CKeyValueManager();
            }
            return new CTextManager();
        }
    }
}
