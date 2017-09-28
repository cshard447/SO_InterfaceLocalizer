namespace InterfaceLocalizer.GUI
{
    partial class StatisticsForm
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
            this.lStats = new Telerik.WinControls.UI.RadLabel();
            this.rbTotal = new Telerik.WinControls.UI.RadRadioButton();
            this.rbChecked = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(151, 356);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 24);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "ОК";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lStats
            // 
            this.lStats.Location = new System.Drawing.Point(41, 40);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(33, 18);
            this.lStats.TabIndex = 1;
            this.lStats.Text = "lStats";
            // 
            // rbTotal
            // 
            this.rbTotal.Location = new System.Drawing.Point(56, 329);
            this.rbTotal.Name = "rbTotal";
            this.rbTotal.Size = new System.Drawing.Size(59, 18);
            this.rbTotal.TabIndex = 2;
            this.rbTotal.Text = "Полная";
            this.rbTotal.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbTotal_ToggleStateChanged);
            // 
            // rbChecked
            // 
            this.rbChecked.Location = new System.Drawing.Point(232, 329);
            this.rbChecked.Name = "rbChecked";
            this.rbChecked.Size = new System.Drawing.Size(118, 18);
            this.rbChecked.TabIndex = 3;
            this.rbChecked.Text = "Выбранные файлы";
            this.rbChecked.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbChecked_ToggleStateChanged);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 407);
            this.Controls.Add(this.rbChecked);
            this.Controls.Add(this.rbTotal);
            this.Controls.Add(this.lStats);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Статистика";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StatisticsForm_FormClosed);
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadLabel lStats;
        private Telerik.WinControls.UI.RadRadioButton rbTotal;
        private Telerik.WinControls.UI.RadRadioButton rbChecked;
    }
}
