namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcOrtalamaHesapla
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.groupOrtalama = new DevExpress.XtraEditors.GroupControl();
            this.lblOrtalamaLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblOrtalama = new DevExpress.XtraEditors.LabelControl();
            this.lblDersSayisiLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblDersSayisi = new DevExpress.XtraEditors.LabelControl();
            this.progressOrtalama = new DevExpress.XtraEditors.ProgressBarControl();
            this.groupDurum = new DevExpress.XtraEditors.GroupControl();
            this.lblDurum = new DevExpress.XtraEditors.LabelControl();
            this.groupNotlar = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupOrtalama)).BeginInit();
            this.groupOrtalama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressOrtalama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDurum)).BeginInit();
            this.groupDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupNotlar)).BeginInit();
            this.groupNotlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBaslik.Text = "📊 ORTALAMA HESAPLAMA - TAKDİR / TEŞEKKÜR";
            // 
            // groupOrtalama
            // 
            this.groupOrtalama.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupOrtalama.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.groupOrtalama.AppearanceCaption.Options.UseFont = true;
            this.groupOrtalama.AppearanceCaption.Options.UseForeColor = true;
            this.groupOrtalama.Controls.Add(this.lblOrtalamaLabel);
            this.groupOrtalama.Controls.Add(this.lblOrtalama);
            this.groupOrtalama.Controls.Add(this.lblDersSayisiLabel);
            this.groupOrtalama.Controls.Add(this.lblDersSayisi);
            this.groupOrtalama.Controls.Add(this.progressOrtalama);
            this.groupOrtalama.Location = new System.Drawing.Point(20, 70);
            this.groupOrtalama.Name = "groupOrtalama";
            this.groupOrtalama.Size = new System.Drawing.Size(350, 180);
            this.groupOrtalama.Text = "📈 Genel Ortalama";
            // 
            // lblOrtalamaLabel
            // 
            this.lblOrtalamaLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOrtalamaLabel.Location = new System.Drawing.Point(20, 45);
            this.lblOrtalamaLabel.Text = "Genel Ortalama:";
            // 
            // lblOrtalama
            // 
            this.lblOrtalama.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblOrtalama.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblOrtalama.Appearance.Options.UseFont = true;
            this.lblOrtalama.Appearance.Options.UseForeColor = true;
            this.lblOrtalama.Location = new System.Drawing.Point(160, 35);
            this.lblOrtalama.Text = "0.00";
            // 
            // lblDersSayisiLabel
            // 
            this.lblDersSayisiLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDersSayisiLabel.Location = new System.Drawing.Point(20, 90);
            this.lblDersSayisiLabel.Text = "Toplam Ders Sayısı:";
            // 
            // lblDersSayisi
            // 
            this.lblDersSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblDersSayisi.Appearance.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblDersSayisi.Appearance.Options.UseFont = true;
            this.lblDersSayisi.Appearance.Options.UseForeColor = true;
            this.lblDersSayisi.Location = new System.Drawing.Point(160, 88);
            this.lblDersSayisi.Text = "0";
            // 
            // progressOrtalama
            // 
            this.progressOrtalama.Location = new System.Drawing.Point(20, 130);
            this.progressOrtalama.Name = "progressOrtalama";
            this.progressOrtalama.Properties.ShowTitle = true;
            this.progressOrtalama.Size = new System.Drawing.Size(310, 30);
            // 
            // groupDurum
            // 
            this.groupDurum.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupDurum.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.groupDurum.AppearanceCaption.Options.UseFont = true;
            this.groupDurum.AppearanceCaption.Options.UseForeColor = true;
            this.groupDurum.Controls.Add(this.lblDurum);
            this.groupDurum.Controls.Add(this.btnYenile);
            this.groupDurum.Location = new System.Drawing.Point(390, 70);
            this.groupDurum.Name = "groupDurum";
            this.groupDurum.Size = new System.Drawing.Size(350, 180);
            this.groupDurum.Text = "🎯 Başarı Durumu";
            // 
            // lblDurum
            // 
            this.lblDurum.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDurum.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblDurum.Appearance.Options.UseFont = true;
            this.lblDurum.Appearance.Options.UseForeColor = true;
            this.lblDurum.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDurum.Location = new System.Drawing.Point(20, 50);
            this.lblDurum.Size = new System.Drawing.Size(310, 60);
            this.lblDurum.Text = "-";
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnYenile.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Appearance.Options.UseBackColor = true;
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Appearance.Options.UseForeColor = true;
            this.btnYenile.Location = new System.Drawing.Point(20, 130);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(150, 35);
            this.btnYenile.Text = "🔄 Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // groupNotlar
            // 
            this.groupNotlar.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.groupNotlar.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.groupNotlar.AppearanceCaption.Options.UseFont = true;
            this.groupNotlar.AppearanceCaption.Options.UseForeColor = true;
            this.groupNotlar.Controls.Add(this.gridControl);
            this.groupNotlar.Location = new System.Drawing.Point(20, 270);
            this.groupNotlar.Name = "groupNotlar";
            this.groupNotlar.Size = new System.Drawing.Size(720, 280);
            this.groupNotlar.Text = "📋 Ders Notlarım";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 23);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(716, 255);
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // UcOrtalamaHesapla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.groupNotlar);
            this.Controls.Add(this.groupDurum);
            this.Controls.Add(this.groupOrtalama);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcOrtalamaHesapla";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupOrtalama)).EndInit();
            this.groupOrtalama.ResumeLayout(false);
            this.groupOrtalama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressOrtalama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDurum)).EndInit();
            this.groupDurum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupNotlar)).EndInit();
            this.groupNotlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.GroupControl groupOrtalama;
        private DevExpress.XtraEditors.LabelControl lblOrtalamaLabel;
        private DevExpress.XtraEditors.LabelControl lblOrtalama;
        private DevExpress.XtraEditors.LabelControl lblDersSayisiLabel;
        private DevExpress.XtraEditors.LabelControl lblDersSayisi;
        private DevExpress.XtraEditors.ProgressBarControl progressOrtalama;
        private DevExpress.XtraEditors.GroupControl groupDurum;
        private DevExpress.XtraEditors.LabelControl lblDurum;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.GroupControl groupNotlar;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
    }
}
