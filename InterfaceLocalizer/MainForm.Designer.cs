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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject2 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject3 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject4 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.mainMenu = new Telerik.WinControls.UI.RadMenu();
            this.menuItemMain = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemStatistics = new Telerik.WinControls.UI.RadMenuItem();
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
            this.menuItemStatistics});
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
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.Name = "columnID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Filename";
            gridViewTextBoxColumn2.Name = "columnFileName";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 93;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Path & tags";
            gridViewTextBoxColumn3.Name = "columnTags";
            gridViewTextBoxColumn3.Width = 117;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Translation 0";
            gridViewTextBoxColumn4.MaxLength = 100000;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "columnTranslation0";
            gridViewTextBoxColumn4.StretchVertically = false;
            gridViewTextBoxColumn4.Width = 202;
            gridViewTextBoxColumn4.WrapText = true;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.Name = "NewCondition";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = "<NO DATA>";
            conditionalFormattingObject1.TValue2 = "\"\"";
            conditionalFormattingObject2.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            conditionalFormattingObject2.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.Name = "NewCondition";
            conditionalFormattingObject2.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.RowForeColor = System.Drawing.Color.Empty;
            gridViewTextBoxColumn5.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewTextBoxColumn5.ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Translation 1";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "columnTranslation1";
            gridViewTextBoxColumn5.Width = 181;
            gridViewTextBoxColumn5.WrapText = true;
            conditionalFormattingObject3.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject3.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject3.Name = "NewCondition";
            conditionalFormattingObject3.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject3.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject3.TValue1 = "<NO DATA>";
            conditionalFormattingObject3.TValue2 = "\"\"";
            gridViewTextBoxColumn6.ConditionalFormattingObjectList.Add(conditionalFormattingObject3);
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Translation 2";
            gridViewTextBoxColumn6.Name = "columnTranslation2";
            gridViewTextBoxColumn6.Width = 218;
            gridViewTextBoxColumn6.WrapText = true;
            conditionalFormattingObject4.CellBackColor = System.Drawing.Color.Red;
            conditionalFormattingObject4.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject4.Name = "NewCondition";
            conditionalFormattingObject4.RowBackColor = System.Drawing.Color.Empty;
            conditionalFormattingObject4.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject4.TValue1 = "<NO DATA>";
            conditionalFormattingObject4.TValue2 = "\"\"";
            gridViewTextBoxColumn7.ConditionalFormattingObjectList.Add(conditionalFormattingObject4);
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Translation3";
            gridViewTextBoxColumn7.Name = "columnTranslation3";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn7.WrapText = true;
            this.gridViewTranslation.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.gridViewTranslation.MasterTemplate.EnableFiltering = true;
            this.gridViewTranslation.MasterTemplate.EnableGrouping = false;
            this.gridViewTranslation.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            sortDescriptor1.PropertyName = "columnFileName";
            this.gridViewTranslation.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
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
            this.Activated += new System.EventHandler(this.MainForm_Activated);
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
    }
}

