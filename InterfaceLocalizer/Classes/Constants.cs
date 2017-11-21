using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    static class Const
    {
        public const string NO_DATA = "<NO DATA>";
    }


    enum Extensions { xml, strings, properties, text, json, unknown };

    static class Extension
    {
        private static bool activated = false;
        private static Dictionary<string, Extensions> converter;

        private static void Activate()
        {
            converter = new Dictionary<string, Extensions>();
            converter.Add(".strings", Extensions.strings);
            converter.Add(".properties", Extensions.properties);
            converter.Add(".xml", Extensions.xml);
            converter.Add(".txt", Extensions.text);
            converter.Add(".json", Extensions.json);
            activated = true;
        }

        public static Extensions Get(String filename)
        {
            if (!activated)
                Activate();

            string ext = Path.GetExtension(filename);
            if (converter.ContainsKey(ext))
                return converter[ext];
            else
                return Extensions.unknown;
        }
    }
}
