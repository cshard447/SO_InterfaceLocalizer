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
    enum WorkMode { interfaces = 0, gossip = 1, multilang = 2};

    public partial class MainForm : Form
    {
        CDataManager dataManager = new CDataManager();
        CTextManager textManager = new CTextManager();
        CMultiManager multiManager = new CMultiManager();
        AppSettings appSettings;
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
                MessageBox.Show("Ошибка загрузки настроек. Перезапустите приложение", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Задайте путь к рабочему каталогу в настройках", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }

        private void LoadMultilang()
        {            
            var languages = appSettings.LanguagesNames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            var translatedFiles = appSettings.TranslationFilenames.Split(new string[] { ";" }, 3, StringSplitOptions.RemoveEmptyEntries);
            
            CFileList.LanguageToFile.Clear();
            int count = Math.Min(languages.Count(), translatedFiles.Count());
            for (int i = 0; i < count; i++)
            {
                if (File.Exists(translatedFiles[i]))
                    CFileList.LanguageToFile.Add(languages[i], translatedFiles[i]);
            }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(appSettings);
            sf.Show();
        }

        private void menuItemStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm(appSettings);
            sf.Show();
        }

        private void cmbShowData_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
                ShowDataOnGrid(dataManager, CFileList.CheckedFiles);
            else if (workMode == WorkMode.gossip)
                ShowDataOnGrid(textManager, CFileList.CheckedGossipFiles);
            else if (workMode == WorkMode.multilang)
                ShowDataOnGrid(multiManager, new List<string>{Properties.Settings.Default.OriginalTextFilename});
        }

        private void ShowDataOnGrid(IManager manager, List<string> source)
        {
            manager.ClearAllData();
            gridViewTranslation.Rows.Clear();
            foreach (string file in source)
                manager.AddFileToManager(file);

            Dictionary<int, ITranslatable> textDict = manager.GetFullDictionary();
            gridViewTranslation.BeginUpdate();
            foreach (int id in textDict.Keys)
                addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Found " + gridViewTranslation.Rows.Count + " strings";
        }

        private void cmbShowUndoneData_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
            {
                dataManager.ClearAllData();
                gridViewTranslation.Rows.Clear();

                foreach (string file in CFileList.CheckedFiles)
                    dataManager.AddFileToManager(file);

                Dictionary<int, ITranslatable> textDict = dataManager.GetFullDictionary();
                gridViewTranslation.BeginUpdate();
                foreach (int id in textDict.Keys)
                {
                    if (textDict[id].GetTranslation("eng") == "<NO DATA>" || textDict[id].GetTranslation("eng") == "")
                    {
                        addDataToGridView(id, textDict[id]);
                    }
                }
                gridViewTranslation.EndUpdate();
                cmlListedItems.Text = "Found " + gridViewTranslation.Rows.Count + " strings";
            }
        }

        private void addDataToGridView(int id, ITranslatable data)
        {
            object[] values = new object[6];
            values[0] = id.ToString();
            values[1] = Path.GetFileName(data.GetFilename());
            values[2] = data.GetPathString();
            values[3] = data.GetOriginalText();
            if (workMode == WorkMode.interfaces || workMode == WorkMode.gossip)
                values[4] = data.GetTranslation("eng");
            else
            {
                values[4] = data.GetTranslation(CFileList.LanguageToFile.Keys.ElementAt(0));
                values[5] = data.GetTranslation(CFileList.LanguageToFile.Keys.ElementAt(1));
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
                gridViewTranslation.Columns["columnOriginalPhrase"].Width = gridViewTranslation.Width / 2;
                gridViewTranslation.Columns["columnTranslation1"].Width = gridViewTranslation.Width / 2;
            }
            else
            {
                gridViewTranslation.Columns["columnOriginalPhrase"].Width = gridViewTranslation.Width = appSettings.ColRusWidth;
                gridViewTranslation.Columns["columnTranslation1"].Width = gridViewTranslation.Width = appSettings.ColEngWidth;
            }
        }

        private void cmbSaveTranslation_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
                SaveDataToFile(dataManager, false);
            else if (workMode == WorkMode.gossip)
                SaveDataToFile(textManager, false);
            else if (workMode == WorkMode.multilang)
                SaveDataToFile(multiManager, false);
        }

        private void cmbSaveOriginal_Click(object sender, EventArgs e)
        {
            if (workMode == WorkMode.interfaces)
                SaveDataToFile(dataManager, true);
            else if (workMode == WorkMode.gossip)
                SaveDataToFile(textManager, true);
            else if (workMode == WorkMode.multilang)
                SaveDataToFile(multiManager, true);
        }

        private void SaveDataToFile(IManager manager, bool originalText)
        {
            manager.UpdateDataFromGridView(gridViewTranslation);
            manager.SaveDataToFile(originalText);
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
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnOriginalPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation1"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = false;
            gridViewTranslation.Columns["columnOriginalPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnTranslation1"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.AutoSizeRows = true;
        }

        private void SetGossipView()
        {
            lMode.Text = "Gossip";
            gridViewTranslation.Columns["columnID"].IsVisible = false;
            gridViewTranslation.Columns["columnTags"].IsVisible = false;
            gridViewTranslation.Columns["columnFilename"].IsVisible = false;
            gridViewTranslation.Columns["columnOriginalPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation1"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = false;
            gridViewTranslation.Columns["columnOriginalPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnTranslation1"].TextAlignment = ContentAlignment.TopLeft;

            gridViewTranslation.AutoSizeRows = true;
        }

        private void SetMultilangView()
        {
            lMode.Text = "Multilang";
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnOriginalPhrase"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation1"].WrapText = true;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = true;
            gridViewTranslation.Columns["columnOriginalPhrase"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnTranslation1"].TextAlignment = ContentAlignment.TopLeft;
            gridViewTranslation.Columns["columnTranslation1"].HeaderText = CFileList.LanguageToFile.Keys.First();
            gridViewTranslation.Columns["columnTranslation2"].HeaderText = CFileList.LanguageToFile.Keys.ElementAt(1);
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