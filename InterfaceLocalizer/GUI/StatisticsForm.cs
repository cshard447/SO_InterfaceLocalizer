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
        IManager manager;
        List<string> fileList;
        int filesCount = 0;
        int phrasesCount = 0;
        int symbolsCount = 0;
        int engSymbols = 0;
        int nonLocalizedPhrases = 0;
        int nonLocalizedSymbols = 0;

        public StatisticsForm(AppSettings _appSettings, WorkMode mode)
        {
            InitializeComponent();
            appSettings = _appSettings;
            switch (mode)
            {
                case WorkMode.interfaces:
                    manager = new CDataManager();
                    fileList = CFileList.CheckedFiles;
                    break;
                case WorkMode.gossip:
                    manager = new CTextManager();
                    fileList = CFileList.CheckedGossipFiles;
                    break;
                case WorkMode.multilang:
                    manager = new CMultiManager();
                    fileList = CFileList.MultilangFile;
                    break;
                default:
                    break;
            }            
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
            //calcStats(CFileList.AllFiles);
            calcStats();
        }

        private void rbChecked_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            //calcStats(CFileList.CheckedFiles);
            calcStats();
        }

        private void calcStats()    // List<string> fileList
        {
            nullData();            
            filesCount = fileList.Count;
            foreach (string file in fileList)
                manager.AddFileToManager(file);

            Dictionary<object, ITranslatable> texts = manager.GetFullDictionary();
            phrasesCount = texts.Count;
            foreach (ITranslatable text in texts.Values)
            {
                symbolsCount += text.GetOriginalText().Length;
                if (text.Undone())
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
            string stats = "Files for translation: " + filesCount.ToString();
            stats += "\nPhrases totally: " + phrasesCount.ToString();
            stats += "\nSymbols totally: " + symbolsCount.ToString();
            stats += "\n\n";

            stats += "Symbols translated: " + engSymbols.ToString();
            stats += "\nPhrases left to translate: " + nonLocalizedPhrases.ToString();
            stats += "\nSymbols left to translate: " + nonLocalizedSymbols.ToString();

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
