using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Telerik.WinControls.RichTextBox.Proofing;

namespace InterfaceLocalizer.Classes
{
    public class CRussianDict : WordDictionary
    {
        protected override void EnsureDictionaryLoadedOverride()
        {
            //base.EnsureDictionaryLoadedOverride();
            using (MemoryStream ms = new MemoryStream(Properties.Resources.ru_RU))
            {
                this.Load(ms);
            }
        }
    }
}
