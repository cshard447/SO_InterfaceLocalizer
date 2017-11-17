using InterfaceLocalizer.Classes;

namespace InterfaceLocalizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject6 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject7 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject8 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject9 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject10 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.mainMenu = new Telerik.WinControls.UI.RadMenu();
            this.menuItemMain = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemStatistics = new Telerik.WinControls.UI.RadMenuItem();
            this.menuSaveCSV = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemSpellCheck = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemCompleteMessage = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemTest = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarTranslation = new Telerik.WinControls.UI.RadCommandBar();
            this.cmbRow = new Telerik.WinControls.UI.CommandBarRowElement();
            this.cmbStripButtons = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmbShowData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbShowTroublesomeData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbColumnsHide = new Telerik.WinControls.UI.CommandBarButton();
            this.cmlListedItems = new Telerik.WinControls.UI.CommandBarLabel();
            this.cmbSaveTranslation = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbSaveOriginal = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbStripMode = new Telerik.WinControls.UI.CommandBarStripElement();
            this.lMode = new Telerik.WinControls.UI.CommandBarLabel();
            this.gridViewTranslation = new Telerik.WinControls.UI.RadGridView();
            this.SpellChecker = new Telerik.WinControls.UI.RadSpellChecker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemMain,
            this.menuItemSpellCheck});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(911, 20);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "radMenu1";
            // 
            // menuItemMain
            // 
            this.menuItemMain.AccessibleDescription = "Main";
            this.menuItemMain.AccessibleName = "Main";
            this.menuItemMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemSettings,
            this.menuItemStatistics,
            this.menuSaveCSV});
            this.menuItemMain.Name = "menuItemMain";
            this.menuItemMain.Text = "Main";
            this.menuItemMain.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.AccessibleDescription = "Settings";
            this.menuItemSettings.AccessibleName = "Settings";
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // menuItemStatistics
            // 
            this.menuItemStatistics.AccessibleDescription = "Statistics";
            this.menuItemStatistics.AccessibleName = "Statistics";
            this.menuItemStatistics.Name = "menuItemStatistics";
            this.menuItemStatistics.Text = "Statistics";
            this.menuItemStatistics.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemStatistics.Click += new System.EventHandler(this.menuItemStatistics_Click);
            // 
            // menuSaveCSV
            // 
            this.menuSaveCSV.AccessibleDescription = "menuSaveCSV";
            this.menuSaveCSV.AccessibleName = "menuSaveCSV";
            this.menuSaveCSV.Name = "menuSaveCSV";
            this.menuSaveCSV.Text = "Save as CSV...";
            this.menuSaveCSV.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuSaveCSV.Click += new System.EventHandler(this.menuSaveCSV_Click);
            // 
            // menuItemSpellCheck
            // 
            this.menuItemSpellCheck.AccessibleDescription = "Spell checker";
            this.menuItemSpellCheck.AccessibleName = "Spell checker";
            this.menuItemSpellCheck.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemCompleteMessage,
            this.menuItemTest});
            this.menuItemSpellCheck.Name = "menuItemSpellCheck";
            this.menuItemSpellCheck.Text = "Spell checker";
            this.menuItemSpellCheck.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuItemCompleteMessage
            // 
            this.menuItemCompleteMessage.AccessibleDescription = "Confirmation box";
            this.menuItemCompleteMessage.AccessibleName = "Confirmation box";
            this.menuItemCompleteMessage.CheckOnClick = true;
            this.menuItemCompleteMessage.Name = "menuItemCompleteMessage";
            this.menuItemCompleteMessage.Text = "Confirmation box";
            this.menuItemCompleteMessage.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemCompleteMessage.Click += new System.EventHandler(this.menuItemCompleteMessage_Click);
            // 
            // menuItemTest
            // 
            this.menuItemTest.AccessibleDescription = "Spell check test";
            this.menuItemTest.AccessibleName = "Spell check test";
            this.menuItemTest.Name = "menuItemTest";
            this.menuItemTest.Text = "Spell check test";
            this.menuItemTest.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemTest.Click += new System.EventHandler(this.menuItemTest_Click);
            // 
            // commandBarTranslation
            // 
            this.commandBarTranslation.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandBarTranslation.Location = new System.Drawing.Point(0, 20);
            this.commandBarTranslation.Name = "commandBarTranslation";
            this.commandBarTranslation.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.cmbRow});
            this.commandBarTranslation.Size = new System.Drawing.Size(911, 45);
            this.commandBarTranslation.TabIndex = 1;
            this.commandBarTranslation.Text = "radCommandBar1";
            // 
            // cmbRow
            // 
            this.cmbRow.MinSize = new System.Drawing.Size(25, 25);
            this.cmbRow.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.cmbStripButtons,
            this.cmbStripMode});
            this.cmbRow.Text = "";
            // 
            // cmbStripButtons
            // 
            this.cmbStripButtons.DisplayName = "Полоса управления";
            this.cmbStripButtons.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmbShowData,
            this.cmbShowTroublesomeData,
            this.cmbColumnsHide,
            this.cmlListedItems,
            this.cmbSaveTranslation,
            this.cmbSaveOriginal});
            this.cmbStripButtons.Name = "commandBarStripElement1";
            // 
            // cmbShowData
            // 
            this.cmbShowData.AccessibleDescription = "Show All";
            this.cmbShowData.AccessibleName = "Show All";
            this.cmbShowData.DisplayName = "Показать все данные";
            this.cmbShowData.DrawText = true;
            this.cmbShowData.Image = ((System.Drawing.Image)(resources.GetObject("cmbShowData.Image")));
            this.cmbShowData.Name = "cmbShowData";
            this.cmbShowData.Text = "Show All";
            this.cmbShowData.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmbShowData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbShowData.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbShowData.Click += new System.EventHandler(this.cmbShowData_Click);
            // 
            // cmbShowTroublesomeData
            // 
            this.cmbShowTroublesomeData.AccessibleDescription = "Show undone";
            this.cmbShowTroublesomeData.AccessibleName = "Show undone";
            this.cmbShowTroublesomeData.DisplayName = "Показать неготовые данные";
            this.cmbShowTroublesomeData.DrawText = true;
            this.cmbShowTroublesomeData.Image = ((System.Drawing.Image)(resources.GetObject("cmbShowTroublesomeData.Image")));
            this.cmbShowTroublesomeData.Name = "cmbShowTroublesomeData";
            this.cmbShowTroublesomeData.Text = "Show troubles";
            this.cmbShowTroublesomeData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbShowTroublesomeData.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbShowTroublesomeData.Click += new System.EventHandler(this.cmbShowTroublesomeData_Click);
            // 
            // cmbColumnsHide
            // 
            this.cmbColumnsHide.AccessibleDescription = "Info";
            this.cmbColumnsHide.AccessibleName = "Info";
            this.cmbColumnsHide.DisplayName = "Убрать столбцы";
            this.cmbColumnsHide.DrawText = true;
            this.cmbColumnsHide.Image = ((System.Drawing.Image)(resources.GetObject("cmbColumnsHide.Image")));
            this.cmbColumnsHide.Name = "cmbColumnsHide";
            this.cmbColumnsHide.Text = "More Info";
            this.cmbColumnsHide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbColumnsHide.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbColumnsHide.Click += new System.EventHandler(this.cmbColumnsHide_Click);
            // 
            // cmlListedItems
            // 
            this.cmlListedItems.DisplayName = "Число строк";
            this.cmlListedItems.Name = "cmlListedItems";
            this.cmlListedItems.Text = "";
            this.cmlListedItems.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmbSaveTranslation
            // 
            this.cmbSaveTranslation.AccessibleDescription = "Save Translations";
            this.cmbSaveTranslation.AccessibleName = "Save Translations";
            this.cmbSaveTranslation.DisplayName = "Сохранить Eng";
            this.cmbSaveTranslation.DrawText = true;
            this.cmbSaveTranslation.Image = ((System.Drawing.Image)(resources.GetObject("cmbSaveTranslation.Image")));
            this.cmbSaveTranslation.Name = "cmbSaveTranslation";
            this.cmbSaveTranslation.Text = "Save Translations";
            this.cmbSaveTranslation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbSaveTranslation.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbSaveTranslation.Click += new System.EventHandler(this.cmbSaveTranslation_Click);
            // 
            // cmbSaveOriginal
            // 
            this.cmbSaveOriginal.AccessibleDescription = "Save Original";
            this.cmbSaveOriginal.AccessibleName = "Save Original";
            this.cmbSaveOriginal.DisplayName = "Сохранить Rus";
            this.cmbSaveOriginal.DrawText = true;
            this.cmbSaveOriginal.Image = ((System.Drawing.Image)(resources.GetObject("cmbSaveOriginal.Image")));
            this.cmbSaveOriginal.Name = "cmbSaveOriginal";
            this.cmbSaveOriginal.Text = "Save Original";
            this.cmbSaveOriginal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmbSaveOriginal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbSaveOriginal.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbSaveOriginal.Click += new System.EventHandler(this.cmbSaveOriginal_Click);
            // 
            // cmbStripMode
            // 
            this.cmbStripMode.DisplayName = "commandBarStripElement1";
            this.cmbStripMode.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.lMode});
            this.cmbStripMode.Name = "commandBarStripElement1";
            // 
            // lMode
            // 
            this.lMode.AccessibleDescription = "TestText";
            this.lMode.AccessibleName = "TestText";
            this.lMode.DisplayName = "Режим работы";
            this.lMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMode.Name = "lMode";
            this.lMode.Text = "TestText";
            this.lMode.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // gridViewTranslation
            // 
            this.gridViewTranslation.AutoSizeRows = true;
            this.gridViewTranslation.BackColor = System.Drawing.SystemColors.Control;
            this.gridViewTranslation.CausesValidation = false;
            this.gridViewTranslation.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTranslation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewTranslation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewTranslation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewTranslation.Location = new System.Drawing.Point(0, 65);
            // 
            // gridViewTranslation
            // 
            this.gridViewTranslation.MasterTemplate.AllowAddNewRow = false;
            this.gridViewTranslation.MasterTemplate.AllowColumnReorder = false;
            this.gridViewTranslation.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "ID";
            gridViewTextBoxColumn8.Name = "columnID";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Filename";
            gridViewTextBoxColumn9.Name = "columnFileName";
            gridViewTextBoxColumn9.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn9.Width = 93;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "Path & tags";
            gridViewTextBoxColumn10.Name = "columnTags";
            gridViewTextBoxColumn10.Width = 117;
            conditionalFormattingObject6.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject6.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject6.Name = "NewCondition";
            conditionalFormattingObject6.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject6.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject6.TValue1 = Const.NO_DATA;
            conditionalFormattingObject6.TValue2 = "\"\"";
            gridViewTextBoxColumn11.ConditionalFormattingObjectList.Add(conditionalFormattingObject6);
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "Translation 0";
            gridViewTextBoxColumn11.MaxLength = 100000;
            gridViewTextBoxColumn11.Multiline = true;
            gridViewTextBoxColumn11.Name = "columnTranslation0";
            gridViewTextBoxColumn11.Width = 202;
            gridViewTextBoxColumn11.WrapText = true;
            conditionalFormattingObject7.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject7.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject7.Name = "NewCondition";
            conditionalFormattingObject7.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject7.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject7.TValue1 = Const.NO_DATA;
            conditionalFormattingObject7.TValue2 = "\"\"";
            conditionalFormattingObject8.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            conditionalFormattingObject8.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject8.Name = "NewCondition";
            conditionalFormattingObject8.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject8.RowForeColor = System.Drawing.Color.Empty;
            gridViewTextBoxColumn12.ConditionalFormattingObjectList.Add(conditionalFormattingObject7);
            gridViewTextBoxColumn12.ConditionalFormattingObjectList.Add(conditionalFormattingObject8);
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "Translation 1";
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "columnTranslation1";
            gridViewTextBoxColumn12.Width = 181;
            gridViewTextBoxColumn12.WrapText = true;
            conditionalFormattingObject9.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject9.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject9.Name = "NewCondition";
            conditionalFormattingObject9.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject9.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject9.TValue1 = Const.NO_DATA;
            conditionalFormattingObject9.TValue2 = "\"\"";
            gridViewTextBoxColumn13.ConditionalFormattingObjectList.Add(conditionalFormattingObject9);
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "Translation 2";
            gridViewTextBoxColumn13.Name = "columnTranslation2";
            gridViewTextBoxColumn13.Width = 218;
            gridViewTextBoxColumn13.WrapText = true;
            conditionalFormattingObject10.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject10.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject10.Name = "NewCondition";
            conditionalFormattingObject10.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject10.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject10.TValue1 = Const.NO_DATA;
            conditionalFormattingObject10.TValue2 = "\"\"";
            gridViewTextBoxColumn14.ConditionalFormattingObjectList.Add(conditionalFormattingObject10);
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.HeaderText = "Translation3";
            gridViewTextBoxColumn14.Name = "columnTranslation3";
            gridViewTextBoxColumn14.Width = 100;
            gridViewTextBoxColumn14.WrapText = true;
            this.gridViewTranslation.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.gridViewTranslation.MasterTemplate.EnableFiltering = true;
            this.gridViewTranslation.MasterTemplate.EnableGrouping = false;
            this.gridViewTranslation.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            sortDescriptor2.PropertyName = "columnFileName";
            this.gridViewTranslation.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.gridViewTranslation.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.gridViewTranslation.Name = "gridViewTranslation";
            this.gridViewTranslation.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.gridViewTranslation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewTranslation.Size = new System.Drawing.Size(911, 535);
            this.gridViewTranslation.TabIndex = 2;
            this.gridViewTranslation.Text = "radGridView1";
            this.gridViewTranslation.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridViewTranslation_CellEndEdit);
            this.gridViewTranslation.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.gridViewTranslation_CellValidating);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Translations.csv";
            this.saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            this.saveFileDialog.Title = "Save current view as a CSV file...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 600);
            this.Controls.Add(this.gridViewTranslation);
            this.Controls.Add(this.commandBarTranslation);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Interface localization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarTranslation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu mainMenu;
        private Telerik.WinControls.UI.RadMenuItem menuItemMain;
        private Telerik.WinControls.UI.RadMenuItem menuItemSettings;
        private Telerik.WinControls.UI.RadCommandBar commandBarTranslation;
        private Telerik.WinControls.UI.CommandBarRowElement cmbRow;
        private Telerik.WinControls.UI.CommandBarStripElement cmbStripButtons;
        private Telerik.WinControls.UI.RadGridView gridViewTranslation;
        private Telerik.WinControls.UI.CommandBarButton cmbShowData;
        private Telerik.WinControls.UI.CommandBarButton cmbColumnsHide;
        private Telerik.WinControls.UI.RadMenuItem menuItemStatistics;
        private Telerik.WinControls.UI.CommandBarLabel cmlListedItems;
        private Telerik.WinControls.UI.CommandBarButton cmbShowTroublesomeData;
        private Telerik.WinControls.UI.CommandBarButton cmbSaveTranslation;
        private Telerik.WinControls.UI.CommandBarButton cmbSaveOriginal;
        private Telerik.WinControls.UI.CommandBarStripElement cmbStripMode;
        private Telerik.WinControls.UI.CommandBarLabel lMode;
        private Telerik.WinControls.UI.RadSpellChecker SpellChecker;
        private Telerik.WinControls.UI.RadMenuItem menuItemSpellCheck;
        private Telerik.WinControls.UI.RadMenuItem menuItemCompleteMessage;
        private Telerik.WinControls.UI.RadMenuItem menuItemTest;
        private Telerik.WinControls.UI.RadMenuItem menuSaveCSV;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

