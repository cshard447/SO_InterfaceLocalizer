using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    class FolderDispatcher
    {
        private const string Original = "\\Russian\\";
        private const string Translation = "\\English\\";

        public static string OriginalPath()
        {
            string result = "";
            WorkMode mode = (WorkMode)Properties.Settings.Default.WorkMode;
            switch (mode)
            {
                case WorkMode.interfaces:
                    result = Properties.Settings.Default.PathToFiles;
                    result += Original;
                    break;
                case WorkMode.gossip:
                    result = Properties.Settings.Default.PathToGossip;
                    result += "\\";
                    break;
                case WorkMode.multilang:
                    result = Properties.Settings.Default.OriginalTextFilename;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string TranslationPath()
        {
            string result = "";
            WorkMode mode = (WorkMode)Properties.Settings.Default.WorkMode;
            switch (mode)
            {
                case WorkMode.interfaces:
                    result = Properties.Settings.Default.PathToFiles;
                    result += Translation;
                    break;
                case WorkMode.gossip:
                    result = Properties.Settings.Default.PathToGossip;
                    result += Translation;
                    break;
                case WorkMode.multilang:
                    result = Properties.Settings.Default.TranslationFilenames;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
