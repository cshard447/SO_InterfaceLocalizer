using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            string path = Properties.Settings.Default.PathToFiles;
            string check = Properties.Settings.Default.CheckedFiles;
            string[] fileArray = check.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string file in fileArray)
                CFileList.checkedFiles.Add(file);
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.Show();
        }

        private void cmbShowData_Click(object sender, EventArgs e)
        {
            dataManager.clearAllData();
            gridViewTranslation.Rows.Clear();

            foreach (string file in CFileList.checkedFiles)
            {
                //string path = Properties.Settings.Default.PathToFiles + "\\Russian\\" + file;
                dataManager.addFileToManager(file);
            }

            List<CTextData> texts = dataManager.getTexts();
            foreach (CTextData td in texts)
            {
                string temp = "";
                while (td.tags.Count != 0)
                    temp += td.tags.Pop() + " -> ";

                object[] values = new object[4];
                values[0] = CFileList.getFilenameFromPath(td.filename);
                values[1] = temp;
                values[2] = td.phrase;
                values[3] = td.engPhrase;
                gridViewTranslation.Rows.Add(values);
            }
        }



    }
}
