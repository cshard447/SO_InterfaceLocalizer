using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLocalizer.Classes;

namespace CmdTranslationChecker
{
    enum InputParameters { none = 0, silent = 1};
    enum ExitCodes { success = 0, noFiles = 1, notTranslated = 2};

    class Program
    {
        static int Main(string[] args)
        {
            List<string> filesToCheck = new List<string>();
            int parameters;
            CmdParser parser = new CmdParser();
            filesToCheck = parser.ParseCommandLine(out parameters);
            Worker worker = new Worker(parameters);

            if (worker.PrepareMembers(filesToCheck))
            {
                worker.calcStats();
                worker.showStats();
            }

            Environment.ExitCode = (int) worker.Result;
            return (int) worker.Result;
        }
    }

}
