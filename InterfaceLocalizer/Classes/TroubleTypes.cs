using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLocalizer.Classes
{
    public enum TroubleType { none, absence, duplicate, difference };

    static class Troubles
    {
        private static bool activated = false;
        private static Dictionary<TroubleType, string> converter;

        private static void Activate()
        {
            converter = new Dictionary<TroubleType, string>();
            converter.Add(TroubleType.none, "OK");
            converter.Add(TroubleType.absence, "No translation");
            converter.Add(TroubleType.duplicate, "Same texts in different languages");
            converter.Add(TroubleType.difference, "Different texts for same language");
            activated = true;
        }

        public static string GetText(TroubleType trouble)
        {
            if (!activated)
                Activate();
            string result = converter[trouble];
            return result;
        }
    }
}
