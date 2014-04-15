using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using InterfaceLocalizer.Classes;
using InterfaceLocalizer.Properties;

namespace InterfaceLocalizer.GUI
{
    public partial class StatisticsForm : Telerik.WinControls.UI.RadForm
    {
        int phrasesCount = 0;
        int symbolsCount =0 ;
        int engSymbols = 0 ;
        int nonLocalizedPhrases = 0;
        int nonLocalizedSymbols = 0;        

        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            CDataManager dataManager = new CDataManager();
            foreach (string file in CFileList.allFiles)
                dataManager.addFileToManager(file);

            List<CTextData> texts = dataManager.getTexts();
            phrasesCount = texts.Count;           
            foreach (CTextData text in texts)
            {
                symbolsCount += text.phrase.Length;
                engSymbols += text.engPhrase.Length;
                if (text.engPhrase == "<NO DATA>" || text.engPhrase == "")
                {
                    nonLocalizedPhrases++;
                    nonLocalizedSymbols += text.phrase.Length;
                }
            }

            showStats();
        }

        private void showStats()
        {
            string stats = "Файлов для перевода: " + CFileList.allFiles.Count.ToString();
            stats += "\nФраз для перевода: " + phrasesCount.ToString();
            stats += "\nСимволов для перевода: " + symbolsCount.ToString();
            stats += "\n\n";

            stats += "Переведено символов: " + engSymbols.ToString();
            stats += "\nОсталось перевести фраз: " + nonLocalizedPhrases.ToString();
            stats += "\nОсталось перевести символов: " + nonLocalizedSymbols.ToString();

            lStats.Text = stats;
            lStats.Update();
        }
    }
}
