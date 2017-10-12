using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdTranslationChecker
{
    class CmdParser
    {
        public List<string> ParseCommandLine()
        {
            string[] cmd = Environment.GetCommandLineArgs();
            List<string> existedFiles = new List<string>();
            int i = 0;
            foreach (string file in cmd)
            {
                if (i == 0 && Path.GetExtension(file) == ".exe")
                {
                    System.Console.WriteLine("Started app: {0}", file);
                    continue;
                }
                //System.Console.WriteLine("Cmd parameter {0}: {1}", (i++).ToString(), file);
                if (File.Exists(file))
                {
                    existedFiles.Add(file);
                    System.Console.WriteLine("File found: {0}", file);
                }
                else
                    System.Console.WriteLine("File doesn't exist: {0}", file);
            }
            return existedFiles;
        }
    }
}
