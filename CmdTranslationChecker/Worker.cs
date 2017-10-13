using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLocalizer.Classes;

namespace CmdTranslationChecker
{

    class Worker
    {
        private IManager fileManager;
        private Dictionary<TroubleType, int> troubleDict = new Dictionary<TroubleType, int>();
        private ExitCodes result;
        private bool Silent;

        public ExitCodes Result 
        { 
            get { return result; }
        }

        public Worker(int _inputParameters)
        {
            Silent = (_inputParameters & (int)InputParameters.silent) > 0;
        }

        public bool PrepareMembers(List<string> filesToAdd)
        {
            int i = 0;
            result = ExitCodes.success;
            foreach (string file in filesToAdd)
            {
                string language = "lang" + (i++).ToString();
                CFileList.LanguageToFile.Add(language, file);
            }
            System.Console.WriteLine("Total files with localizations found: " + CFileList.LanguageToFile.Count.ToString());
            if (filesToAdd.Count < 2)
            {
                result = ExitCodes.noFiles;
                WaitForUser();
                return false;
            }

            string tempfile = CFileList.LanguageToFile.Values.First();
            fileManager = ManagerFactory.CreateManager(InterfaceLocalizer.WorkMode.multilang, tempfile);
            System.Console.WriteLine("Created manager: " + fileManager.ToString());

            fileManager.AddFileToManager("emty arg");
            System.Console.WriteLine("Files added to manager");

            foreach (TroubleType type in Enum.GetValues(typeof(TroubleType)))
                troubleDict.Add(type, 0);
            return true;
        }

        public void calcStats()
        {
            Dictionary<object, ITranslatable> texts = fileManager.GetFullDictionary();
            TroubleType trouble;
            foreach (ITranslatable text in texts.Values)
                if (text.Troublesome(out trouble))
                {
                    troubleDict[trouble]++;
                    result = ExitCodes.notTranslated;
                }
        }

        public void showStats()
        {
            string stats = "";
            foreach (TroubleType trouble in Enum.GetValues(typeof(TroubleType)))
                if (trouble != TroubleType.none)
                    stats += "\n " + Enum.GetName(typeof(TroubleType), trouble) + ": " + troubleDict[trouble].ToString();

            System.Console.WriteLine(stats);
            WaitForUser();
        }

        private void WaitForUser()
        { 
            if (!Silent)
                System.Console.ReadLine();
        }

    }
}
