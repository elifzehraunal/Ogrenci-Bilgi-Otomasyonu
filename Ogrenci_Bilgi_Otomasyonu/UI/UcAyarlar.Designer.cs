namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcAyarlar
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.scrollPanel = new DevExpress.XtraEditors.XtraScrollableControl();
            // Profil
            this.groupProfil = new DevExpress.XtraEditors.GroupControl();
            this.lblKullaniciAdiLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblRolLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblRol = new DevExpress.XtraEditors.LabelControl();
            this.lblSonGirisLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblSonGiris = new DevExpress.XtraEditors.LabelControl();
            // Şifre Değiştirme
            this.groupSifre = new DevExpress.XtraEditors.GroupControl();
            this.txtMevcutSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.btnSifreDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.lblMevcutSifre = new DevExpress.XtraEditors.LabelControl();
            this.lblYeniSifre = new DevExpress.XtraEditors.LabelControl();
            this.lblYeniSifreTekrar = new DevExpress.XtraEditors.LabelControl();
            // API
            this.groupApiSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnApiTest = new DevExpress.XtraEditors.SimpleButton();
            this.cmbApiProvider = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblApiProvider = new DevExpress.XtraEditors.LabelControl();
            this.txtApiKey = new DevExpress.XtraEditors.TextEdit();
            this.lblApiKey = new DevExpress.XtraEditors.LabelControl();
            // Genel
            this.groupGenel = new DevExpress.XtraEditors.GroupControl();
            this.chkBildirimGoster = new DevExpress.XtraEditors.CheckEdit();
            this.chkOtomatikYedekleme = new DevExpress.XtraEditors.CheckEdit();
            this.chkKaranlikTema = new DevExpress.XtraEditors.CheckEdit();
            this.chkOtomatikGuncelleme = new DevExpress.XtraEditors.CheckEdit();
            // Buttons
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupProfil)).BeginInit();
            this.groupProfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSifre)).BeginInit();
            this.groupSifre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMevcutSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupApiSettings)).BeginInit();
            this.groupApiSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbApiProvider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGenel)).BeginInit();
            this.groupGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBildirimGoster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatikYedekleme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKaranlikTema.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatikGuncelleme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBaslik.Text = "⚙️ AYARLAR";
            // 
            // scrollPanel
            // 
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 50);
            this.scrollPanel.Size = new System.Drawing.Size(900, 480);
            // ========== KULLANICI PROFİLİ ==========
            this.groupProfil.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupProfil.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.groupProfil.AppearanceCaption.Options.UseFont = true;
            this.groupProfil.AppearanceCaption.Options.UseForeColor = true;
            this.groupProfil.Location = new System.Drawing.Point(20, 15);
            this.groupProfil.Size = new System.Drawing.Size(400, 130);
            this.groupProfil.Text = "👤 Kullanıcı Profili";
            // Profil labels
            this.lblKullaniciAdiLabel.Location = new System.Drawing.Point(20, 40);
            this.lblKullaniciAdiLabel.Text = "Kullanıcı Adı:";
            this.lblKullaniciAdiLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullaniciAdi.Location = new System.Drawing.Point(130, 40);
            this.lblKullaniciAdi.Text = "-";
            this.lblKullaniciAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblRolLabel.Location = new System.Drawing.Point(20, 65);
            this.lblRolLabel.Text = "Rol:";
            this.lblRolLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRol.Location = new System.Drawing.Point(130, 65);
            this.lblRol.Text = "-";
            this.lblRol.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblSonGirisLabel.Location = new System.Drawing.Point(20, 90);
            this.lblSonGirisLabel.Text = "Son Giriş:";
            this.lblSonGirisLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSonGiris.Location = new System.Drawing.Point(130, 90);
            this.lblSonGiris.Text = "-";
            this.lblSonGiris.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.groupProfil.Controls.Add(this.lblKullaniciAdiLabel);
            this.groupProfil.Controls.Add(this.lblKullaniciAdi);
            this.groupProfil.Controls.Add(this.lblRolLabel);
            this.groupProfil.Controls.Add(this.lblRol);
            this.groupProfil.Controls.Add(this.lblSonGirisLabel);
            this.groupProfil.Controls.Add(this.lblSonGiris);
            // ========== ŞİFRE DEĞİŞTİRME ==========
            this.groupSifre.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupSifre.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.groupSifre.AppearanceCaption.Options.UseFont = true;
            this.groupSifre.AppearanceCaption.Options.UseForeColor = true;
            this.groupSifre.Location = new System.Drawing.Point(440, 15);
            this.groupSifre.Size = new System.Drawing.Size(420, 180);
            this.groupSifre.Text = "🔒 Şifre Değiştir";
            // Şifre kontrolleri
            this.lblMevcutSifre.Location = new System.Drawing.Point(20, 45); this.lblMevcutSifre.Text = "Mevcut Şifre:";
            this.lblMevcutSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMevcutSifre.Location = new System.Drawing.Point(140, 42); this.txtMevcutSifre.Size = new System.Drawing.Size(260, 24);
            this.txtMevcutSifre.Properties.PasswordChar = '*';
            this.lblYeniSifre.Location = new System.Drawing.Point(20, 80); this.lblYeniSifre.Text = "Yeni Şifre:";
            this.lblYeniSifre.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYeniSifre.Location = new System.Drawing.Point(140, 77); this.txtYeniSifre.Size = new System.Drawing.Size(260, 24);
            this.txtYeniSifre.Properties.PasswordChar = '*';
            this.lblYeniSifreTekrar.Location = new System.Drawing.Point(20, 115); this.lblYeniSifreTekrar.Text = "Şifre Tekrar:";
            this.lblYeniSifreTekrar.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(140, 112); this.txtYeniSifreTekrar.Size = new System.Drawing.Size(260, 24);
            this.txtYeniSifreTekrar.Properties.PasswordChar = '*';
            this.btnSifreDegistir.Appearance.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnSifreDegistir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSifreDegistir.Appearance.Options.UseBackColor = true;
            this.btnSifreDegistir.Appearance.Options.UseForeColor = true;
            this.btnSifreDegistir.Location = new System.Drawing.Point(140, 145);
            this.btnSifreDegistir.Size = new System.Drawing.Size(150, 30);
            this.btnSifreDegistir.Text = "🔐 Şifreyi Değiştir";
            this.btnSifreDegistir.Click += new System.EventHandler(this.btnSifreDegistir_Click);
            this.groupSifre.Controls.Add(this.lblMevcutSifre);
            this.groupSifre.Controls.Add(this.txtMevcutSifre);
            this.groupSifre.Controls.Add(this.lblYeniSifre);
            this.groupSifre.Controls.Add(this.txtYeniSifre);
            this.groupSifre.Controls.Add(this.lblYeniSifreTekrar);
            this.groupSifre.Controls.Add(this.txtYeniSifreTekrar);
            this.groupSifre.Controls.Add(this.btnSifreDegistir);
            // ========== API AYARLARI ==========
            this.groupApiSettings.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupApiSettings.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.groupApiSettings.AppearanceCaption.Options.UseFont = true;
            this.groupApiSettings.AppearanceCaption.Options.UseForeColor = true;
            this.groupApiSettings.Location = new System.Drawing.Point(20, 160);
            this.groupApiSettings.Size = new System.Drawing.Size(400, 190);
            this.groupApiSettings.Text = "🔑 API Ayarları";
            this.lblApiKey.Location = new System.Drawing.Point(20, 45); this.lblApiKey.Text = "API Anahtarı:";
            this.lblApiKey.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApiKey.Location = new System.Drawing.Point(120, 42); this.txtApiKey.Size = new System.Drawing.Size(260, 24);
            this.txtApiKey.Properties.PasswordChar = '*';
            this.lblApiProvider.Location = new System.Drawing.Point(20, 80); this.lblApiProvider.Text = "AI Sağlayıcı:";
            this.lblApiProvider.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbApiProvider.Location = new System.Drawing.Point(120, 77); this.cmbApiProvider.Size = new System.Drawing.Size(260, 24);
            this.cmbApiProvider.Properties.Items.AddRange(new object[] {
            "Google Gemini",
            "OpenAI ChatGPT",
            "xAI Grok"});
            this.cmbApiProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnApiTest.Appearance.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnApiTest.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnApiTest.Appearance.Options.UseBackColor = true;
            this.btnApiTest.Appearance.Options.UseForeColor = true;
            this.btnApiTest.Location = new System.Drawing.Point(120, 150);
            this.btnApiTest.Size = new System.Drawing.Size(150, 30);
            this.btnApiTest.Text = "🔗 Bağlantı Test";
            this.btnApiTest.Click += new System.EventHandler(this.btnApiTest_Click);
            this.groupApiSettings.Controls.Add(this.lblApiKey);
            this.groupApiSettings.Controls.Add(this.txtApiKey);
            this.groupApiSettings.Controls.Add(this.lblApiProvider);
            this.groupApiSettings.Controls.Add(this.cmbApiProvider);
            this.groupApiSettings.Controls.Add(this.btnApiTest);
            // ========== GENEL AYARLAR ==========
            this.groupGenel.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupGenel.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.groupGenel.AppearanceCaption.Options.UseFont = true;
            this.groupGenel.AppearanceCaption.Options.UseForeColor = true;
            this.groupGenel.Location = new System.Drawing.Point(440, 210);
            this.groupGenel.Size = new System.Drawing.Size(420, 140);
            this.groupGenel.Text = "📋 Genel Ayarlar";
            this.chkOtomatikYedekleme.Location = new System.Drawing.Point(20, 40);
            this.chkOtomatikYedekleme.Properties.Caption = "Otomatik Yedekleme";
            this.chkOtomatikYedekleme.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkOtomatikYedekleme.Size = new System.Drawing.Size(180, 22);
            this.chkBildirimGoster.EditValue = true;
            this.chkBildirimGoster.Location = new System.Drawing.Point(220, 40);
            this.chkBildirimGoster.Properties.Caption = "Bildirimleri Göster";
            this.chkBildirimGoster.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkBildirimGoster.Size = new System.Drawing.Size(180, 22);
            this.chkKaranlikTema.Location = new System.Drawing.Point(20, 75);
            this.chkKaranlikTema.Properties.Caption = "Karanlık Tema";
            this.chkKaranlikTema.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkKaranlikTema.Size = new System.Drawing.Size(180, 22);
            this.chkOtomatikGuncelleme.EditValue = true;
            this.chkOtomatikGuncelleme.Location = new System.Drawing.Point(220, 75);
            this.chkOtomatikGuncelleme.Properties.Caption = "Otomatik Güncelleme";
            this.chkOtomatikGuncelleme.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkOtomatikGuncelleme.Size = new System.Drawing.Size(180, 22);
            this.groupGenel.Controls.Add(this.chkOtomatikYedekleme);
            this.groupGenel.Controls.Add(this.chkBildirimGoster);
            this.groupGenel.Controls.Add(this.chkKaranlikTema);
            this.groupGenel.Controls.Add(this.chkOtomatikGuncelleme);
            // ========== SCROLL PANEL CONTROLS ==========
            this.scrollPanel.Controls.Add(this.groupProfil);
            this.scrollPanel.Controls.Add(this.groupSifre);
            this.scrollPanel.Controls.Add(this.groupApiSettings);
            this.scrollPanel.Controls.Add(this.groupGenel);
            // ========== BUTTONS ==========
            this.pnlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlButtons.Appearance.Options.UseBackColor = true;
            this.pnlButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlButtons.Controls.Add(this.btnTemizle);
            this.pnlButtons.Controls.Add(this.btnKaydet);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 530);
            this.pnlButtons.Size = new System.Drawing.Size(900, 70);
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(20, 15);
            this.btnKaydet.Size = new System.Drawing.Size(150, 40);
            this.btnKaydet.Text = "💾 Ayarları Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            this.btnTemizle.Appearance.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnTemizle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Appearance.Options.UseBackColor = true;
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Appearance.Options.UseForeColor = true;
            this.btnTemizle.Location = new System.Drawing.Point(180, 15);
            this.btnTemizle.Size = new System.Drawing.Size(150, 40);
            this.btnTemizle.Text = "🗑️ Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // UcAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcAyarlar";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupProfil)).EndInit();
            this.groupProfil.ResumeLayout(false);
            this.groupProfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSifre)).EndInit();
            this.groupSifre.ResumeLayout(false);
            this.groupSifre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMevcutSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupApiSettings)).EndInit();
            this.groupApiSettings.ResumeLayout(false);
            this.groupApiSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGenel)).EndInit();
            this.groupGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBildirimGoster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatikYedekleme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKaranlikTema.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtomatikGuncelleme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.XtraScrollableControl scrollPanel;
        // Profil
        private DevExpress.XtraEditors.GroupControl groupProfil;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdiLabel;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblRolLabel;
        private DevExpress.XtraEditors.LabelControl lblRol;
        private DevExpress.XtraEditors.LabelControl lblSonGirisLabel;
        private DevExpress.XtraEditors.LabelControl lblSonGiris;
        // Şifre
        private DevExpress.XtraEditors.GroupControl groupSifre;
        private DevExpress.XtraEditors.LabelControl lblMevcutSifre;
        private DevExpress.XtraEditors.TextEdit txtMevcutSifre;
        private DevExpress.XtraEditors.LabelControl lblYeniSifre;
        private DevExpress.XtraEditors.TextEdit txtYeniSifre;
        private DevExpress.XtraEditors.LabelControl lblYeniSifreTekrar;
        private DevExpress.XtraEditors.TextEdit txtYeniSifreTekrar;
        private DevExpress.XtraEditors.SimpleButton btnSifreDegistir;
        // API
        private DevExpress.XtraEditors.GroupControl groupApiSettings;
        private DevExpress.XtraEditors.SimpleButton btnApiTest;
        private DevExpress.XtraEditors.ComboBoxEdit cmbApiProvider;
        private DevExpress.XtraEditors.LabelControl lblApiProvider;
        private DevExpress.XtraEditors.TextEdit txtApiKey;
        private DevExpress.XtraEditors.LabelControl lblApiKey;
        // Genel
        private DevExpress.XtraEditors.GroupControl groupGenel;
        private DevExpress.XtraEditors.CheckEdit chkBildirimGoster;
        private DevExpress.XtraEditors.CheckEdit chkOtomatikYedekleme;
        private DevExpress.XtraEditors.CheckEdit chkKaranlikTema;
        private DevExpress.XtraEditors.CheckEdit chkOtomatikGuncelleme;
        // Buttons
        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
