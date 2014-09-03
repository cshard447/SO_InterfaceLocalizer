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
            this.lFileCount = new Telerik.WinControls.UI.RadLabel();
            this.lCheckedCount = new Telerik.WinControls.UI.RadLabel();
            this.pvSettings = new Telerik.WinControls.UI.RadPageView();
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
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSettings)).BeginInit();
            this.pvSettings.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lFileCount
            // 
            this.lFileCount.Location = new System.Drawing.Point(8, 394);
            this.lFileCount.Name = "lFileCount";
            this.lFileCount.Size = new System.Drawing.Size(2, 2);
            this.lFileCount.TabIndex = 6;
            // 
            // lCheckedCount
            // 
            this.lCheckedCount.Location = new System.Drawing.Point(8, 418);
            this.lCheckedCount.Name = "lCheckedCount";
            this.lCheckedCount.Size = new System.Drawing.Size(2, 2);
            this.lCheckedCount.TabIndex = 7;
            // 
            // pvSettings
            // 
            this.pvSettings.Controls.Add(this.pageInterface);
            this.pvSettings.Controls.Add(this.pageGossip);
            this.pvSettings.Location = new System.Drawing.Point(12, 12);
            this.pvSettings.Name = "pvSettings";
            this.pvSettings.SelectedPage = this.pageInterface;
            this.pvSettings.Size = new System.Drawing.Size(356, 531);
            this.pvSettings.TabIndex = 9;
            this.pvSettings.Text = "radPageView1";
            // 
            // pageInterface
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.pageInterface.Controls.Add(this.cbSelectAll);
            this.pageInterface.Controls.Add(this.lCheckedCount);
            this.pageInterface.Controls.Add(this.lvFilesList);
            this.pageInterface.Controls.Add(this.lFileCount);
            this.pageInterface.Controls.Add(this.bePathToFiles);
            this.pageInterface.Controls.Add(this.lPathInfo);
            this.pageInterface.Controls.Add(this.bOK);
            this.pageInterface.Location = new System.Drawing.Point(10, 37);
            this.pageInterface.Name = "pageInterface";
            this.pageInterface.Size = new System.Drawing.Size(335, 483);
            this.pageInterface.Text = "Интерфейсы";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.Location = new System.Drawing.Point(197, 394);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(124, 18);
            this.cbSelectAll.TabIndex = 13;
            this.cbSelectAll.Text = "Выделить/Снять все";
            this.cbSelectAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbSelectAll_ToggleStateChanged);
            // 
            // lvFilesList
            // 
            this.lvFilesList.Location = new System.Drawing.Point(8, 103);
            this.lvFilesList.Name = "lvFilesList";
            this.lvFilesList.ShowCheckBoxes = true;
            this.lvFilesList.Size = new System.Drawing.Size(313, 284);
            this.lvFilesList.TabIndex = 12;
            this.lvFilesList.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvFilesList_ItemCheckedChanged);
            // 
            // bePathToFiles
            // 
            this.bePathToFiles.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog;
            this.bePathToFiles.Location = new System.Drawing.Point(8, 57);
            this.bePathToFiles.Name = "bePathToFiles";
            this.bePathToFiles.Size = new System.Drawing.Size(313, 20);
            this.bePathToFiles.TabIndex = 11;
            this.bePathToFiles.ValueChanged += new System.EventHandler(this.bePathToFiles_ValueChanged);
            // 
            // lPathInfo
            // 
            this.lPathInfo.Location = new System.Drawing.Point(8, 19);
            this.lPathInfo.Name = "lPathInfo";
            this.lPathInfo.Size = new System.Drawing.Size(320, 18);
            this.lPathInfo.TabIndex = 10;
            this.lPathInfo.Text = "Введите путь, по которому расположены файлы с данными:";
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(211, 427);
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
            this.pageGossip.Size = new System.Drawing.Size(335, 483);
            this.pageGossip.Text = "Слухи";
            // 
            // lGossipChecked
            // 
            this.lGossipChecked.Location = new System.Drawing.Point(11, 424);
            this.lGossipChecked.Name = "lGossipChecked";
            this.lGossipChecked.Size = new System.Drawing.Size(2, 2);
            this.lGossipChecked.TabIndex = 20;
            // 
            // lGossipFound
            // 
            this.lGossipFound.Location = new System.Drawing.Point(11, 400);
            this.lGossipFound.Name = "lGossipFound";
            this.lGossipFound.Size = new System.Drawing.Size(2, 2);
            this.lGossipFound.TabIndex = 19;
            // 
            // cbSelectAllGossip
            // 
            this.cbSelectAllGossip.Location = new System.Drawing.Point(200, 400);
            this.cbSelectAllGossip.Name = "cbSelectAllGossip";
            this.cbSelectAllGossip.Size = new System.Drawing.Size(124, 18);
            this.cbSelectAllGossip.TabIndex = 18;
            this.cbSelectAllGossip.Text = "Выделить/Снять все";
            // 
            // lvGossipList
            // 
            this.lvGossipList.Location = new System.Drawing.Point(11, 109);
            this.lvGossipList.Name = "lvGossipList";
            this.lvGossipList.ShowCheckBoxes = true;
            this.lvGossipList.Size = new System.Drawing.Size(313, 284);
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
            this.lPathToGossip.Size = new System.Drawing.Size(314, 18);
            this.lPathToGossip.TabIndex = 15;
            this.lPathToGossip.Text = "Введите путь, по котрому расположены файлы со слухами:";
            // 
            // bOkGossip
            // 
            this.bOkGossip.Location = new System.Drawing.Point(214, 433);
            this.bOkGossip.Name = "bOkGossip";
            this.bOkGossip.Size = new System.Drawing.Size(110, 24);
            this.bOkGossip.TabIndex = 14;
            this.bOkGossip.Text = "ОК";
            this.bOkGossip.Click += new System.EventHandler(this.bOkGossip_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 555);
            this.Controls.Add(this.pvSettings);
            this.Name = "SettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Настройки";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSettings)).EndInit();
            this.pvSettings.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lFileCount;
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
    }
}
