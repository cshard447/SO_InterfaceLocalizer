using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
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
        string path;
        IEnumerable<string> files;
        List<string> fileList = new List<string>();
        int count = 0;

        public SettingsForm()
        {
            InitializeComponent();
            path = Properties.Settings.Default.PathToFiles;
            bePathToFiles.Value = Properties.Settings.Default.PathToFiles;
            foreach (ListViewDataItem item in lvFilesList.Items)
            {
                if (Properties.Settings.Default.CheckedFiles.Contains(item.Text))
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

            files = System.IO.Directory.EnumerateFiles(rusPath, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string filepath in files)
            {
                lvFilesList.Items.Add(CFileList.getFilenameFromPath(filepath));
                fileList.Add(CFileList.getFilenameFromPath(filepath));
                count++;
            }

            lFileCount.Text = "Найдено " + count.ToString() + " файла";
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            List<string> checkedFiles = new List<string>();
            foreach (ListViewDataItem item in lvFilesList.CheckedItems)
                checkedFiles.Add(item.Text);
            
            Properties.Settings.Default.PathToFiles = path;
            Properties.Settings.Default.CheckedFiles = CFileList.getListAsString(checkedFiles);
            Properties.Settings.Default.Save();

            CFileList.allFiles = fileList;
            CFileList.checkedFiles = checkedFiles;
            this.Close();
        }

        private void lvFilesList_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            int checkedCount = lvFilesList.CheckedItems.Count;
            lCheckedCount.Text = "Выделено " + checkedCount.ToString() + " файла";
        }

        private void cbSelectAll_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            foreach(ListViewDataItem item in lvFilesList.Items)
                item.CheckState = args.ToggleState;
        }
    }
}
