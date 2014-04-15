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
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStats)).BeginInit();
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
            this.lStats.Size = new System.Drawing.Size(55, 18);
            this.lStats.TabIndex = 1;
            this.lStats.Text = "radLabel1";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 407);
            this.Controls.Add(this.lStats);
            this.Controls.Add(this.bOK);
            this.Name = "StatisticsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Статистика";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton bOK;
        private Telerik.WinControls.UI.RadLabel lStats;
    }
}
