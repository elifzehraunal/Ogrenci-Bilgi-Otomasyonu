namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcDersProgrami
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.pnlFiltre = new DevExpress.XtraEditors.PanelControl();
            this.lueSinifFiltre = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFiltre = new DevExpress.XtraEditors.LabelControl();
            this.pnlSchedule = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltre)).BeginInit();
            this.pnlFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSinifFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBaslik.Size = new System.Drawing.Size(900, 60);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "📅 HAFTALIK DERS PROGRAMI";
            // 
            // pnlFiltre
            // 
            this.pnlFiltre.Appearance.BackColor = System.Drawing.Color.FromArgb(232, 234, 246);
            this.pnlFiltre.Appearance.Options.UseBackColor = true;
            this.pnlFiltre.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFiltre.Controls.Add(this.lueSinifFiltre);
            this.pnlFiltre.Controls.Add(this.lblFiltre);
            this.pnlFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltre.Location = new System.Drawing.Point(0, 60);
            this.pnlFiltre.Name = "pnlFiltre";
            this.pnlFiltre.Size = new System.Drawing.Size(900, 45);
            this.pnlFiltre.TabIndex = 1;
            // 
            // lblFiltre
            // 
            this.lblFiltre.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblFiltre.Appearance.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.lblFiltre.Appearance.Options.UseFont = true;
            this.lblFiltre.Appearance.Options.UseForeColor = true;
            this.lblFiltre.Location = new System.Drawing.Point(15, 13);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(70, 19);
            this.lblFiltre.TabIndex = 0;
            this.lblFiltre.Text = "🏫 Sınıf Seçin:";
            // 
            // lueSinifFiltre
            // 
            this.lueSinifFiltre.Location = new System.Drawing.Point(120, 11);
            this.lueSinifFiltre.Name = "lueSinifFiltre";
            this.lueSinifFiltre.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lueSinifFiltre.Properties.Appearance.Options.UseFont = true;
            this.lueSinifFiltre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSinifFiltre.Properties.NullText = "-- Sınıf Seçiniz --";
            this.lueSinifFiltre.Size = new System.Drawing.Size(220, 24);
            this.lueSinifFiltre.TabIndex = 1;
            this.lueSinifFiltre.EditValueChanged += new System.EventHandler(this.lueSinifFiltre_EditValueChanged);
            // 
            // pnlSchedule
            // 
            this.pnlSchedule.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSchedule.Appearance.Options.UseBackColor = true;
            this.pnlSchedule.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSchedule.Location = new System.Drawing.Point(0, 105);
            this.pnlSchedule.Name = "pnlSchedule";
            this.pnlSchedule.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSchedule.Size = new System.Drawing.Size(900, 495);
            this.pnlSchedule.TabIndex = 2;
            // 
            // UcDersProgrami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSchedule);
            this.Controls.Add(this.pnlFiltre);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcDersProgrami";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltre)).EndInit();
            this.pnlFiltre.ResumeLayout(false);
            this.pnlFiltre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSinifFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSchedule)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.PanelControl pnlFiltre;
        private DevExpress.XtraEditors.LookUpEdit lueSinifFiltre;
        private DevExpress.XtraEditors.LabelControl lblFiltre;
        private DevExpress.XtraEditors.PanelControl pnlSchedule;
    }
}
