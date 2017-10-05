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
    public enum WorkMode { interfaces = 0, gossip = 1, multilang = 2};

    public partial class MainForm : Form
    {
        CDataManager dataManager = new CDataManager();
        CTextManager textManager = new CTextManager();
        //CMultiManager multiManager = new CMultiManager();
        CKeyValueManager multiManager = new CKeyValueManager();
        AppSettings appSettings;
        private IManager currentManager;
        private List<string> currentFilelist;
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
            try
            {
                appSettings = new AppSettings();
                LoadSettings();

                LoadData(appSettings.PathToFiles + "\\Russian\\", appSettings.CheckedFiles, "*.xml",
                        ref CFileList.AllFiles, ref CFileList.CheckedFiles);
                LoadData(appSettings.PathToGossip, appSettings.CheckedGossipFiles, "*.txt",
                        ref CFileList.AllGossipFiles, ref CFileList.CheckedGossipFiles);
                LoadMultilang();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't load your settings. Please restart the app", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Please specify the path to the working directory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }

        private void LoadMultilang()
        {            
            var languages = appSettings.LanguagesNames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            var translatedFiles = appSettings.TranslationFilenames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            
            CFileList.LanguageToFile.Clear();
            int count = Math.Min(languages.Count(), translatedFiles.Count());
            for (int i = 0; i < count; i++)
                if (File.Exists(translatedFiles[i]))
                    CFileList.LanguageToFile.Add(languages[i], translatedFiles[i]);
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(appSettings);
            sf.Show();
        }

        private void menuItemStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm(appSettings, workMode);
            sf.Show();
        }

        private void cmbShowData_Click(object sender, EventArgs e)
        {
            currentManager.ClearAllData();
            gridViewTranslation.Rows.Clear();
            foreach (string file in currentFilelist)
                currentManager.AddFileToManager(file);

            Dictionary<object, ITranslatable> textDict = currentManager.GetFullDictionary();
            gridViewTranslation.BeginUpdate();
            foreach (object id in textDict.Keys)
                addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Found " + gridViewTranslation.Rows.Count + " strings";
        }

        private void cmbShowTroublesomeData_Click(object sender, EventArgs e)
        {
            currentManager.ClearAllData();
            gridViewTranslation.Rows.Clear();

            foreach (string file in currentFilelist)
                currentManager.AddFileToManager(file);

            Dictionary<object, ITranslatable> textDict = currentManager.GetFullDictionary();
            gridViewTranslation.BeginUpdate();
            foreach (object id in textDict.Keys)
                if (textDict[id].Troublesome())
                    addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Found " + gridViewTranslation.Rows.Count + " strings";
        }

        private void addDataToGridView(object id, ITranslatable data)
        {
            object[] values = new object[7];
            values[0] = id.ToString();
            values[1] = Path.GetFileName(data.GetFilename());
            values[2] = data.GetPathString();
            values[3] = data.GetOriginalText();
            if (workMode == WorkMode.interfaces || workMode == WorkMode.gossip)
                values[4] = data.GetTranslation("eng");
            else
            {
                for (int i = 0; i < CFileList.LanguageToFile.Count(); i++ )
                    values[i+4] = data.GetTranslation(CFileList.LanguageToFile.Keys.ElementAt(i));
            }
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
                gridViewTranslation.Columns["columnOriginalPhrase"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation1"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation2"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation3"].Width = gridViewTranslation.Width / 4;
            }
            else
            {
                gridViewTranslation.Columns["columnOriginalPhrase"].Width = gridViewTranslation.Width = appSettings.ColRusWidth;
                gridViewTranslation.Columns["columnTranslation1"].Width = gridViewTranslation.Width = appSettings.ColEngWidth;
                gridViewTranslation.Columns["columnTranslation2"].Width = gridViewTranslation.Width = appSettings.ColLanguage2Width;
                gridViewTranslation.Columns["columnTranslation3"].Width = gridViewTranslation.Width = appSettings.ColLanguage3Width;
            }
        }

        private void cmbSaveTranslation_Click(object sender, EventArgs e)
        {
            currentManager.UpdateDataFromGridView(gridViewTranslation);
            currentManager.SaveDataToFile(false);
        }

        private void cmbSaveOriginal_Click(object sender, EventArgs e)
        {
            currentManager.UpdateDataFromGridView(gridViewTranslation);
            currentManager.SaveDataToFile(true);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            appSettings.MainFormTop = this.Top;
            appSettings.MainFormLeft = this.Left;
            appSettings.MainFormHeight = this.Height;
            appSettings.MainFormWidth = this.Width;
            appSettings.SpellCheckCompleteBox = menuItemCompleteMessage.IsChecked;
            appSettings.ServiceColumnsVisible = gridViewTranslation.Columns["columnID"].IsVisible;
            appSettings.ColIDWidth = gridViewTranslation.Columns["columnID"].Width;
            appSettings.ColFilenameWidth = gridViewTranslation.Columns["columnFilename"].Width;
            appSettings.ColTagsWidth = gridViewTranslation.Columns["columnTags"].Width;
            appSettings.ColRusWidth = gridViewTranslation.Columns["columnOriginalPhrase"].Width;
            appSettings.ColEngWidth = gridViewTranslation.Columns["columnTranslation1"].Width;
            appSettings.ColLanguage2Width = gridViewTranslation.Columns["columnTranslation2"].Width;
            appSettings.ColLanguage3Width = gridViewTranslation.Columns["columnTranslation3"].Width;
            appSettings.SaveSettings();
        }

        private void LoadSettings()
        {
            this.Top = appSettings.MainFormTop;
            this.Left = appSettings.MainFormLeft;
            this.Height = appSettings.MainFormHeight;
            this.Width = appSettings.MainFormWidth;
            
            gridViewTranslation.Columns["columnID"].IsVisible = appSettings.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnFilename"].IsVisible = appSettings.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnTags"].IsVisible = appSettings.ServiceColumnsVisible;
            gridViewTranslation.Columns["columnID"].Width = appSettings.ColIDWidth;
            gridViewTranslation.Columns["columnFilename"].Width = appSettings.ColFilenameWidth;
            gridViewTranslation.Columns["columnTags"].Width = appSettings.ColTagsWidth;
            gridViewTranslation.Columns["columnOriginalPhrase"].Width = appSettings.ColRusWidth;
            gridViewTranslation.Columns["columnTranslation1"].Width = appSettings.ColEngWidth;
            gridViewTranslation.Columns["columnTranslation2"].Width = appSettings.ColLanguage2Width;
            gridViewTranslation.Columns["columnTranslation3"].Width = appSettings.ColLanguage3Width;
            showInfo = appSettings.ServiceColumnsVisible;
            menuItemCompleteMessage.IsChecked = appSettings.SpellCheckCompleteBox;
            SpellChecker.EnableCompleteMessageBox = appSettings.SpellCheckCompleteBox;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            workMode = (WorkMode) Properties.Settings.Default.WorkMode;
            if (workMode == WorkMode.interfaces)
                SetInterfacesView();
            else if (workMode == WorkMode.gossip)
                SetGossipView();
            else if (workMode == WorkMode.multilang)
                SetMultilangView();
        }

        private void SetInterfacesView()
        {
            lMode.Text = "Interfaces";
            currentManager = dataManager;
            currentFilelist = CFileList.CheckedFiles;
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = false;
            gridViewTranslation.Columns["columnTranslation3"].IsVisible = false;
            gridViewTranslation.AutoSizeRows = true;
        }

        private void SetGossipView()
        {
            lMode.Text = "Gossip";
            currentManager = textManager;
            currentFilelist = CFileList.CheckedGossipFiles;
            gridViewTranslation.Columns["columnID"].IsVisible = false;
            gridViewTranslation.Columns["columnTags"].IsVisible = false;
            gridViewTranslation.Columns["columnFilename"].IsVisible = false;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = false;
            gridViewTranslation.Columns["columnTranslation3"].IsVisible = false;
            gridViewTranslation.AutoSizeRows = true;
        }

        private void SetMultilangView()
        {
            lMode.Text = "Multilang";
            currentManager = multiManager;
            currentFilelist = CFileList.MultilangFile;
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = true;
            gridViewTranslation.Columns["columnTranslation3"].IsVisible = true;
            for (int i = 1; i <= CFileList.LanguageToFile.Count(); i++)
                gridViewTranslation.Columns["columnTranslation" + i.ToString()].HeaderText = CFileList.LanguageToFile.Keys.ElementAt(i-1);
            gridViewTranslation.AutoSizeRows = true;
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

        private void menuItemCompleteMessage_Click(object sender, EventArgs e)
        {
            SpellChecker.EnableCompleteMessageBox = !SpellChecker.EnableCompleteMessageBox;
        }

        private void menuItemTest_Click(object sender, EventArgs e)
        {
            SpellChecker.SpellCheckMode = SpellCheckMode.AllAtOnce;
            //SpellChecker.SpellingFormStartPosition = FormStartPosition.
            var column = gridViewTranslation.Columns["columnTranslation1"];
            foreach (var row in gridViewTranslation.Rows)
            {                
                var cell = row.Cells["columnTranslation1"];                
                //SpellChecker.Check(cell.Value);   //gridViewTranslation.GridViewElement.hos
            }
        }
    }
}