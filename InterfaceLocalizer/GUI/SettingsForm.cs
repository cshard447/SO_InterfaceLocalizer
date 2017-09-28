﻿using System;
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
            if (Properties.Settings.Default.WorkMode == (int) WorkMode.interfaces)
                pvSettings.SelectedPage = pageInterface;
            else if (Properties.Settings.Default.WorkMode == (int)WorkMode.gossip)
                pvSettings.SelectedPage = pageGossip;
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

            lFileCount.Text = "Найдено " + count.ToString() + " файла";
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

            lGossipFound.Text = "Найдено " + gossipCount.ToString() + " файла";
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
            lCheckedCount.Text = "Выделено " + checkedCount.ToString() + " файла";
        }

        private void lvGossipList_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            int checkedCount = lvGossipList.CheckedItems.Count;
            lGossipChecked.Text = "Выделено " + checkedCount.ToString() + " файла";
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

    }
}
