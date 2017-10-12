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
            filesToCheck = parser.ParseCommandLine();

            int i = 0;
            foreach (string file in filesToCheck)
            {
                string language = "lang" + (i++).ToString();
                CFileList.LanguageToFile.Add(language, file);
            }
            if (filesToCheck.Count < 2)
                return;
            

            Worker stuff = new Worker();
            stuff.PrepareMembers();
            stuff.calcStats();
            stuff.showStats();

            System.Console.ReadLine();
        }
    }

}
