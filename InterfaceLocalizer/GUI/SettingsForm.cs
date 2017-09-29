using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using InterfaceLocalizer.Classes;
using InterfaceLocalizer.Properties;

namespace InterfaceLocalizer.GUI
{
    public partial class SettingsForm : Telerik.WinControls.UI.RadForm
    {
        AppSettings appSettings;
        string path;
        IEnumerable<string> files;
        List<string> fileList = new List<string>();
        int count = 0;

        string gossipPath;
        IEnumerable<string> gossipFiles;
        List<string> gossipFileList = new List<string>();
        int gossipCount = 0;

        public SettingsForm(AppSettings _appSettings)
        {
            InitializeComponent();
            appSettings = _appSettings;
            if (Properties.Settings.Default.WorkMode == (int)WorkMode.interfaces)
                pvSettings.SelectedPage = pageInterface;
            else if (Properties.Settings.Default.WorkMode == (int)WorkMode.gossip)
                pvSettings.SelectedPage = pageGossip;
            else if (Properties.Settings.Default.WorkMode == (int)WorkMode.multilang)
                pvSettings.SelectedPage = pageMultilang;
            
            LoadMultiLanguage();
            // иниициализируем данные об интерфейсах
            path = appSettings.PathToFiles;
            bePathToFiles.Value = appSettings.PathToFiles;
            List<string> filenames = CFileList.GetListFromString(appSettings.CheckedFiles);
            foreach (ListViewDataItem item in lvFilesList.Items)
            {
                if (filenames.Contains(item.Text))
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            
            gossipPath = appSettings.PathToGossip;
            bePathToGossip.Value = appSettings.PathToGossip;
            List<string> gossipFilenames = CFileList.GetListFromString(appSettings.CheckedGossipFiles);
            foreach (ListViewDataItem item in lvGossipList.Items)
            {
                if (gossipFilenames.Contains(item.Text))
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
        }

        private void bePathToFiles_ValueChanged(object sender, EventArgs e)
        {
            path = bePathToFiles.Value;
            string rusPath = path + "\\Russian\\";
            string engPath = path + "\\English\\";

            if (!System.IO.Directory.Exists(rusPath))
            {
                MessageBox.Show("Не существует папка Russian по указанному пути");
                return;
            }
            if (!System.IO.Directory.Exists(engPath))
            {
                MessageBox.Show("Не существует папка English по указанному пути");
                return;
            }

            //files = System.IO.Directory.EnumerateFiles(rusPath, "*.xml", SearchOption.TopDirectoryOnly);
            string[] extensions = { "*.json", "*.xml" };
            files = (extensions.AsParallel().SelectMany(searchPattern => Directory.EnumerateFiles(rusPath, searchPattern)));

            foreach (string filepath in files)
            {
                if (Path.GetFileName(filepath) == "soCheckBox.xml")    // костыль, так как файл содержит только пустую строку
                    continue;
                lvFilesList.Items.Add(Path.GetFileName(filepath));
                fileList.Add(Path.GetFileName(filepath));
                count++;
            }

            lFileCount.Text = "Found " + count.ToString() + " files";
        }

        private void bePathToGossip_ValueChanged(object sender, EventArgs e)
        {
            gossipPath = bePathToGossip.Value;
            string rusPath = gossipPath;    // +"\\Russian\\";
            string engPath = gossipPath;    // +"\\English\\";

            if (!System.IO.Directory.Exists(rusPath))
            {
                MessageBox.Show("Не существует папка Russian по указанному пути");
                return;
            }
            if (!System.IO.Directory.Exists(engPath))
            {
                MessageBox.Show("Не существует папка English по указанному пути");
                return;
            }

            gossipFiles = System.IO.Directory.EnumerateFiles(rusPath, "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string filepath in gossipFiles)
            {
                lvGossipList.Items.Add(Path.GetFileName(filepath));
                gossipFileList.Add(Path.GetFileName(filepath));
                gossipCount++;
            }

            lGossipFound.Text = "Found " + gossipCount.ToString() + " files";
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            List<string> checkedFiles = new List<string>();
            foreach (ListViewDataItem item in lvFilesList.CheckedItems)
                checkedFiles.Add(item.Text);

            appSettings.PathToFiles = path;
            appSettings.CheckedFiles = CFileList.GetListAsString(checkedFiles);
            appSettings.SaveSettings();

            CFileList.AllFiles = fileList;
            CFileList.CheckedFiles = checkedFiles;
            Properties.Settings.Default.WorkMode = (int) WorkMode.interfaces;
            this.Close();
        }

        private void bOkGossip_Click(object sender, EventArgs e)
        {
            List<string> checkedFiles = new List<string>();
            foreach (ListViewDataItem item in lvGossipList.CheckedItems)
                checkedFiles.Add(item.Text);

            appSettings.PathToGossip = gossipPath;
            appSettings.CheckedGossipFiles = CFileList.GetListAsString(checkedFiles);
            appSettings.SaveSettings();

            CFileList.AllGossipFiles = fileList;
            CFileList.CheckedGossipFiles = checkedFiles;
            Properties.Settings.Default.WorkMode = (int) WorkMode.gossip;
            this.Close();
        }

        private void lvFilesList_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            int checkedCount = lvFilesList.CheckedItems.Count;
            lCheckedCount.Text = "Selected " + checkedCount.ToString() + " files";
        }

        private void lvGossipList_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            int checkedCount = lvGossipList.CheckedItems.Count;
            lGossipChecked.Text = "Selected " + checkedCount.ToString() + " files";
        }

        private void cbSelectAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            foreach(ListViewDataItem item in lvFilesList.Items)
                item.CheckState = args.ToggleState;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Left = appSettings.SettingsFormLeft;
            this.Top = appSettings.SettingsFormTop;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            appSettings.SettingsFormLeft = this.Left;
            appSettings.SettingsFormTop = this.Top;
            appSettings.SaveSettings();
        }

        private void LoadMultiLanguage()
        {
            beOriginalFilename.Value = appSettings.OriginalTextFilename;
            var languages = appSettings.LanguagesNames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            tbLanguage1.Text = languages[0];
            tbLanguage2.Text = languages[1];
            tbLanguage3.Text = languages[2];

            var translatedFiles = appSettings.TranslationFilenames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            beLanguageFile1.Value = translatedFiles[0];
            beLanguageFile2.Value = translatedFiles[1];
            //beLanguageFile3.Value = translatedFiles[2];
        }

        private void bOKMulti_Click(object sender, EventArgs e)
        {
            appSettings.OriginalTextFilename = beOriginalFilename.Value;
            string langs = tbLanguage1.Text + ";" + tbLanguage2.Text + ";" + tbLanguage3.Text;
            appSettings.LanguagesNames = langs;
            string translationFiles = beLanguageFile1.Value + ";" + beLanguageFile2.Value + ";" + beLanguageFile3.Value;
            appSettings.TranslationFilenames = translationFiles;

            CFileList.LanguageToFile.Clear();
            if (beLanguageFile1.Value != "" && File.Exists(beLanguageFile1.Value))
                CFileList.LanguageToFile.Add(tbLanguage1.Text, beLanguageFile1.Value);
            if (beLanguageFile2.Value != "" && File.Exists(beLanguageFile2.Value))
                CFileList.LanguageToFile.Add(tbLanguage2.Text, beLanguageFile2.Value);
            if (beLanguageFile3.Value != "" && File.Exists(beLanguageFile3.Value))
                CFileList.LanguageToFile.Add(tbLanguage3.Text, beLanguageFile3.Value);

            appSettings.SaveSettings();
            Properties.Settings.Default.WorkMode = (int)WorkMode.multilang;
            this.Close();
        }

    }
}
