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


        public void PrepareMembers()
        {
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
            /*
            foreach (string file in fileList)
                manager.AddFileToManager(file);*/

            Dictionary<object, ITranslatable> texts = fileManager.GetFullDictionary();
            TroubleType trouble;
            //phrasesCount = texts.Count;
            foreach (ITranslatable text in texts.Values)
            {
                //symbolsCount += text.GetOriginalText().Length;
                if (text.Troublesome(out trouble))
                {
                    //nonLocalizedPhrases++;
                    troubleDict[trouble]++;
                    //nonLocalizedSymbols += text.GetOriginalText().Length;
                }
                //else
                //engSymbols += text.GetTranslation("eng").Length;

            }
            //showStats();
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
