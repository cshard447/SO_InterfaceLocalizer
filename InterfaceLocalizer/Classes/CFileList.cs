using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{

    public class CFileList
    {
        public static List<string> AllFiles = new List<string>();
        public static List<string> CheckedFiles = new List<string>();
        public static List<string> AllGossipFiles = new List<string>();
        public static List<string> CheckedGossipFiles = new List<string>();
        public static List<string> MultilangFile = new List<string>();
        public static Dictionary<string, string> LanguageToFile = new Dictionary<string, string>();

        public static string GetListAsString(List<string> list)
        {
            string result = "";
            foreach (string str in list)
                result += str + ";";
            return result;
        }
        public static List<string> GetListFromString(string value)
        {
            List<string> result = new List<string>();
            string []arr = value.Split(';');
            foreach (string str in arr)
                result.Add(str);
            return result;
        }

        public static List<string> GetProperList(WorkMode mode)
        {
            switch (mode)
            {
                case WorkMode.interfaces:
                    return CheckedFiles;
                case WorkMode.gossip:
                    return CheckedGossipFiles;
                case WorkMode.multilang:
                    return MultilangFile;
                default:
                    return AllFiles;
            }
        }

        public static int GetNumberOfFiles()
        {
            return LanguageToFile.Count;
        }
    }

}
