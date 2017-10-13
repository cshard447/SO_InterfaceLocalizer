using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLocalizer.Classes;

namespace CmdTranslationChecker
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string> filesToCheck = new List<string>();
            CmdParser parser = new CmdParser();
            Worker stuff = new Worker();
            filesToCheck = parser.ParseCommandLine();            

            stuff.PrepareMembers(filesToCheck);
            stuff.calcStats();
            stuff.showStats();

            System.Console.ReadLine();
        }
    }

}
