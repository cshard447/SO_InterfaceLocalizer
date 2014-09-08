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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.mainMenu = new Telerik.WinControls.UI.RadMenu();
            this.menuItemMain = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemStatistics = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarTranslation = new Telerik.WinControls.UI.RadCommandBar();
            this.cmbRow = new Telerik.WinControls.UI.CommandBarRowElement();
            this.cmbStripButtons = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmbShowData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbShowUndoneData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbColumnsHide = new Telerik.WinControls.UI.CommandBarButton();
            this.cmlListedItems = new Telerik.WinControls.UI.CommandBarLabel();
            this.cmbSaveEng = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbSaveRus = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbStripMode = new Telerik.WinControls.UI.CommandBarStripElement();
            this.lMode = new Telerik.WinControls.UI.CommandBarLabel();
            this.gridViewTranslation = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTranslation.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemMain});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(887, 20);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "radMenu1";
            // 
            // menuItemMain
            // 
            this.menuItemMain.AccessibleDescription = "Главное";
            this.menuItemMain.AccessibleName = "Главное";
            this.menuItemMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemSettings,
            this.menuItemStatistics});
            this.menuItemMain.Name = "menuItemMain";
            this.menuItemMain.Text = "Главное";
            this.menuItemMain.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.AccessibleDescription = "Настройки";
            this.menuItemSettings.AccessibleName = "Настройки";
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Text = "Настройки";
            this.menuItemSettings.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // menuItemStatistics
            // 
            this.menuItemStatistics.AccessibleDescription = "Статистика";
            this.menuItemStatistics.AccessibleName = "Статистика";
            this.menuItemStatistics.Name = "menuItemStatistics";
            this.menuItemStatistics.Text = "Статистика";
            this.menuItemStatistics.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuItemStatistics.Click += new System.EventHandler(this.menuItemStatistics_Click);
            // 
            // commandBarTranslation
            // 
            this.commandBarTranslation.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandBarTranslation.Location = new System.Drawing.Point(0, 20);
            this.commandBarTranslation.Name = "commandBarTranslation";
            this.commandBarTranslation.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.cmbRow});
            this.commandBarTranslation.Size = new System.Drawing.Size(887, 45);
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
            this.cmbShowUndoneData,
            this.cmbColumnsHide,
            this.cmlListedItems,
            this.cmbSaveEng,
            this.cmbSaveRus});
            this.cmbStripButtons.Name = "commandBarStripElement1";
            // 
            // cmbShowData
            // 
            this.cmbShowData.AccessibleDescription = "Показать данные";
            this.cmbShowData.AccessibleName = "Показать данные";
            this.cmbShowData.DisplayName = "Показать все данные";
            this.cmbShowData.DrawText = true;
            this.cmbShowData.Image = ((System.Drawing.Image)(resources.GetObject("cmbShowData.Image")));
            this.cmbShowData.Name = "cmbShowData";
            this.cmbShowData.Text = "Показать все";
            this.cmbShowData.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmbShowData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbShowData.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbShowData.Click += new System.EventHandler(this.cmbShowData_Click);
            // 
            // cmbShowUndoneData
            // 
            this.cmbShowUndoneData.AccessibleDescription = "Показать неготовые";
            this.cmbShowUndoneData.AccessibleName = "Показать неготовые";
            this.cmbShowUndoneData.DisplayName = "Показать неготовые данные";
            this.cmbShowUndoneData.DrawText = true;
            this.cmbShowUndoneData.Image = ((System.Drawing.Image)(resources.GetObject("cmbShowUndoneData.Image")));
            this.cmbShowUndoneData.Name = "cmbShowUndoneData";
            this.cmbShowUndoneData.Text = "Показать неготовые";
            this.cmbShowUndoneData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbShowUndoneData.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbShowUndoneData.Click += new System.EventHandler(this.cmbShowUndoneData_Click);
            // 
            // cmbColumnsHide
            // 
            this.cmbColumnsHide.AccessibleDescription = "Убрать инфо";
            this.cmbColumnsHide.AccessibleName = "Убрать инфо";
            this.cmbColumnsHide.DisplayName = "Убрать столбцы";
            this.cmbColumnsHide.DrawText = true;
            this.cmbColumnsHide.Image = ((System.Drawing.Image)(resources.GetObject("cmbColumnsHide.Image")));
            this.cmbColumnsHide.Name = "cmbColumnsHide";
            this.cmbColumnsHide.Text = "Убрать инфо";
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
            // cmbSaveEng
            // 
            this.cmbSaveEng.AccessibleDescription = "Сохранить";
            this.cmbSaveEng.AccessibleName = "Сохранить";
            this.cmbSaveEng.DisplayName = "Сохранить Eng";
            this.cmbSaveEng.DrawText = true;
            this.cmbSaveEng.Image = ((System.Drawing.Image)(resources.GetObject("cmbSaveEng.Image")));
            this.cmbSaveEng.Name = "cmbSaveEng";
            this.cmbSaveEng.Text = "Сохранить Eng";
            this.cmbSaveEng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbSaveEng.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbSaveEng.Click += new System.EventHandler(this.cmbSaveChecked_Click);
            // 
            // cmbSaveRus
            // 
            this.cmbSaveRus.AccessibleDescription = "Сохранить Rus";
            this.cmbSaveRus.AccessibleName = "Сохранить Rus";
            this.cmbSaveRus.DisplayName = "Сохранить Rus";
            this.cmbSaveRus.DrawText = true;
            this.cmbSaveRus.Image = ((System.Drawing.Image)(resources.GetObject("cmbSaveRus.Image")));
            this.cmbSaveRus.Name = "cmbSaveRus";
            this.cmbSaveRus.Text = "Сохранить Rus";
            this.cmbSaveRus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmbSaveRus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbSaveRus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbSaveRus.Click += new System.EventHandler(this.cmbSaveRus_Click);
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
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "ID";
            gridViewTextBoxColumn6.Name = "columnID";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Имя файла";
            gridViewTextBoxColumn7.Name = "columnFileName";
            gridViewTextBoxColumn7.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn7.Width = 93;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "Теги";
            gridViewTextBoxColumn8.Name = "columnTags";
            gridViewTextBoxColumn8.Width = 117;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Русский";
            gridViewTextBoxColumn9.MaxLength = 100000;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "columnRussianPhrase";
            gridViewTextBoxColumn9.StretchVertically = false;
            gridViewTextBoxColumn9.Width = 300;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "Английский";
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "columnEnglishPhrase";
            gridViewTextBoxColumn10.Width = 300;
            this.gridViewTranslation.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.gridViewTranslation.MasterTemplate.EnableGrouping = false;
            this.gridViewTranslation.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            sortDescriptor2.PropertyName = "columnFileName";
            this.gridViewTranslation.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.gridViewTranslation.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.gridViewTranslation.Name = "gridViewTranslation";
            this.gridViewTranslation.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.gridViewTranslation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewTranslation.Size = new System.Drawing.Size(887, 589);
            this.gridViewTranslation.TabIndex = 2;
            this.gridViewTranslation.Text = "radGridView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 654);
            this.Controls.Add(this.gridViewTranslation);
            this.Controls.Add(this.commandBarTranslation);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Локализация интерфейса";
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
        private Telerik.WinControls.UI.CommandBarButton cmbShowUndoneData;
        private Telerik.WinControls.UI.CommandBarButton cmbSaveEng;
        private Telerik.WinControls.UI.CommandBarButton cmbSaveRus;
        private Telerik.WinControls.UI.CommandBarStripElement cmbStripMode;
        private Telerik.WinControls.UI.CommandBarLabel lMode;
    }
}

