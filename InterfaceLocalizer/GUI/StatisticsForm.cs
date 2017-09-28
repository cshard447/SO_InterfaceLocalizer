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
        AppSettings appSettings;
        int filesCount = 0;
        int phrasesCount = 0;
        int symbolsCount =0 ;
        int engSymbols = 0 ;
        int nonLocalizedPhrases = 0;
        int nonLocalizedSymbols = 0;

        public StatisticsForm(AppSettings _appSettings)
        {
            InitializeComponent();
            appSettings = _appSettings;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            rbChecked.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.Left = appSettings.StatsFormLeft;
            this.Top = appSettings.StatsFormTop;
        }

        private void rbTotal_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            calcStats(CFileList.AllFiles);
        }

        private void rbChecked_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            calcStats(CFileList.CheckedFiles);
        }

        private void calcStats(List<string> fileList)
        {
            nullData();
            CDataManager dataManager = new CDataManager();
            filesCount = fileList.Count;
            foreach (string file in fileList)
                dataManager.AddFileToManager(file);

            Dictionary<int, ITranslatable> texts = dataManager.GetFullDictionary();
            phrasesCount = texts.Count;
            foreach (CXmlData text in texts.Values)
            {
                symbolsCount += text.GetOriginalText().Length;
                if (text.GetTranslation("eng") == "<NO DATA>" || text.GetTranslation("eng") == "")
                {
                    nonLocalizedPhrases++;
                    nonLocalizedSymbols += text.GetOriginalText().Length;
                }
                //else
                engSymbols += text.GetTranslation("eng").Length;

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
            appSettings.StatsFormLeft = this.Left;
            appSettings.StatsFormTop = this.Top;
            appSettings.SaveSettings();
        }
    }
}
