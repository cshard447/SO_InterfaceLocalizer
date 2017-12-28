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

        List<RadPanel> panelList = new List<RadPanel>();
        int newPanelInitialHeight = 5;

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
            else if (Properties.Settings.Default.WorkMode == (int)WorkMode.groups)
                pvSettings.SelectedPage = pageGroups;
            
            LoadMultiLanguage();
            LoadGroupData();
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
                //MessageBox.Show("Не существует папка Russian по указанному путиXML");
                return;
            }
            if (!System.IO.Directory.Exists(engPath))
            {
                //MessageBox.Show("Не существует папка English по указанному пути");
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
                //MessageBox.Show("Не существует папка Russian по указанному путиTEXT");
                return;
            }
            if (!System.IO.Directory.Exists(engPath))
            {
                //MessageBox.Show("Не существует папка English по указанному пути");
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
            var languages = appSettings.LanguagesNames.Split(new string[] { ";" }, 4, StringSplitOptions.RemoveEmptyEntries);
            tbLanguage0.Text = (languages.Count() > 0) ? (languages[0]) : "";
            tbLanguage1.Text = (languages.Count() > 1) ? (languages[1]) : "";
            tbLanguage2.Text = (languages.Count() > 2 ) ? (languages[2]) : "";
            tbLanguage3.Text = (languages.Count() > 3 ) ? (languages[3]) : "";            

            var translatedFiles = appSettings.TranslationFilenames.Split(new string[] { ";" }, 4, StringSplitOptions.RemoveEmptyEntries);
            beLanguageFile0.Value = (translatedFiles.Count() > 0) ? (translatedFiles[0]) : "";
            beLanguageFile1.Value = (translatedFiles.Count() > 1) ? (translatedFiles[1]) : "";
            beLanguageFile2.Value = (translatedFiles.Count() > 2) ? (translatedFiles[2]) : "";
            beLanguageFile3.Value = (translatedFiles.Count() > 3) ? (translatedFiles[3]) : "";
        }

        private void bOKMulti_Click(object sender, EventArgs e)
        {
            string langs = tbLanguage0.Text + ";" + tbLanguage1.Text + ";" + tbLanguage2.Text + ";" + tbLanguage3.Text;
            appSettings.LanguagesNames = langs;
            string translationFiles = beLanguageFile0.Value + ";" + beLanguageFile1.Value + ";" + beLanguageFile2.Value + ";" + beLanguageFile3.Value;
            appSettings.TranslationFilenames = translationFiles;

            CFileList.LanguageToFile.Clear();
            if (beLanguageFile0.Value != "" && File.Exists(beLanguageFile0.Value))
                CFileList.LanguageToFile.Add(tbLanguage0.Text, beLanguageFile0.Value);
            if (beLanguageFile1.Value != "" && File.Exists(beLanguageFile1.Value))
                CFileList.LanguageToFile.Add(tbLanguage1.Text, beLanguageFile1.Value);
            if (beLanguageFile2.Value != "" && File.Exists(beLanguageFile2.Value))
                CFileList.LanguageToFile.Add(tbLanguage2.Text, beLanguageFile2.Value);
            if (beLanguageFile3.Value != "" && File.Exists(beLanguageFile3.Value))
                CFileList.LanguageToFile.Add(tbLanguage3.Text, beLanguageFile3.Value);

            CFileList.MultilangFile.Clear();
            foreach (string filename in CFileList.LanguageToFile.Values)
                CFileList.MultilangFile.Add(filename);

            appSettings.SaveSettings();
            Properties.Settings.Default.WorkMode = (int)WorkMode.multilang;
            this.Close();
        }

        private void bAddGroup_Click(object sender, EventArgs e)
        {
            RadTextBox textGroup = new RadTextBox();
            RadTextBox textbox1 = new RadTextBox();
            RadTextBox textbox2 = new RadTextBox();
            RadBrowseEditor browse1 = new RadBrowseEditor();
            RadBrowseEditor browse2 = new RadBrowseEditor();
            textGroup.Text = "Enter group name";
            textGroup.Location = new Point(130, 10);
            textbox1.Text = "Language name";
            textbox1.Location = new Point(15, 40);
            textbox2.Text = "Language name";
            textbox2.Location = new Point(15, 70);
            browse1.Location = new Point (130, 40);
            browse2.Location = new Point (130, 70);
            browse1.Width = 200;
            browse2.Width = 200;
            RadPanel panel = new RadPanel();
            panel.Width = pageGroups.Width;
            panel.Top = newPanelInitialHeight;
            panel.Controls.Add(textGroup);
            panel.Controls.Add(textbox1);
            panel.Controls.Add(textbox2);
            panel.Controls.Add(browse1);
            panel.Controls.Add(browse2);
            pageGroups.Controls.Add(panel);
            bAddGroup.Top += panel.Height + 10;
            newPanelInitialHeight += panel.Height + 10;
            panelList.Add(panel);
        }

        private void bOkGroups_Click(object sender, EventArgs e)
        {
            string groupNames = "";
            string languageNames = "";
            string fileNames = "";
            CFileList.GroupedFiles.Clear();

            foreach (RadPanel panel in panelList)
            {
                string groupName = panel.Controls[0].Text;
                string file1 = (panel.Controls[3] as RadBrowseEditor).Value;
                string file2 = (panel.Controls[4] as RadBrowseEditor).Value;

                groupNames += groupName + ";";
                languageNames += panel.Controls[1].Text + ";";
                languageNames += panel.Controls[2].Text + ";";
                fileNames += file1 + ";";
                fileNames += file2 + ";";

                CFileList.GroupedData[groupName] = new Dictionary<string, string>();
                CFileList.GroupedData[groupName].Add(panel.Controls[1].Text, file1);
                CFileList.GroupedData[groupName].Add(panel.Controls[2].Text, file2);
                CFileList.GroupedFiles.Add(file1);
                CFileList.GroupedFiles.Add(file2);
            }

            appSettings.GroupNames = groupNames;
            appSettings.LanguagesInsideGroups = languageNames;
            appSettings.FilesInsideGroups = fileNames;
            appSettings.SaveSettings();
            Properties.Settings.Default.WorkMode = (int)WorkMode.groups;
            this.Close();
        }

        private void LoadGroupData()
        {
            string[] groupNames = appSettings.GroupNames.Split(new string[] { ";" }, 4, StringSplitOptions.RemoveEmptyEntries);
            string[] languages = appSettings.LanguagesInsideGroups.Split(new string[] { ";" }, 8, StringSplitOptions.RemoveEmptyEntries);
            string[] files = appSettings.FilesInsideGroups.Split(new string[] { ";" }, 16, StringSplitOptions.RemoveEmptyEntries);

            int groupCounter = 0;
            int langCounter = 0;
            int fileCounter = 0;
            foreach (string group in groupNames)
            {
                bAddGroup_Click(this, null);
                panelList.ElementAt(groupCounter).Controls[0].Text = group;
                panelList.ElementAt(groupCounter).Controls[1].Text = languages[langCounter];
                panelList.ElementAt(groupCounter).Controls[2].Text = languages[++langCounter];
                (panelList.ElementAt(groupCounter).Controls[3] as RadBrowseEditor).Value = files[fileCounter];
                (panelList.ElementAt(groupCounter).Controls[4] as RadBrowseEditor).Value = files[++fileCounter];

                fileCounter ++;
                langCounter ++;
                groupCounter ++;
            }

        }

    }
}
