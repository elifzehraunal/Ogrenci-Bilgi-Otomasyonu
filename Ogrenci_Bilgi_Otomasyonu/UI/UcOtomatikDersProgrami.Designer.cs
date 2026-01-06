namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcOtomatikDersProgrami
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.groupIstatistik = new DevExpress.XtraEditors.GroupControl();
            this.lblSinifSayisiLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblSinifSayisi = new DevExpress.XtraEditors.LabelControl();
            this.lblDersSayisiLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblDersSayisi = new DevExpress.XtraEditors.LabelControl();
            this.lblOgretmenSayisiLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblOgretmenSayisi = new DevExpress.XtraEditors.LabelControl();
            this.groupAksiyonlar = new DevExpress.XtraEditors.GroupControl();
            this.btnOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnayla = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenidenOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.lblApiDurum = new DevExpress.XtraEditors.LabelControl();
            this.pnlDurum = new DevExpress.XtraEditors.PanelControl();
            this.lblDurum = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.tabSiniflar = new System.Windows.Forms.TabControl();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupIstatistik)).BeginInit();
            this.groupIstatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAksiyonlar)).BeginInit();
            this.groupAksiyonlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDurum)).BeginInit();
            this.pnlDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(950, 50);
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBaslik.Text = "🤖 OTOMATİK DERS PROGRAMI OLUŞTURUCU";
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.groupIstatistik);
            this.pnlTop.Controls.Add(this.groupAksiyonlar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 50);
            this.pnlTop.Size = new System.Drawing.Size(950, 110);
            // 
            // groupIstatistik
            // 
            this.groupIstatistik.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.groupIstatistik.Location = new System.Drawing.Point(10, 5);
            this.groupIstatistik.Size = new System.Drawing.Size(300, 100);
            this.groupIstatistik.Text = "📊 Okul Verileri";
            this.lblSinifSayisiLabel.Location = new System.Drawing.Point(15, 35);
            this.lblSinifSayisiLabel.Text = "Sınıf Sayısı:";
            this.lblSinifSayisiLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSinifSayisi.Location = new System.Drawing.Point(100, 35);
            this.lblSinifSayisi.Text = "0";
            this.lblSinifSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDersSayisiLabel.Location = new System.Drawing.Point(15, 55);
            this.lblDersSayisiLabel.Text = "Ders Sayısı:";
            this.lblDersSayisiLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDersSayisi.Location = new System.Drawing.Point(100, 55);
            this.lblDersSayisi.Text = "0";
            this.lblDersSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblOgretmenSayisiLabel.Location = new System.Drawing.Point(15, 75);
            this.lblOgretmenSayisiLabel.Text = "Öğretmen:";
            this.lblOgretmenSayisiLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOgretmenSayisi.Location = new System.Drawing.Point(100, 75);
            this.lblOgretmenSayisi.Text = "0";
            this.lblOgretmenSayisi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.groupIstatistik.Controls.Add(this.lblSinifSayisiLabel);
            this.groupIstatistik.Controls.Add(this.lblSinifSayisi);
            this.groupIstatistik.Controls.Add(this.lblDersSayisiLabel);
            this.groupIstatistik.Controls.Add(this.lblDersSayisi);
            this.groupIstatistik.Controls.Add(this.lblOgretmenSayisiLabel);
            this.groupIstatistik.Controls.Add(this.lblOgretmenSayisi);
            // 
            // groupAksiyonlar
            // 
            this.groupAksiyonlar.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.groupAksiyonlar.Location = new System.Drawing.Point(320, 5);
            this.groupAksiyonlar.Size = new System.Drawing.Size(620, 100);
            this.groupAksiyonlar.Text = "⚡ Aksiyonlar";
            // btnOlustur
            this.btnOlustur.Appearance.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.btnOlustur.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnOlustur.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOlustur.Appearance.Options.UseBackColor = true;
            this.btnOlustur.Appearance.Options.UseFont = true;
            this.btnOlustur.Appearance.Options.UseForeColor = true;
            this.btnOlustur.Location = new System.Drawing.Point(15, 35);
            this.btnOlustur.Size = new System.Drawing.Size(160, 40);
            this.btnOlustur.Text = "🤖 Otomatik Oluştur";
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // btnOnayla
            this.btnOnayla.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnOnayla.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnOnayla.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOnayla.Appearance.Options.UseBackColor = true;
            this.btnOnayla.Appearance.Options.UseFont = true;
            this.btnOnayla.Appearance.Options.UseForeColor = true;
            this.btnOnayla.Location = new System.Drawing.Point(185, 35);
            this.btnOnayla.Size = new System.Drawing.Size(160, 40);
            this.btnOnayla.Text = "✅ Onayla ve Kaydet";
            this.btnOnayla.Enabled = false;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // btnYenidenOlustur
            this.btnYenidenOlustur.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnYenidenOlustur.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnYenidenOlustur.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYenidenOlustur.Appearance.Options.UseBackColor = true;
            this.btnYenidenOlustur.Appearance.Options.UseFont = true;
            this.btnYenidenOlustur.Appearance.Options.UseForeColor = true;
            this.btnYenidenOlustur.Location = new System.Drawing.Point(355, 35);
            this.btnYenidenOlustur.Size = new System.Drawing.Size(140, 40);
            this.btnYenidenOlustur.Text = "🔄 Yeniden Oluştur";
            this.btnYenidenOlustur.Enabled = false;
            this.btnYenidenOlustur.Click += new System.EventHandler(this.btnYenidenOlustur_Click);
            // lblApiDurum
            this.lblApiDurum.Location = new System.Drawing.Point(15, 80);
            this.lblApiDurum.Text = "API: Bekleniyor...";
            this.lblApiDurum.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblApiDurum.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.groupAksiyonlar.Controls.Add(this.btnOlustur);
            this.groupAksiyonlar.Controls.Add(this.btnOnayla);
            this.groupAksiyonlar.Controls.Add(this.btnYenidenOlustur);
            this.groupAksiyonlar.Controls.Add(this.lblApiDurum);
            // 
            // pnlDurum
            // 
            this.pnlDurum.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDurum.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDurum.Location = new System.Drawing.Point(0, 160);
            this.pnlDurum.Size = new System.Drawing.Size(950, 35);
            this.pnlDurum.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.pnlDurum.Appearance.Options.UseBackColor = true;
            this.lblDurum.Location = new System.Drawing.Point(15, 8);
            this.lblDurum.Text = "Hazır";
            this.lblDurum.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.progressBar.Location = new System.Drawing.Point(800, 5);
            this.progressBar.Size = new System.Drawing.Size(140, 25);
            this.progressBar.Visible = false;
            this.progressBar.Properties.ShowTitle = true;
            this.pnlDurum.Controls.Add(this.lblDurum);
            this.pnlDurum.Controls.Add(this.progressBar);
            // 
            // tabSiniflar
            // 
            this.tabSiniflar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSiniflar.Location = new System.Drawing.Point(0, 195);
            this.tabSiniflar.Size = new System.Drawing.Size(950, 405);
            this.tabSiniflar.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // UcOtomatikDersProgrami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabSiniflar);
            this.Controls.Add(this.pnlDurum);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcOtomatikDersProgrami";
            this.Size = new System.Drawing.Size(950, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupIstatistik)).EndInit();
            this.groupIstatistik.ResumeLayout(false);
            this.groupIstatistik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAksiyonlar)).EndInit();
            this.groupAksiyonlar.ResumeLayout(false);
            this.groupAksiyonlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDurum)).EndInit();
            this.pnlDurum.ResumeLayout(false);
            this.pnlDurum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.GroupControl groupIstatistik;
        private DevExpress.XtraEditors.LabelControl lblSinifSayisiLabel;
        private DevExpress.XtraEditors.LabelControl lblSinifSayisi;
        private DevExpress.XtraEditors.LabelControl lblDersSayisiLabel;
        private DevExpress.XtraEditors.LabelControl lblDersSayisi;
        private DevExpress.XtraEditors.LabelControl lblOgretmenSayisiLabel;
        private DevExpress.XtraEditors.LabelControl lblOgretmenSayisi;
        private DevExpress.XtraEditors.GroupControl groupAksiyonlar;
        private DevExpress.XtraEditors.SimpleButton btnOlustur;
        private DevExpress.XtraEditors.SimpleButton btnOnayla;
        private DevExpress.XtraEditors.SimpleButton btnYenidenOlustur;
        private DevExpress.XtraEditors.LabelControl lblApiDurum;
        private DevExpress.XtraEditors.PanelControl pnlDurum;
        private DevExpress.XtraEditors.LabelControl lblDurum;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private System.Windows.Forms.TabControl tabSiniflar;
    }
}
