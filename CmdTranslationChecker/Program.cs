using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLocalizer.Classes;

namespace CmdTranslationChecker
{
    enum ExitCodes { success = 0, noFiles = 1, notTranslated = 2};
    class Program
    {
        static int Main(string[] args)
        {
            List<string> filesToCheck = new List<string>();
            CmdParser parser = new CmdParser();
            filesToCheck = parser.ParseCommandLine();
            Worker worker = new Worker();

            if (worker.PrepareMembers(filesToCheck))
            {
                worker.calcStats();
                worker.showStats();
            }

            System.Console.ReadLine();
            Environment.ExitCode = (int) worker.Result;
            return (int) worker.Result;
        }
    }

}
