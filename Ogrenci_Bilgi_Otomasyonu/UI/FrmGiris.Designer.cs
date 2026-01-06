using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class FrmGiris
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlLogin = new DevExpress.XtraEditors.PanelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.chkBeniHatirla = new DevExpress.XtraEditors.CheckEdit();
            this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).BeginInit();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // pnlMain - Gradient Arka Plan
            // 
            this.pnlMain.Appearance.BackColor = Color.FromArgb(108, 99, 255);
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.pnlLogin);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(600, 500);
            
            // 
            // pnlLogin - Glassmorphism Login Card
            // 
            this.pnlLogin.Appearance.BackColor = Color.FromArgb(240, 255, 255, 255);
            this.pnlLogin.Appearance.Options.UseBackColor = true;
            this.pnlLogin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlLogin.Controls.Add(this.btnCikis);
            this.pnlLogin.Controls.Add(this.btnGiris);
            this.pnlLogin.Controls.Add(this.chkBeniHatirla);
            this.pnlLogin.Controls.Add(this.txtSifre);
            this.pnlLogin.Controls.Add(this.lblSifre);
            this.pnlLogin.Controls.Add(this.txtKullaniciAdi);
            this.pnlLogin.Controls.Add(this.lblKullaniciAdi);
            this.pnlLogin.Controls.Add(this.picLogo);
            this.pnlLogin.Controls.Add(this.lblBaslik);
            this.pnlLogin.Controls.Add(this.lblAltBaslik);
            this.pnlLogin.Location = new Point(100, 60);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new Size(400, 380);
            
            // 
            // picLogo - Öğrenci Bilgi Sistemi Logosu
            // 
            this.picLogo.Location = new Point(160, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(80, 80);
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
            this.picLogo.Properties.ShowMenu = false;
            
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = Color.FromArgb(108, 99, 255);
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new Point(20, 105);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new Size(360, 35);
            this.lblBaslik.Text = "🎓 Öğrenci Bilgi Sistemi";
            
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.Appearance.Font = new Font("Segoe UI", 10F);
            this.lblAltBaslik.Appearance.ForeColor = Color.Gray;
            this.lblAltBaslik.Appearance.Options.UseFont = true;
            this.lblAltBaslik.Appearance.Options.UseForeColor = true;
            this.lblAltBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAltBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAltBaslik.Location = new Point(20, 135);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new Size(360, 20);
            this.lblAltBaslik.Text = "Hesabınıza giriş yapın";
            
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Appearance.Font = new Font("Segoe UI Semibold", 10F);
            this.lblKullaniciAdi.Appearance.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblKullaniciAdi.Appearance.Options.UseFont = true;
            this.lblKullaniciAdi.Appearance.Options.UseForeColor = true;
            this.lblKullaniciAdi.Location = new Point(40, 170);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Text = "🆔 TC / Kullanıcı Adı";
            
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new Point(40, 195);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtKullaniciAdi.Size = new Size(320, 28);
            this.txtKullaniciAdi.TabIndex = 1;
            
            // 
            // lblSifre
            // 
            this.lblSifre.Appearance.Font = new Font("Segoe UI Semibold", 10F);
            this.lblSifre.Appearance.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblSifre.Appearance.Options.UseFont = true;
            this.lblSifre.Appearance.Options.UseForeColor = true;
            this.lblSifre.Location = new Point(40, 235);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Text = "🔒 Şifre";
            
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new Point(40, 260);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSifre.Properties.PasswordChar = '●';
            this.txtSifre.Size = new Size(320, 28);
            this.txtSifre.TabIndex = 2;
            
            // 
            // chkBeniHatirla
            // 
            this.chkBeniHatirla.Location = new Point(40, 300);
            this.chkBeniHatirla.Name = "chkBeniHatirla";
            this.chkBeniHatirla.Properties.Caption = "Beni Hatırla";
            this.chkBeniHatirla.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            this.chkBeniHatirla.Properties.Appearance.Options.UseFont = true;
            this.chkBeniHatirla.Size = new Size(120, 20);
            this.chkBeniHatirla.TabIndex = 3;
            
            // 
            // btnGiris - Modern Gradient Button
            // 
            this.btnGiris.Appearance.BackColor = Color.FromArgb(108, 99, 255);
            this.btnGiris.Appearance.BackColor2 = Color.FromArgb(156, 39, 176);
            this.btnGiris.Appearance.Font = new Font("Segoe UI Semibold", 12F);
            this.btnGiris.Appearance.ForeColor = Color.White;
            this.btnGiris.Appearance.Options.UseBackColor = true;
            this.btnGiris.Appearance.Options.UseFont = true;
            this.btnGiris.Appearance.Options.UseForeColor = true;
            this.btnGiris.AppearanceHovered.BackColor = Color.FromArgb(130, 120, 255);
            this.btnGiris.AppearanceHovered.Options.UseBackColor = true;
            this.btnGiris.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGiris.Location = new Point(40, 330);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new Size(155, 40);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "🚀 Giriş Yap";
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            
            // 
            // btnCikis
            // 
            this.btnCikis.Appearance.BackColor = Color.FromArgb(200, 200, 200);
            this.btnCikis.Appearance.Font = new Font("Segoe UI", 11F);
            this.btnCikis.Appearance.ForeColor = Color.FromArgb(80, 80, 80);
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCikis.Location = new Point(205, 330);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new Size(155, 40);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "❌ Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.Font = new Font("Segoe UI", 9F);
            this.lblVersion.Appearance.ForeColor = Color.FromArgb(200, 255, 255, 255);
            this.lblVersion.Appearance.Options.UseFont = true;
            this.lblVersion.Appearance.Options.UseForeColor = true;
            this.lblVersion.Location = new Point(245, 465);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Text = "v1.0.0 | © 2024";
            
            // 
            // FrmGiris
            // 
            this.AcceptButton = this.btnGiris;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(600, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş - Öğrenci Bilgi Sistemi";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmGiris_Paint);
            
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLogin)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeniHatirla.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlLogin;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblSifre;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.CheckEdit chkBeniHatirla;
        private DevExpress.XtraEditors.SimpleButton btnGiris;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraEditors.LabelControl lblVersion;
    }
}
