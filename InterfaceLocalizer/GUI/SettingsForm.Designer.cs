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
            this.bOK = new Telerik.WinControls.UI.RadButton();
            this.lPathInfo = new Telerik.WinControls.UI.RadLabel();
            this.bePathToFiles = new Telerik.WinControls.UI.RadBrowseEditor();
            this.lvFilesList = new Telerik.WinControls.UI.RadListView();
            this.lFileCount = new Telerik.WinControls.UI.RadLabel();
            this.lCheckedCount = new Telerik.WinControls.UI.RadLabel();
            this.cbSelectAll = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(262, 432);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 24);
            this.bOK.TabIndex = 1;
            this.bOK.Text = "ОК";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lPathInfo
            // 
            this.lPathInfo.Location = new System.Drawing.Point(59, 24);
            this.lPathInfo.Name = "lPathInfo";
            this.lPathInfo.Size = new System.Drawing.Size(313, 18);
            this.lPathInfo.TabIndex = 2;
            this.lPathInfo.Text = "Введите путь, по котрому расположены файлы с данными:";
            // 
            // bePathToFiles
            // 
            this.bePathToFiles.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog;
            this.bePathToFiles.Location = new System.Drawing.Point(59, 62);
            this.bePathToFiles.Name = "bePathToFiles";
            this.bePathToFiles.Size = new System.Drawing.Size(313, 20);
            this.bePathToFiles.TabIndex = 3;
            this.bePathToFiles.ValueChanged += new System.EventHandler(this.bePathToFiles_ValueChanged);
            // 
            // lvFilesList
            // 
            this.lvFilesList.Location = new System.Drawing.Point(59, 108);
            this.lvFilesList.Name = "lvFilesList";
            this.lvFilesList.ShowCheckBoxes = true;
            this.lvFilesList.Size = new System.Drawing.Size(313, 284);
            this.lvFilesList.TabIndex = 4;
            this.lvFilesList.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvFilesList_ItemCheckedChanged);
            // 
            // lFileCount
            // 
            this.lFileCount.Location = new System.Drawing.Point(59, 399);
            this.lFileCount.Name = "lFileCount";
            this.lFileCount.Size = new System.Drawing.Size(2, 2);
            this.lFileCount.TabIndex = 6;
            // 
            // lCheckedCount
            // 
            this.lCheckedCount.Location = new System.Drawing.Point(59, 422);
            this.lCheckedCount.Name = "lCheckedCount";
            this.lCheckedCount.Size = new System.Drawing.Size(2, 2);
            this.lCheckedCount.TabIndex = 7;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.Location = new System.Drawing.Point(248, 399);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(124, 18);
            this.cbSelectAll.TabIndex = 8;
            this.cbSelectAll.Text = "Выделить/Снять все";
            this.cbSelectAll.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.cbSelectAll_ToggleStateChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 481);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.lCheckedCount);
            this.Controls.Add(this.lFileCount);
            this.Controls.Add(this.lvFilesList);
            this.Controls.Add(this.bePathToFiles);
            this.Controls.Add(this.lPathInfo);
            this.Controls.Add(this.bOK);
            this.Name = "SettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Настройки";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lPathInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCheckedCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadLabel lPathInfo;
        private Telerik.WinControls.UI.RadBrowseEditor bePathToFiles;
        private Telerik.WinControls.UI.RadListView lvFilesList;
        private Telerik.WinControls.UI.RadLabel lFileCount;
        private Telerik.WinControls.UI.RadLabel lCheckedCount;
        private Telerik.WinControls.UI.RadCheckBox cbSelectAll;
    }
}
