﻿namespace InterfaceLocalizer
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.mainMenu = new Telerik.WinControls.UI.RadMenu();
            this.menuItemMain = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemStatistics = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarTranslation = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmbShowData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbShowUndoneData = new Telerik.WinControls.UI.CommandBarButton();
            this.cmbColumnsHide = new Telerik.WinControls.UI.CommandBarButton();
            this.cmlListedItems = new Telerik.WinControls.UI.CommandBarLabel();
            this.gridViewTranslation = new Telerik.WinControls.UI.RadGridView();
            this.cmbSaveChecked = new Telerik.WinControls.UI.CommandBarButton();
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
            this.mainMenu.Size = new System.Drawing.Size(823, 20);
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
            this.commandBarRowElement1});
            this.commandBarTranslation.Size = new System.Drawing.Size(823, 70);
            this.commandBarTranslation.TabIndex = 1;
            this.commandBarTranslation.Text = "radCommandBar1";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement});
            // 
            // commandBarStripElement
            // 
            this.commandBarStripElement.DisplayName = "Полоса управления";
            this.commandBarStripElement.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmbShowData,
            this.cmbShowUndoneData,
            this.cmbColumnsHide,
            this.cmlListedItems,
            this.cmbSaveChecked});
            this.commandBarStripElement.Name = "commandBarStripElement1";
            // 
            // cmbShowData
            // 
            this.cmbShowData.AccessibleDescription = "Показать данные";
            this.cmbShowData.AccessibleName = "Показать данные";
            this.cmbShowData.DisplayName = "Показать данные";
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
            this.cmbShowUndoneData.DisplayName = "commandBarButton1";
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
            // gridViewTranslation
            // 
            this.gridViewTranslation.BackColor = System.Drawing.SystemColors.Control;
            this.gridViewTranslation.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTranslation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewTranslation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridViewTranslation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewTranslation.Location = new System.Drawing.Point(0, 90);
            // 
            // gridViewTranslation
            // 
            this.gridViewTranslation.MasterTemplate.AllowAddNewRow = false;
            this.gridViewTranslation.MasterTemplate.AllowColumnReorder = false;
            this.gridViewTranslation.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Имя файла";
            gridViewTextBoxColumn9.Name = "columnFileName";
            gridViewTextBoxColumn9.Width = 93;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "Теги";
            gridViewTextBoxColumn10.Name = "columnTags";
            gridViewTextBoxColumn10.Width = 117;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "Русский";
            gridViewTextBoxColumn11.Name = "columnRussianPhrase";
            gridViewTextBoxColumn11.Width = 312;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "Английский";
            gridViewTextBoxColumn12.Name = "columnEnglishPhrase";
            gridViewTextBoxColumn12.Width = 238;
            this.gridViewTranslation.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.gridViewTranslation.MasterTemplate.EnableGrouping = false;
            this.gridViewTranslation.Name = "gridViewTranslation";
            this.gridViewTranslation.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.gridViewTranslation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewTranslation.Size = new System.Drawing.Size(823, 564);
            this.gridViewTranslation.TabIndex = 2;
            this.gridViewTranslation.Text = "radGridView1";
            // 
            // cmbSaveChecked
            // 
            this.cmbSaveChecked.AccessibleDescription = "Сохранить";
            this.cmbSaveChecked.AccessibleName = "Сохранить";
            this.cmbSaveChecked.DisplayName = "Сохранить данные";
            this.cmbSaveChecked.DrawText = true;
            this.cmbSaveChecked.Image = ((System.Drawing.Image)(resources.GetObject("cmbSaveChecked.Image")));
            this.cmbSaveChecked.Name = "cmbSaveChecked";
            this.cmbSaveChecked.Text = "Сохранить";
            this.cmbSaveChecked.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmbSaveChecked.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmbSaveChecked.Click += new System.EventHandler(this.cmbSaveChecked_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 654);
            this.Controls.Add(this.gridViewTranslation);
            this.Controls.Add(this.commandBarTranslation);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "Локализация интерфейса";
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
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement;
        private Telerik.WinControls.UI.RadGridView gridViewTranslation;
        private Telerik.WinControls.UI.CommandBarButton cmbShowData;
        private Telerik.WinControls.UI.CommandBarButton cmbColumnsHide;
        private Telerik.WinControls.UI.RadMenuItem menuItemStatistics;
        private Telerik.WinControls.UI.CommandBarLabel cmlListedItems;
        private Telerik.WinControls.UI.CommandBarButton cmbShowUndoneData;
        private Telerik.WinControls.UI.CommandBarButton cmbSaveChecked;
    }
}

