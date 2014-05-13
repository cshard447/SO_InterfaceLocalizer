using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            CFileList.checkedFiles.Clear();
            CFileList.allFiles.Clear();
            try
            {
                string path = Properties.Settings.Default.PathToFiles;
                string check = Properties.Settings.Default.CheckedFiles;
                string[] fileArray = check.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in fileArray)
                    CFileList.checkedFiles.Add(file);

                IEnumerable<string> files = System.IO.Directory.EnumerateFiles(path + "\\Russian\\", "*.xml", SearchOption.TopDirectoryOnly);
                foreach (string filepath in files)
                    CFileList.allFiles.Add(CFileList.getFilenameFromPath(filepath));
            }
            catch
            {
                MessageBox.Show("Задайте путь к рабочему каталогу в настройках", "Предупреждение");
            }
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

            Dictionary<int, CTextData> textDict = dataManager.getTextsDict();

            gridViewTranslation.BeginUpdate();
            foreach (int id in textDict.Keys)
                addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";
        }

        private void cmbShowUndoneData_Click(object sender, EventArgs e)
        {
            dataManager.clearAllData();
            gridViewTranslation.Rows.Clear();

            foreach (string file in CFileList.checkedFiles)
                dataManager.addFileToManager(file);

            Dictionary<int, CTextData> textDict = dataManager.getTextsDict();
            gridViewTranslation.BeginUpdate();
            foreach (int id in textDict.Keys)
            {
                if (textDict[id].engPhrase == "<NO DATA>" || textDict[id].engPhrase == "")
                {
                    addDataToGridView(id, textDict[id]);
                }
            }
            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";
        }

        private void addDataToGridView(int id, CTextData td)
        {
            Stack<string> copy = new Stack<string>(td.tags);
            copy = CFileList.invertStack(copy);
            string temp = "";
            while (copy.Count != 0)
                temp += copy.Pop() + " -> ";

            object[] values = new object[5];
            values[0] = id.ToString();
            values[1] = CFileList.getFilenameFromPath(td.filename);
            values[2] = temp;
            values[3] = td.phrase;
            values[4] = td.engPhrase;
            gridViewTranslation.Rows.Add(values);            
        }

        private void cmbColumnsHide_Click(object sender, EventArgs e)
        {
            gridViewTranslation.Columns["columnFileName"].IsVisible = !gridViewTranslation.Columns["columnFileName"].IsVisible;
            gridViewTranslation.Columns["columnTags"].IsVisible = !gridViewTranslation.Columns["columnTags"].IsVisible;
            gridViewTranslation.Columns["columnID"].IsVisible = !gridViewTranslation.Columns["columnID"].IsVisible;
            if (!gridViewTranslation.Columns["columnFileName"].IsVisible)
            {
                gridViewTranslation.Columns["columnRussianPhrase"].Width = gridViewTranslation.Width / 2;
                gridViewTranslation.Columns["columnEnglishPhrase"].Width = gridViewTranslation.Width / 2;
            }
            else
            {
                gridViewTranslation.Columns["columnRussianPhrase"].Width = gridViewTranslation.Width = Properties.Settings.Default.ColRusWidth;
                gridViewTranslation.Columns["columnEnglishPhrase"].Width = gridViewTranslation.Width = Properties.Settings.Default.ColEngWidth;
            }
        }

        private void cmbSaveChecked_Click(object sender, EventArgs e)
        {
            dataManager.updateTextsFromGridView(gridViewTranslation);
            dataManager.saveDataToFile(true);
        }

        private void cmbSaveRus_Click(object sender, EventArgs e)
        {
            dataManager.updateTextsFromGridView(gridViewTranslation);
            dataManager.saveDataToFile(false);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.MainFromTop = this.Top;
            Properties.Settings.Default.MainFormLeft = this.Left;
            Properties.Settings.Default.MainFormHeight = this.Height;
            Properties.Settings.Default.MainFormWidth = this.Width;
            Properties.Settings.Default.ServiceColumnsVisible = gridViewTranslation.Columns["columnID"].IsVisible;
            Properties.Settings.Default.ColIDWidth = gridViewTranslation.Columns["columnID"].Width;
            Properties.Settings.Default.ColFilenameWidth = gridViewTranslation.Columns["columnFilename"].Width;
            Properties.Settings.Default.ColTagsWidth = gridViewTranslation.Columns["columnTags"].Width;
            Properties.Settings.Default.ColRusWidth = gridViewTranslation.Columns["columnRussianPhrase"].Width;
            Properties.Settings.Default.ColEngWidth = gridViewTranslation.Columns["columnEnglishPhrase"].Width;
            Properties.Settings.Default.Save();
        }

        private void LoadSettings()
        {
            this.Top = Properties.Settings.Default.MainFromTop;
            this.Left = Properties.Settings.Default.MainFormLeft;
            this.Height = Properties.Settings.Default.MainFormHeight;
            this.Width = Properties.Settings.Default.MainFormWidth;
            gridViewTranslation.Columns["columnID"].IsVisible = Properties.Settings.Default.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnFilename"].IsVisible = Properties.Settings.Default.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnTags"].IsVisible = Properties.Settings.Default.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnID"].Width = Properties.Settings.Default.ColIDWidth;
            gridViewTranslation.Columns["columnFilename"].Width = Properties.Settings.Default.ColFilenameWidth;
            gridViewTranslation.Columns["columnTags"].Width = Properties.Settings.Default.ColTagsWidth;
            gridViewTranslation.Columns["columnRussianPhrase"].Width = Properties.Settings.Default.ColRusWidth;
            gridViewTranslation.Columns["columnEnglishPhrase"].Width = Properties.Settings.Default.ColEngWidth;
        }

    }
}