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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.bePathToFiles = new Telerik.WinControls.UI.RadBrowseEditor();
            this.lvFilesList = new Telerik.WinControls.UI.RadListView();
            this.lFileCount = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).BeginInit();
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(59, 24);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(313, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Введите путь, по котрому расположены файлы с данными:";
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
            // 
            // lFileCount
            // 
            this.lFileCount.Location = new System.Drawing.Point(59, 399);
            this.lFileCount.Name = "lFileCount";
            this.lFileCount.Size = new System.Drawing.Size(2, 2);
            this.lFileCount.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 481);
            this.Controls.Add(this.lFileCount);
            this.Controls.Add(this.lvFilesList);
            this.Controls.Add(this.bePathToFiles);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.bOK);
            this.Name = "SettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Настройки";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePathToFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvFilesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lFileCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadBrowseEditor bePathToFiles;
        private Telerik.WinControls.UI.RadListView lvFilesList;
        private Telerik.WinControls.UI.RadLabel lFileCount;
    }
}
