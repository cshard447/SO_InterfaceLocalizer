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
        int filesCount = 0;
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
            rbChecked.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.Left = Properties.Settings.Default.StatsFormLeft;
            this.Top = Properties.Settings.Default.StatsFormTop;
        }

        private void rbTotal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            calcStats(CFileList.allFiles);
        }

        private void rbChecked_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            calcStats(CFileList.checkedFiles);
        }

        private void calcStats(List<string> fileList)
        {
            nullData();
            CDataManager dataManager = new CDataManager();
            filesCount = fileList.Count;
            foreach (string file in fileList)
                dataManager.addFileToManager(file);

            Dictionary<int, CXmlData> texts = dataManager.getTextsDict();
            phrasesCount = texts.Count;
            foreach (CXmlData text in texts.Values)
            {
                symbolsCount += text.phrase.Length;
                if (text.engPhrase == "<NO DATA>" || text.engPhrase == "")
                {
                    nonLocalizedPhrases++;
                    nonLocalizedSymbols += text.phrase.Length;
                }
                //else
                    engSymbols += text.engPhrase.Length;

            }
            showStats();
        }

        private void showStats()
        {
            string stats = "Файлов для перевода: " + filesCount.ToString();
            stats += "\nФраз для перевода: " + phrasesCount.ToString();
            stats += "\nСимволов для перевода: " + symbolsCount.ToString();
            stats += "\n\n";

            stats += "Переведено символов: " + engSymbols.ToString();
            stats += "\nОсталось перевести фраз: " + nonLocalizedPhrases.ToString();
            stats += "\nОсталось перевести символов: " + nonLocalizedSymbols.ToString();

            lStats.Text = stats;
            lStats.Update();
        }

        private void nullData()
        {
            filesCount = 0;
            phrasesCount = 0;
            symbolsCount = 0;
            engSymbols = 0;
            nonLocalizedPhrases = 0;
            nonLocalizedSymbols = 0;         
        }

        private void StatisticsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.StatsFormLeft = this.Left;
            Properties.Settings.Default.StatsFormTop = this.Top;
            Properties.Settings.Default.Save();
        }
    }
}
