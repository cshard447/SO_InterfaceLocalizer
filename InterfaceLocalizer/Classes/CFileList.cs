using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    public class CFileList
    {
        public static List<string> allFiles = new List<string>();
        public static List<string> checkedFiles = new List<string>();

        /*
        public static void setAllFilesList(List<string> files)
        {
            allFiles = files;
        }

        public static void setCheckedFilesList(List<string> files)
        {
            checkedFiles = files;
        }
         * */
        public static string getFilenameFromPath(string path)
        {
            string filename = "";
            int last = path.LastIndexOf("\\");
            filename = path.Substring(last + 1);
            return filename;
        }

        public static string getListAsString(List<string> list)
        {
            string result = "";
            foreach (string str in list)
                result += str + ";";
            return result;
        }
    }
}
