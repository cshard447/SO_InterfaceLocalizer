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
            Activate();
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
                //MessageBox.Show("Please specify the path to the working directory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }

        private void LoadMultilang()
        {
            var languages = appSettings.LanguagesNames.Split(new string[] { ";" }, 4, StringSplitOptions.RemoveEmptyEntries);
            var translatedFiles = appSettings.TranslationFilenames.Split(new string[] { ";" }, 4, StringSplitOptions.RemoveEmptyEntries);
            
            CFileList.LanguageToFile.Clear();
            int count = Math.Min(languages.Count(), translatedFiles.Count());
            for (int i = 0; i < count; i++)
                if (File.Exists(translatedFiles[i]))
                {
                    CFileList.LanguageToFile.Add(languages[i], translatedFiles[i]);
                    CFileList.MultilangFile.Add(translatedFiles[i]);
                }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(appSettings);
            sf.ShowDialog();
            Activate();
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
            TroubleType trouble;
            gridViewTranslation.BeginUpdate();
            foreach (object id in textDict.Keys)
                if (textDict[id].Troublesome(out trouble))
                    addDataToGridView(id, textDict[id]);

            gridViewTranslation.EndUpdate();
            cmlListedItems.Text = "Found " + gridViewTranslation.Rows.Count + " strings";
        }

        private void addDataToGridView(object id, ITranslatable data)
        {
            object[] values = data.GetAsRow();
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
                gridViewTranslation.Columns["columnTranslation0"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation1"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation2"].Width = gridViewTranslation.Width / 4;
                gridViewTranslation.Columns["columnTranslation3"].Width = gridViewTranslation.Width / 4;
            }
            else
            {
                gridViewTranslation.Columns["columnTranslation0"].Width = gridViewTranslation.Width = appSettings.ColRusWidth;
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
            appSettings.ColRusWidth = gridViewTranslation.Columns["columnTranslation0"].Width;
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
            gridViewTranslation.Columns["columnTranslation0"].Width = appSettings.ColRusWidth;
            gridViewTranslation.Columns["columnTranslation1"].Width = appSettings.ColEngWidth;
            gridViewTranslation.Columns["columnTranslation2"].Width = appSettings.ColLanguage2Width;
            gridViewTranslation.Columns["columnTranslation3"].Width = appSettings.ColLanguage3Width;
            showInfo = appSettings.ServiceColumnsVisible;
            menuItemCompleteMessage.IsChecked = appSettings.SpellCheckCompleteBox;
            SpellChecker.EnableCompleteMessageBox = appSettings.SpellCheckCompleteBox;
        }

        private void Activate()
        {
            workMode = (WorkMode) Properties.Settings.Default.WorkMode;
            currentFilelist = CFileList.GetProperList(workMode);
            currentManager = ManagerFactory.CreateManager(workMode, currentFilelist.First());

            lMode.Text = Enum.GetName(typeof(WorkMode), workMode);
            gridViewTranslation.Columns["columnID"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTags"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnFilename"].IsVisible = showInfo;
            gridViewTranslation.Columns["columnTranslation2"].IsVisible = false;
            gridViewTranslation.Columns["columnTranslation3"].IsVisible = false;

            switch (workMode)
            {
                case WorkMode.interfaces:
                    break;
                case  WorkMode.gossip:
                    gridViewTranslation.Columns["columnID"].IsVisible = false;
                    gridViewTranslation.Columns["columnTags"].IsVisible = false;
                    gridViewTranslation.Columns["columnFilename"].IsVisible = false;
                    break;
                case  WorkMode.multilang:
                    for (int i = 0; i <= CFileList.LanguageToFile.Count(); i++)
                    {
                        gridViewTranslation.Columns["columnTranslation" + i.ToString()].HeaderText = CFileList.LanguageToFile.Keys.ElementAt(i);
                        gridViewTranslation.Columns["columnTranslation" + i.ToString()].IsVisible = true;
                    }
                    break;
            }
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

        private void menuSaveCSV_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                string delimiter = ";";
                using (var stream = File.CreateText(file))
                {
                    foreach (var row in gridViewTranslation.Rows)
                    {
                        string line = "";
                        foreach (var column in gridViewTranslation.Columns.Where(u => u.IsVisible))
                            line += row.Cells[column.Name].Value.ToString() + delimiter;

                        stream.WriteLine(line);
                    }
                }
            }
        }
    }
}