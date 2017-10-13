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
        IManager fileManager;
        Dictionary<TroubleType, int> troubleDict = new Dictionary<TroubleType, int>();


        public void PrepareMembers(List<string> filesToAdd)
        {
            int i = 0;
            foreach (string file in filesToAdd)
            {
                string language = "lang" + (i++).ToString();
                CFileList.LanguageToFile.Add(language, file);
            }
            if (filesToAdd.Count < 2)
                return;

            System.Console.WriteLine("Total files with localizations found: " + CFileList.LanguageToFile.Count.ToString());
            string tempfile = CFileList.LanguageToFile.Values.First();
            fileManager = ManagerFactory.CreateManager(InterfaceLocalizer.WorkMode.multilang, tempfile);
            System.Console.WriteLine("Created manager: " + fileManager.ToString());

            fileManager.AddFileToManager("emty arg");
            System.Console.WriteLine("Files added to manager");

            foreach (TroubleType type in Enum.GetValues(typeof(TroubleType)))
                troubleDict.Add(type, 0);
        }

        public void calcStats()
        {
            Dictionary<object, ITranslatable> texts = fileManager.GetFullDictionary();
            TroubleType trouble;
            foreach (ITranslatable text in texts.Values)
                if (text.Troublesome(out trouble))
                    troubleDict[trouble]++;
        }

        public void showStats()
        {
            string stats = "";
            foreach (TroubleType trouble in Enum.GetValues(typeof(TroubleType)))
                if (trouble != TroubleType.none)
                    stats += "\n " + Enum.GetName(typeof(TroubleType), trouble) + ": " + troubleDict[trouble].ToString();

            System.Console.WriteLine(stats);
        }
    }
}
