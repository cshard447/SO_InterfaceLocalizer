using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using Telerik.WinControls.RichTextBox.Proofing;

using InterfaceLocalizer.GUI;
using InterfaceLocalizer.Classes;
using InterfaceLocalizer.Properties;


namespace InterfaceLocalizer
{
    enum WorkMode { interfaces = 0, gossip = 1};

    public partial class MainForm : Form
    {
        CDataManager dataManager = new CDataManager();
        CTextManager textManager = new CTextManager();
        private WorkMode workMode;
        private bool showInfo;
        private string correctedValue = String.Empty;
        //IControlSpellChecker gridviewControlSpellChecker;
        //DocumentSpellChecker documentSpellChecker;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();

            LoadData(Properties.Settings.Default.PathToFiles + "\\Russian\\", Properties.Settings.Default.CheckedFiles, "*.xml",
                    ref CFileList.allFiles, ref CFileList.checkedFiles);
            LoadData(Properties.Settings.Default.PathToGossip, Properties.Settings.Default.CheckedGossipFiles, "*.txt",
                    ref CFileList.allGossipFiles, ref CFileList.checkedGossipFiles);

            //gridviewControlSpellChecker = SpellChecker.GetControlSpellChecker(typeof(RadTextBox));
            //documentSpellChecker = gridviewControlSpellChecker.SpellChecker as DocumentSpellChecker;
            //documentSpellChecker.AddDictionary(new CRussianDict(), RussianCulture);
            //documentSpellChecker.SpellCheckingCulture = RussianCulture;
        }

        private void LoadData(string path, string check, string mask, ref List<string> allFiles, ref List<string> checkedFiles)
        {
            allFiles.Clear();
            checkedFiles.Clear();
            try
            {
                string[] fileArray = check.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in fileArray)
                    checkedFiles.Add(file);

                IEnumerable<string> files = System.IO.Directory.EnumerateFiles(path, mask, SearchOption.TopDirectoryOnly);
                foreach (string filepath in files)
                    allFiles.Add(Path.GetFileName(filepath));
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
            if (workMode == WorkMode.interfaces)
                ShowDataOnGrid(dataManager, CFileList.checkedFiles);
            else if (workMode == WorkMode.gossip)
                ShowDataOnGrid(textManager, CFileList.checkedGossipFiles);
        }

        private void ShowDataOnGrid(IManager manager, List<string> source)
        {
            manager.clearAllData();
            gridViewTranslation.Rows.Clear();
            foreach (string file in source)
                manager.addFileToManager(file);

            Dictionary<int, ITranslatable> textDict = manager.getFullDictionary();
            gridViewTranslation.BeginUpdate();
            foreach (int id in textDict.Keys)
                addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";        
        }

        private void cmbShowUndoneData_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
            {
                dataManager.clearAllData();
                gridViewTranslation.Rows.Clear();

                foreach (string file in CFileList.checkedFiles)
                    dataManager.addFileToManager(file);

                Dictionary<int, ITranslatable> textDict = dataManager.getFullDictionary();
                gridViewTranslation.BeginUpdate();
                foreach (int id in textDict.Keys)
                {
                    if (textDict[id].getEngData() == "<NO DATA>" || textDict[id].getEngData() == "")
                    {
                        addDataToGridView(id, textDict[id]);
                    }
                }
                gridViewTranslation.EndUpdate();
                cmlListedItems.Text = "Выведено " + gridViewTranslation.Rows.Count + " строк";
            }
        }

        private void addDataToGridView(int id, ITranslatable data)
        {
            object[] values = new object[5];
            values[0] = id.ToString();
            values[1] = Path.GetFileName(data.getFilename());
            values[2] = data.getTagsString();
            values[3] = data.getRusData();
            values[4] = data.getEngData();
            gridViewTranslation.Rows.Add(values);
        }

        private void cmbColumnsHide_Click(object sender, EventArgs e)
        {
            showInfo = gridViewTranslation.Columns["columnTags"].IsVisible;     // get the visibility state
            showInfo = !showInfo;       // change the state of visibility
            gridViewTranslation.Columns["columnFileName"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            if (!showInfo)
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
            if (workMode == WorkMode.interfaces)
                SaveDataToFile(dataManager, true);
            else if (workMode == WorkMode.gossip)
                SaveDataToFile(textManager, true);
        }

        private void cmbSaveRus_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
                SaveDataToFile(dataManager, false);
            else if (workMode == WorkMode.gossip)
                SaveDataToFile(textManager, false);
        }

        private void SaveDataToFile(IManager manager, bool englishData)
        {
            manager.updateDataFromGridView(gridViewTranslation);
            manager.saveDataToFile(englishData);
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

        private void MainForm_Activated(object sender, EventArgs e)
        {
            workMode = (WorkMode) Properties.Settings.Default.WorkMode;
            if (workMode == WorkMode.interfaces)
                SetInterfacesView();
            else if (workMode == WorkMode.gossip)
                SetGossipView();
        }

        private void SetInterfacesView()
        {
            lMode.Text = "Interfaces";
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            //cmbColumnsHide_Click(null, null);
            gridViewTranslation.Columns["columnRussianPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnEnglishPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnRussianPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnEnglishPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.AutoSizeRows = true;
        }

        private void SetGossipView()
        {
            lMode.Text = "Gossip";
            gridViewTranslation.Columns["columnID"].IsVisible = false;
            gridViewTranslation.Columns["columnTags"].IsVisible = false;
            gridViewTranslation.Columns["columnFilename"].IsVisible = false;
            //cmbColumnsHide_Click(null, null);
            gridViewTranslation.Columns["columnRussianPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnEnglishPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnRussianPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnEnglishPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.AutoSizeRows = true;
            //gridViewTranslation.Columns["columnRussianPhrase"].StretchVertically = true;
            //gridViewTranslation.Columns["columnRussianPhrase"].AutoSizeMode = Telerik.WinControls.UI.BestFitColumnMode.DisplayedCells;
            //gridViewTranslation.AllowAutoSizeColumns = true;
            //gridViewTranslation.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;        
        }

        private void gridViewTranslation_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            RadTextBoxEditor editor = e.ActiveEditor as RadTextBoxEditor;
            if (editor != null)
            {
                RadTextBoxEditorElement element = editor.EditorElement as RadTextBoxEditorElement;
                SpellChecker.Check(element.TextBoxItem.HostedControl);
                correctedValue = e.ActiveEditor.Value.ToString();
            }
            
        }

        private void gridViewTranslation_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            gridViewTranslation.CurrentCell.Value = correctedValue;
        }

        private static readonly CultureInfo RussianCulture = CultureInfo.GetCultureInfo("ru-RU");
    }
}