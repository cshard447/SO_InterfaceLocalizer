namespace InterfaceLocalizer.GUI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lCheckedCount = new Telerik.WinControls.UI.RadLabel();
            this.pvSettings = new Telerik.WinControls.UI.RadPageView();
            this.pageGroups = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageMultilang = new Telerik.WinControls.UI.RadPageViewPage();
            this.tbLanguage0 = new Telerik.WinControls.UI.RadTextBox();
            this.lSelectFilesForTranslations = new Telerik.WinControls.UI.RadLabel();
            this.beLanguageFile3 = new Telerik.WinControls.UI.RadBrowseEditor();
            this.beLanguageFile2 = new Telerik.WinControls.UI.RadBrowseEditor();
            this.beLanguageFile1 = new Telerik.WinControls.UI.RadBrowseEditor();
            this.tbLanguage3 = new Telerik.WinControls.UI.RadTextBox();
            this.tbLanguage2 = new Telerik.WinControls.UI.RadTextBox();
            this.tbLanguage1 = new Telerik.WinControls.UI.RadTextBox();
            this.beLanguageFile0 = new Telerik.WinControls.UI.RadBrowseEditor();
            this.lSelectMultilang = new Telerik.WinControls.UI.RadLabel();
            this.bOKMulti = new Telerik.WinControls.UI.RadButton();
            this.pageInterface = new Telerik.WinControls.UI.RadPageViewPage();
            this.cbSelectAll = new Telerik.WinControls.UI.RadCheckBox();
            this.lvFilesList = new Telerik.WinControls.UI.RadListView();
            this.bePathToFiles = new Telerik.WinControls.UI.RadBrowseEditor();
            this.lPathInfo = new Telerik.WinControls.UI.RadLabel();
            this.bOK = new Telerik.WinControls.UI.RadButton();
            this.pageGossip = new Telerik.WinControls.UI.RadPageViewPage();
            this.lGossipChecked = new Telerik.WinControls.UI.RadLabel();
            this.lGossipFound = new Telerik.WinControls.UI.RadLabel();
            this.cbSelectAllGossip = new Telerik.WinControls.UI.RadCheckBox();
            this.lvGossipList = new Telerik.WinControls.UI.RadListView();
            this.bePathToGossip = new Telerik.WinControls.UI.RadBrowseEditor();
            this.lPathToGossip = new Telerik.WinControls.UI.RadLabel();
            this.bOkGossip = new Telerik.WinControls.UI.RadButton();
            this.bAddGroup = new Telerik.WinControls.UI.RadButton();
            this.bOkGroups = new Telerik.WinControls.UI.RadButton();
            this.lFileCount = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSettings)).BeginInit();
            this.pvSettings.SuspendLayout();
            this.pageGroups.SuspendLayout();
            this.pageMultilang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lSelectFilesForTranslations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lSelectMultilang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOKMulti)).BeginInit();
            this.pageInterface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            this.pageGossip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lGossipChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lGossipFound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAllGossip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvGossipList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToGossip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathToGossip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOkGossip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAddGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOkGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lCheckedCount
            // 
            this.lCheckedCount.Location = new System.Drawing.Point(25, 439);
            this.lCheckedCount.Name = "lCheckedCount";
            this.lCheckedCount.Size = new System.Drawing.Size(2, 2);
            this.lCheckedCount.TabIndex = 7;
            // 
            // pvSettings
            // 
            this.pvSettings.Controls.Add(this.pageGroups);
            this.pvSettings.Controls.Add(this.pageMultilang);
            this.pvSettings.Controls.Add(this.pageInterface);
            this.pvSettings.Controls.Add(this.pageGossip);
            this.pvSettings.Location = new System.Drawing.Point(12, 12);
            this.pvSettings.Name = "pvSettings";
            this.pvSettings.SelectedPage = this.pageGroups;
            this.pvSettings.Size = new System.Drawing.Size(361, 531);
            this.pvSettings.TabIndex = 9;
            this.pvSettings.Text = "pageViewSettings";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvSettings.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvSettings.GetChildAt(0))).EnsureSelectedItemVisible = true;
            // 
            // pageGroups
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageGroups.Controls.Add(this.bOkGroups);
            this.pageGroups.Controls.Add(this.bAddGroup);
            this.pageGroups.Location = new System.Drawing.Point(10, 37);
            this.pageGroups.Name = "pageGroups";
            this.pageGroups.Size = new System.Drawing.Size(340, 483);
            this.pageGroups.Text = " Group Check";
            // 
            // pageMultilang
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageMultilang.Controls.Add(this.tbLanguage0);
            this.pageMultilang.Controls.Add(this.lSelectFilesForTranslations);
            this.pageMultilang.Controls.Add(this.beLanguageFile3);
            this.pageMultilang.Controls.Add(this.beLanguageFile2);
            this.pageMultilang.Controls.Add(this.beLanguageFile1);
            this.pageMultilang.Controls.Add(this.tbLanguage3);
            this.pageMultilang.Controls.Add(this.tbLanguage2);
            this.pageMultilang.Controls.Add(this.tbLanguage1);
            this.pageMultilang.Controls.Add(this.beLanguageFile0);
            this.pageMultilang.Controls.Add(this.lSelectMultilang);
            this.pageMultilang.Controls.Add(this.bOKMulti);
            this.pageMultilang.Location = new System.Drawing.Point(10, 37);
            this.pageMultilang.Name = "pageMultilang";
            this.pageMultilang.Size = new System.Drawing.Size(340, 483);
            this.pageMultilang.Text = "Multi language";
            // 
            // tbLanguage0
            // 
            this.tbLanguage0.Location = new System.Drawing.Point(11, 66);
            this.tbLanguage0.Name = "tbLanguage0";
            this.tbLanguage0.Size = new System.Drawing.Size(100, 20);
            this.tbLanguage0.TabIndex = 22;
            this.tbLanguage0.TabStop = false;
            this.tbLanguage0.Text = "Language name";
            // 
            // lSelectFilesForTranslations
            // 
            this.lSelectFilesForTranslations.Location = new System.Drawing.Point(11, 106);
            this.lSelectFilesForTranslations.Name = "lSelectFilesForTranslations";
            this.lSelectFilesForTranslations.Size = new System.Drawing.Size(264, 18);
            this.lSelectFilesForTranslations.TabIndex = 21;
            this.lSelectFilesForTranslations.Text = "Select files for translations and set language names:";
            // 
            // beLanguageFile3
            // 
            this.beLanguageFile3.Location = new System.Drawing.Point(123, 220);
            this.beLanguageFile3.Name = "beLanguageFile3";
            this.beLanguageFile3.Size = new System.Drawing.Size(201, 20);
            this.beLanguageFile3.TabIndex = 20;
            this.beLanguageFile3.Text = "radBrowseEditor3";
            // 
            // beLanguageFile2
            // 
            this.beLanguageFile2.Location = new System.Drawing.Point(123, 180);
            this.beLanguageFile2.Name = "beLanguageFile2";
            this.beLanguageFile2.Size = new System.Drawing.Size(201, 20);
            this.beLanguageFile2.TabIndex = 19;
            this.beLanguageFile2.Text = "radBrowseEditor2";
            // 
            // beLanguageFile1
            // 
            this.beLanguageFile1.Location = new System.Drawing.Point(123, 140);
            this.beLanguageFile1.Name = "beLanguageFile1";
            this.beLanguageFile1.Size = new System.Drawing.Size(201, 20);
            this.beLanguageFile1.TabIndex = 18;
            this.beLanguageFile1.Text = "radBrowseEditor1";
            // 
            // tbLanguage3
            // 
            this.tbLanguage3.Location = new System.Drawing.Point(11, 220);
            this.tbLanguage3.Name = "tbLanguage3";
            this.tbLanguage3.Size = new System.Drawing.Size(100, 20);
            this.tbLanguage3.TabIndex = 17;
            this.tbLanguage3.TabStop = false;
            this.tbLanguage3.Text = "Language name";
            // 
            // tbLanguage2
            // 
            this.tbLanguage2.Location = new System.Drawing.Point(11, 180);
            this.tbLanguage2.Name = "tbLanguage2";
            this.tbLanguage2.Size = new System.Drawing.Size(100, 20);
            this.tbLanguage2.TabIndex = 16;
            this.tbLanguage2.TabStop = false;
            this.tbLanguage2.Text = "Language name";
            // 
            // tbLanguage1
            // 
            this.tbLanguage1.Location = new System.Drawing.Point(11, 140);
            this.tbLanguage1.Name = "tbLanguage1";
            this.tbLanguage1.Size = new System.Drawing.Size(100, 20);
            this.tbLanguage1.TabIndex = 15;
            this.tbLanguage1.TabStop = false;
            this.tbLanguage1.Text = "Language name";
            // 
            // beLanguageFile0
            // 
            this.beLanguageFile0.Location = new System.Drawing.Point(123, 66);
            this.beLanguageFile0.Name = "beLanguageFile0";
            this.beLanguageFile0.Size = new System.Drawing.Size(201, 20);
            this.beLanguageFile0.TabIndex = 14;
            ((Telerik.WinControls.UI.RadBrowseEditorElement)(this.beLanguageFile0.GetChildAt(0))).Text = "(none)";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.beLanguageFile0.GetChildAt(0).GetChildAt(2).GetChildAt(0))).FlipText = true;
            // 
            // lSelectMultilang
            // 
            this.lSelectMultilang.Location = new System.Drawing.Point(11, 28);
            this.lSelectMultilang.Name = "lSelectMultilang";
            this.lSelectMultilang.Size = new System.Drawing.Size(245, 18);
            this.lSelectMultilang.TabIndex = 13;
            this.lSelectMultilang.Text = "Select a file with original phrases for translation:";
            // 
            // bOKMulti
            // 
            this.bOKMulti.Location = new System.Drawing.Point(214, 450);
            this.bOKMulti.Name = "bOKMulti";
            this.bOKMulti.Size = new System.Drawing.Size(110, 24);
            this.bOKMulti.TabIndex = 12;
            this.bOKMulti.Text = "ОК";
            this.bOKMulti.Click += new System.EventHandler(this.bOKMulti_Click);
            // 
            // pageInterface
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageInterface.Controls.Add(this.lFileCount);
            this.pageInterface.Controls.Add(this.cbSelectAll);
            this.pageInterface.Controls.Add(this.lCheckedCount);
            this.pageInterface.Controls.Add(this.lvFilesList);
            this.pageInterface.Controls.Add(this.bePathToFiles);
            this.pageInterface.Controls.Add(this.lPathInfo);
            this.pageInterface.Controls.Add(this.bOK);
            this.pageInterface.Location = new System.Drawing.Point(10, 37);
            this.pageInterface.Name = "pageInterface";
            this.pageInterface.Size = new System.Drawing.Size(340, 483);
            this.pageInterface.Text = "Xml folders";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.Location = new System.Drawing.Point(214, 415);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(94, 18);
            this.cbSelectAll.TabIndex = 13;
            this.cbSelectAll.Text = "Select all/none";
            this.cbSelectAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbSelectAll_ToggleStateChanged);
            // 
            // lvFilesList
            // 
            this.lvFilesList.Location = new System.Drawing.Point(11, 109);
            this.lvFilesList.Name = "lvFilesList";
            this.lvFilesList.ShowCheckBoxes = true;
            this.lvFilesList.Size = new System.Drawing.Size(313, 300);
            this.lvFilesList.TabIndex = 12;
            this.lvFilesList.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvFilesList_ItemCheckedChanged);
            // 
            // bePathToFiles
            // 
            this.bePathToFiles.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog;
            this.bePathToFiles.Location = new System.Drawing.Point(11, 63);
            this.bePathToFiles.Name = "bePathToFiles";
            this.bePathToFiles.Size = new System.Drawing.Size(313, 20);
            this.bePathToFiles.TabIndex = 11;
            this.bePathToFiles.ValueChanged += new System.EventHandler(this.bePathToFiles_ValueChanged);
            // 
            // lPathInfo
            // 
            this.lPathInfo.Location = new System.Drawing.Point(11, 25);
            this.lPathInfo.Name = "lPathInfo";
            this.lPathInfo.Size = new System.Drawing.Size(221, 18);
            this.lPathInfo.TabIndex = 10;
            this.lPathInfo.Text = "Select a folder with xml files for translation:";
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(214, 450);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 24);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "ОК";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // pageGossip
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageGossip.Controls.Add(this.lGossipChecked);
            this.pageGossip.Controls.Add(this.lGossipFound);
            this.pageGossip.Controls.Add(this.cbSelectAllGossip);
            this.pageGossip.Controls.Add(this.lvGossipList);
            this.pageGossip.Controls.Add(this.bePathToGossip);
            this.pageGossip.Controls.Add(this.lPathToGossip);
            this.pageGossip.Controls.Add(this.bOkGossip);
            this.pageGossip.Location = new System.Drawing.Point(10, 37);
            this.pageGossip.Name = "pageGossip";
            this.pageGossip.Size = new System.Drawing.Size(340, 483);
            this.pageGossip.Text = "Text data";
            // 
            // lGossipChecked
            // 
            this.lGossipChecked.Location = new System.Drawing.Point(14, 415);
            this.lGossipChecked.Name = "lGossipChecked";
            this.lGossipChecked.Size = new System.Drawing.Size(2, 2);
            this.lGossipChecked.TabIndex = 20;
            // 
            // lGossipFound
            // 
            this.lGossipFound.Location = new System.Drawing.Point(14, 439);
            this.lGossipFound.Name = "lGossipFound";
            this.lGossipFound.Size = new System.Drawing.Size(2, 2);
            this.lGossipFound.TabIndex = 19;
            // 
            // cbSelectAllGossip
            // 
            this.cbSelectAllGossip.Location = new System.Drawing.Point(214, 415);
            this.cbSelectAllGossip.Name = "cbSelectAllGossip";
            this.cbSelectAllGossip.Size = new System.Drawing.Size(94, 18);
            this.cbSelectAllGossip.TabIndex = 18;
            this.cbSelectAllGossip.Text = "Select all/none";
            // 
            // lvGossipList
            // 
            this.lvGossipList.Location = new System.Drawing.Point(11, 109);
            this.lvGossipList.Name = "lvGossipList";
            this.lvGossipList.ShowCheckBoxes = true;
            this.lvGossipList.Size = new System.Drawing.Size(313, 300);
            this.lvGossipList.TabIndex = 17;
            this.lvGossipList.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvGossipList_ItemCheckedChanged);
            // 
            // bePathToGossip
            // 
            this.bePathToGossip.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog;
            this.bePathToGossip.Location = new System.Drawing.Point(11, 63);
            this.bePathToGossip.Name = "bePathToGossip";
            this.bePathToGossip.Size = new System.Drawing.Size(313, 20);
            this.bePathToGossip.TabIndex = 16;
            this.bePathToGossip.ValueChanged += new System.EventHandler(this.bePathToGossip_ValueChanged);
            // 
            // lPathToGossip
            // 
            this.lPathToGossip.Location = new System.Drawing.Point(11, 25);
            this.lPathToGossip.Name = "lPathToGossip";
            this.lPathToGossip.Size = new System.Drawing.Size(216, 18);
            this.lPathToGossip.TabIndex = 15;
            this.lPathToGossip.Text = "Select a folder with txt files for translation:";
            // 
            // bOkGossip
            // 
            this.bOkGossip.Location = new System.Drawing.Point(214, 450);
            this.bOkGossip.Name = "bOkGossip";
            this.bOkGossip.Size = new System.Drawing.Size(110, 24);
            this.bOkGossip.TabIndex = 14;
            this.bOkGossip.Text = "ОК";
            this.bOkGossip.Click += new System.EventHandler(this.bOkGossip_Click);
            // 
            // bAddGroup
            // 
            this.bAddGroup.Location = new System.Drawing.Point(8, 3);
            this.bAddGroup.Name = "bAddGroup";
            this.bAddGroup.Size = new System.Drawing.Size(49, 33);
            this.bAddGroup.TabIndex = 16;
            this.bAddGroup.Text = "+";
            this.bAddGroup.Click += new System.EventHandler(this.bAddGroup_Click);
            // 
            // bOkGroups
            // 
            this.bOkGroups.Location = new System.Drawing.Point(214, 450);
            this.bOkGroups.Name = "bOkGroups";
            this.bOkGroups.Size = new System.Drawing.Size(110, 24);
            this.bOkGroups.TabIndex = 17;
            this.bOkGroups.Text = "ОК";
            this.bOkGroups.Click += new System.EventHandler(this.bOkGroups_Click);
            // 
            // lFileCount
            // 
            this.lFileCount.Location = new System.Drawing.Point(25, 415);
            this.lFileCount.Name = "lFileCount";
            this.lFileCount.Size = new System.Drawing.Size(2, 2);
            this.lFileCount.TabIndex = 14;
            // 
            // SettingsForm
            // 
            this.AccessibleDescription = "Settings form";
            this.AccessibleName = "Settings form";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 555);
            this.Controls.Add(this.pvSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Settings form";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSettings)).EndInit();
            this.pvSettings.ResumeLayout(false);
            this.pageGroups.ResumeLayout(false);
            this.pageMultilang.ResumeLayout(false);
            this.pageMultilang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lSelectFilesForTranslations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLanguage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beLanguageFile0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lSelectMultilang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOKMulti)).EndInit();
            this.pageInterface.ResumeLayout(false);
            this.pageInterface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            this.pageGossip.ResumeLayout(false);
            this.pageGossip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lGossipChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lGossipFound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAllGossip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvGossipList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToGossip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathToGossip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOkGossip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAddGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOkGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lCheckedCount;
        private Telerik.WinControls.UI.RadPageView pvSettings;
        private Telerik.WinControls.UI.RadPageViewPage pageInterface;
        private Telerik.WinControls.UI.RadCheckBox cbSelectAll;
        private Telerik.WinControls.UI.RadListView lvFilesList;
        private Telerik.WinControls.UI.RadBrowseEditor bePathToFiles;
        private Telerik.WinControls.UI.RadLabel lPathInfo;
        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadPageViewPage pageGossip;
        private Telerik.WinControls.UI.RadCheckBox cbSelectAllGossip;
        private Telerik.WinControls.UI.RadListView lvGossipList;
        private Telerik.WinControls.UI.RadBrowseEditor bePathToGossip;
        private Telerik.WinControls.UI.RadLabel lPathToGossip;
        private Telerik.WinControls.UI.RadButton bOkGossip;
        private Telerik.WinControls.UI.RadLabel lGossipChecked;
        private Telerik.WinControls.UI.RadLabel lGossipFound;
        private Telerik.WinControls.UI.RadPageViewPage pageMultilang;
        private Telerik.WinControls.UI.RadBrowseEditor beLanguageFile0;
        private Telerik.WinControls.UI.RadLabel lSelectMultilang;
        private Telerik.WinControls.UI.RadButton bOKMulti;
        private Telerik.WinControls.UI.RadLabel lSelectFilesForTranslations;
        private Telerik.WinControls.UI.RadBrowseEditor beLanguageFile3;
        private Telerik.WinControls.UI.RadBrowseEditor beLanguageFile2;
        private Telerik.WinControls.UI.RadBrowseEditor beLanguageFile1;
        private Telerik.WinControls.UI.RadTextBox tbLanguage3;
        private Telerik.WinControls.UI.RadTextBox tbLanguage2;
        private Telerik.WinControls.UI.RadTextBox tbLanguage1;
        private Telerik.WinControls.UI.RadTextBox tbLanguage0;
        private Telerik.WinControls.UI.RadPageViewPage pageGroups;
        private Telerik.WinControls.UI.RadButton bAddGroup;
        private Telerik.WinControls.UI.RadButton bOkGroups;
        private Telerik.WinControls.UI.RadLabel lFileCount;
    }
}
