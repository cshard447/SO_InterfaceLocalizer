using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using InterfaceLocalizer.GUI;
using InterfaceLocalizer.Classes;
using InterfaceLocalizer.Properties;


namespace InterfaceLocalizer
{
    public partial class MainForm : Form
    {
        CDataManager dataManager = new CDataManager();        
        string path;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CFileList.checkedFiles.Clear();
            CFileList.allFiles.Clear();
            string path = Properties.Settings.Default.PathToFiles;
            string check = Properties.Settings.Default.CheckedFiles;
            string[] fileArray = check.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string file in fileArray)
                CFileList.checkedFiles.Add(file);

            IEnumerable<string> files = System.IO.Directory.EnumerateFiles(path + "\\Russian\\", "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string filepath in files)
                CFileList.allFiles.Add(CFileList.getFilenameFromPath(filepath));
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.Show();
        }

        private void menuItemStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm();
            sf.Show();
        }

        private void cmbShowData_Click(object sender, EventArgs e)
        {
            dataManager.clearAllData();
            gridViewTranslation.Rows.Clear();

            foreach (string file in CFileList.checkedFiles)
                dataManager.addFileToManager(file);

            List<CTextData> texts = dataManager.getTexts();
            foreach (CTextData td in texts)
            {
                addDataToGridView(td);
            }
            cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";
        }

        private void cmbShowUndoneData_Click(object sender, EventArgs e)
        {
            dataManager.clearAllData();
            gridViewTranslation.Rows.Clear();

            foreach (string file in CFileList.checkedFiles)
                dataManager.addFileToManager(file);

            List<CTextData> texts = dataManager.getTexts();
            foreach (CTextData td in texts)
            {
                if (td.engPhrase == "<NO DATA>" || td.engPhrase == "")
                {
                    addDataToGridView(td);
                }
            }
            cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";
        }

        private void addDataToGridView(CTextData td)
        {
            Stack<string> copy = new Stack<string>(td.tags);
            copy = CFileList.invertStack(copy);
            string temp = "";
            while (copy.Count != 0)
                temp += copy.Pop() + " -> ";

            object[] values = new object[4];
            values[0] = CFileList.getFilenameFromPath(td.filename);
            values[1] = temp;
            values[2] = td.phrase;
            values[3] = td.engPhrase;
            gridViewTranslation.Rows.Add(values);        
        }

        private void cmbColumnsHide_Click(object sender, EventArgs e)
        {
            gridViewTranslation.Columns["columnFileName"].IsVisible = !gridViewTranslation.Columns["columnFileName"].IsVisible;
            gridViewTranslation.Columns["columnTags"].IsVisible = !gridViewTranslation.Columns["columnTags"].IsVisible;
        }

        private void cmbSaveChecked_Click(object sender, EventArgs e)
        {
            dataManager.saveDataToFile();
        }


    }
}
