using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class FrmAnaModul
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
            this.pnlSidebar = new DevExpress.XtraEditors.PanelControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.lblLogo = new DevExpress.XtraEditors.LabelControl();
            this.lblKullanici = new DevExpress.XtraEditors.LabelControl();
            this.btnOgrenciListesi = new DevExpress.XtraEditors.SimpleButton();
            this.btnOgretmenListesi = new DevExpress.XtraEditors.SimpleButton();
            this.btnDersListesi = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.btnDersProgrami = new DevExpress.XtraEditors.SimpleButton();
            this.btnOtomatikProgram = new DevExpress.XtraEditors.SimpleButton();
            this.btnOrtalamaHesapla = new DevExpress.XtraEditors.SimpleButton();
            this.btnAyarlar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            this.SuspendLayout();
            
            // 
            // pnlSidebar - Sol Menü Paneli
            // 
            this.pnlSidebar.Appearance.BackColor = Color.FromArgb(108, 99, 255);
            this.pnlSidebar.Appearance.Options.UseBackColor = true;
            this.pnlSidebar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Controls.Add(this.btnOgrenciListesi);
            this.pnlSidebar.Controls.Add(this.btnOgretmenListesi);
            this.pnlSidebar.Controls.Add(this.btnDersListesi);
            this.pnlSidebar.Controls.Add(this.btnNotGirisi);
            this.pnlSidebar.Controls.Add(this.btnDersProgrami);
            this.pnlSidebar.Controls.Add(this.btnOtomatikProgram);
            this.pnlSidebar.Controls.Add(this.btnOrtalamaHesapla);
            this.pnlSidebar.Controls.Add(this.btnAyarlar);
            this.pnlSidebar.Controls.Add(this.btnCikis);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new Size(220, 700);
            
            // 
            // picLogo
            // 
            this.picLogo.Location = new Point(70, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(80, 80);
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
            this.picLogo.Properties.ShowMenu = false;
            this.picLogo.Properties.AllowFocused = false;
            this.picLogo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.EditValue = global::Ogrenci_Bilgi_Otomasyonu.Properties.Resources.logo;
            
            // 
            // lblLogo
            // 
            this.lblLogo.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblLogo.Appearance.ForeColor = Color.White;
            this.lblLogo.Appearance.Options.UseFont = true;
            this.lblLogo.Appearance.Options.UseForeColor = true;
            this.lblLogo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLogo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLogo.Location = new Point(10, 100);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new Size(200, 25);
            this.lblLogo.Text = "🎓 Öğrenci Bilgi Sistemi";
            
            // 
            // btnOgrenciListesi
            // 
            this.btnOgrenciListesi.Appearance.BackColor = Color.Transparent;
            this.btnOgrenciListesi.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnOgrenciListesi.Appearance.ForeColor = Color.White;
            this.btnOgrenciListesi.Appearance.Options.UseBackColor = true;
            this.btnOgrenciListesi.Appearance.Options.UseFont = true;
            this.btnOgrenciListesi.Appearance.Options.UseForeColor = true;
            this.btnOgrenciListesi.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnOgrenciListesi.AppearanceHovered.ForeColor = Color.White;
            this.btnOgrenciListesi.AppearanceHovered.Options.UseBackColor = true;
            this.btnOgrenciListesi.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnOgrenciListesi.AppearancePressed.Options.UseBackColor = true;
            this.btnOgrenciListesi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOgrenciListesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgrenciListesi.Location = new Point(10, 145);
            this.btnOgrenciListesi.Name = "btnOgrenciListesi";
            this.btnOgrenciListesi.Size = new Size(200, 45);
            this.btnOgrenciListesi.Text = "  🎓  Öğrenciler";
            this.btnOgrenciListesi.Click += new System.EventHandler(this.btnOgrenciListesi_ItemClick);
            
            // 
            // btnOgretmenListesi
            // 
            this.btnOgretmenListesi.Appearance.BackColor = Color.Transparent;
            this.btnOgretmenListesi.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnOgretmenListesi.Appearance.ForeColor = Color.White;
            this.btnOgretmenListesi.Appearance.Options.UseBackColor = true;
            this.btnOgretmenListesi.Appearance.Options.UseFont = true;
            this.btnOgretmenListesi.Appearance.Options.UseForeColor = true;
            this.btnOgretmenListesi.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnOgretmenListesi.AppearanceHovered.ForeColor = Color.White;
            this.btnOgretmenListesi.AppearanceHovered.Options.UseBackColor = true;
            this.btnOgretmenListesi.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnOgretmenListesi.AppearancePressed.Options.UseBackColor = true;
            this.btnOgretmenListesi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOgretmenListesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgretmenListesi.Location = new Point(10, 195);
            this.btnOgretmenListesi.Name = "btnOgretmenListesi";
            this.btnOgretmenListesi.Size = new Size(200, 45);
            this.btnOgretmenListesi.Text = "  👨‍🏫  Öğretmenler";
            this.btnOgretmenListesi.Click += new System.EventHandler(this.btnOgretmenListesi_ItemClick);
            
            // 
            // btnDersListesi
            // 
            this.btnDersListesi.Appearance.BackColor = Color.Transparent;
            this.btnDersListesi.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnDersListesi.Appearance.ForeColor = Color.White;
            this.btnDersListesi.Appearance.Options.UseBackColor = true;
            this.btnDersListesi.Appearance.Options.UseFont = true;
            this.btnDersListesi.Appearance.Options.UseForeColor = true;
            this.btnDersListesi.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnDersListesi.AppearanceHovered.ForeColor = Color.White;
            this.btnDersListesi.AppearanceHovered.Options.UseBackColor = true;
            this.btnDersListesi.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnDersListesi.AppearancePressed.Options.UseBackColor = true;
            this.btnDersListesi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDersListesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDersListesi.Location = new Point(10, 245);
            this.btnDersListesi.Name = "btnDersListesi";
            this.btnDersListesi.Size = new Size(200, 45);
            this.btnDersListesi.Text = "  📚  Dersler";
            this.btnDersListesi.Click += new System.EventHandler(this.btnDersListesi_ItemClick);
            
            // 
            // btnNotGirisi
            // 
            this.btnNotGirisi.Appearance.BackColor = Color.Transparent;
            this.btnNotGirisi.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnNotGirisi.Appearance.ForeColor = Color.White;
            this.btnNotGirisi.Appearance.Options.UseBackColor = true;
            this.btnNotGirisi.Appearance.Options.UseFont = true;
            this.btnNotGirisi.Appearance.Options.UseForeColor = true;
            this.btnNotGirisi.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnNotGirisi.AppearanceHovered.ForeColor = Color.White;
            this.btnNotGirisi.AppearanceHovered.Options.UseBackColor = true;
            this.btnNotGirisi.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnNotGirisi.AppearancePressed.Options.UseBackColor = true;
            this.btnNotGirisi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNotGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotGirisi.Location = new Point(10, 295);
            this.btnNotGirisi.Name = "btnNotGirisi";
            this.btnNotGirisi.Size = new Size(200, 45);
            this.btnNotGirisi.Text = "  📊  Notlar";
            this.btnNotGirisi.Click += new System.EventHandler(this.btnNotGirisi_ItemClick);
            
            // 
            // btnDersProgrami
            // 
            this.btnDersProgrami.Appearance.BackColor = Color.Transparent;
            this.btnDersProgrami.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnDersProgrami.Appearance.ForeColor = Color.White;
            this.btnDersProgrami.Appearance.Options.UseBackColor = true;
            this.btnDersProgrami.Appearance.Options.UseFont = true;
            this.btnDersProgrami.Appearance.Options.UseForeColor = true;
            this.btnDersProgrami.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnDersProgrami.AppearanceHovered.ForeColor = Color.White;
            this.btnDersProgrami.AppearanceHovered.Options.UseBackColor = true;
            this.btnDersProgrami.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnDersProgrami.AppearancePressed.Options.UseBackColor = true;
            this.btnDersProgrami.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDersProgrami.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDersProgrami.Location = new Point(10, 345);
            this.btnDersProgrami.Name = "btnDersProgrami";
            this.btnDersProgrami.Size = new Size(200, 45);
            this.btnDersProgrami.Text = "  📅  Ders Programı";
            this.btnDersProgrami.Click += new System.EventHandler(this.btnDersProgrami_ItemClick);
            
            // 
            // btnOtomatikProgram
            // 
            this.btnOtomatikProgram.Appearance.BackColor = Color.Transparent;
            this.btnOtomatikProgram.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnOtomatikProgram.Appearance.ForeColor = Color.White;
            this.btnOtomatikProgram.Appearance.Options.UseBackColor = true;
            this.btnOtomatikProgram.Appearance.Options.UseFont = true;
            this.btnOtomatikProgram.Appearance.Options.UseForeColor = true;
            this.btnOtomatikProgram.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnOtomatikProgram.AppearanceHovered.ForeColor = Color.White;
            this.btnOtomatikProgram.AppearanceHovered.Options.UseBackColor = true;
            this.btnOtomatikProgram.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnOtomatikProgram.AppearancePressed.Options.UseBackColor = true;
            this.btnOtomatikProgram.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOtomatikProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtomatikProgram.Location = new Point(10, 395);
            this.btnOtomatikProgram.Name = "btnOtomatikProgram";
            this.btnOtomatikProgram.Size = new Size(200, 45);
            this.btnOtomatikProgram.Text = "  🤖  Otomatik Program";
            this.btnOtomatikProgram.Click += new System.EventHandler(this.btnOtomatikProgram_ItemClick);
            
            // 
            // btnOrtalamaHesapla
            // 
            this.btnOrtalamaHesapla.Appearance.BackColor = Color.Transparent;
            this.btnOrtalamaHesapla.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnOrtalamaHesapla.Appearance.ForeColor = Color.White;
            this.btnOrtalamaHesapla.Appearance.Options.UseBackColor = true;
            this.btnOrtalamaHesapla.Appearance.Options.UseFont = true;
            this.btnOrtalamaHesapla.Appearance.Options.UseForeColor = true;
            this.btnOrtalamaHesapla.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnOrtalamaHesapla.AppearanceHovered.ForeColor = Color.White;
            this.btnOrtalamaHesapla.AppearanceHovered.Options.UseBackColor = true;
            this.btnOrtalamaHesapla.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnOrtalamaHesapla.AppearancePressed.Options.UseBackColor = true;
            this.btnOrtalamaHesapla.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOrtalamaHesapla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrtalamaHesapla.Location = new Point(10, 445);
            this.btnOrtalamaHesapla.Name = "btnOrtalamaHesapla";
            this.btnOrtalamaHesapla.Size = new Size(200, 45);
            this.btnOrtalamaHesapla.Text = "  🧮  Ortalama Hesapla";
            this.btnOrtalamaHesapla.Click += new System.EventHandler(this.btnOrtalamaHesapla_ItemClick);
            
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Appearance.BackColor = Color.Transparent;
            this.btnAyarlar.Appearance.Font = new Font("Segoe UI", 10F);
            this.btnAyarlar.Appearance.ForeColor = Color.White;
            this.btnAyarlar.Appearance.Options.UseBackColor = true;
            this.btnAyarlar.Appearance.Options.UseFont = true;
            this.btnAyarlar.Appearance.Options.UseForeColor = true;
            this.btnAyarlar.AppearanceHovered.BackColor = Color.FromArgb(0, 206, 201);
            this.btnAyarlar.AppearanceHovered.ForeColor = Color.White;
            this.btnAyarlar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAyarlar.AppearancePressed.BackColor = Color.FromArgb(80, 75, 200);
            this.btnAyarlar.AppearancePressed.Options.UseBackColor = true;
            this.btnAyarlar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnAyarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyarlar.Location = new Point(10, 495);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new Size(200, 45);
            this.btnAyarlar.Text = "  ⚙️  Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_ItemClick);
            
            // 
            // btnCikis
            // 
            this.btnCikis.Appearance.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCikis.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCikis.Appearance.ForeColor = Color.White;
            this.btnCikis.Appearance.Options.UseBackColor = true;
            this.btnCikis.Appearance.Options.UseFont = true;
            this.btnCikis.Appearance.Options.UseForeColor = true;
            this.btnCikis.AppearanceHovered.BackColor = Color.FromArgb(200, 35, 51);
            this.btnCikis.AppearanceHovered.Options.UseBackColor = true;
            this.btnCikis.AppearancePressed.BackColor = Color.FromArgb(180, 25, 41);
            this.btnCikis.AppearancePressed.Options.UseBackColor = true;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.Location = new Point(10, 640);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new Size(200, 45);
            this.btnCikis.Text = "  🚪  Çıkış";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_ItemClick);
            
            // 
            // pnlHeader - Üst Başlık Paneli
            // 
            this.pnlHeader.Appearance.BackColor = Color.FromArgb(108, 99, 255);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblKullanici);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(980, 60);
            
            // 
            // lblKullanici
            // 
            this.lblKullanici.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblKullanici.Appearance.ForeColor = Color.White;
            this.lblKullanici.Appearance.Options.UseFont = true;
            this.lblKullanici.Appearance.Options.UseForeColor = true;
            this.lblKullanici.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblKullanici.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblKullanici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblKullanici.Text = "👤 Hoş Geldiniz";
            
            // 
            // pnlContent - Ana İçerik Paneli
            // 
            this.pnlContent.Appearance.BackColor = Color.FromArgb(30, 30, 60);
            this.pnlContent.Appearance.Options.UseBackColor = true;
            this.pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new Point(220, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new Size(980, 640);
            
            // 
            // FrmAnaModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnaModul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Bilgi Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAnaModul_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlSidebar;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.LabelControl lblLogo;
        private DevExpress.XtraEditors.LabelControl lblKullanici;
        private DevExpress.XtraEditors.SimpleButton btnOgrenciListesi;
        private DevExpress.XtraEditors.SimpleButton btnOgretmenListesi;
        private DevExpress.XtraEditors.SimpleButton btnDersListesi;
        private DevExpress.XtraEditors.SimpleButton btnNotGirisi;
        private DevExpress.XtraEditors.SimpleButton btnDersProgrami;
        private DevExpress.XtraEditors.SimpleButton btnOtomatikProgram;
        private DevExpress.XtraEditors.SimpleButton btnOrtalamaHesapla;
        private DevExpress.XtraEditors.SimpleButton btnAyarlar;
        private DevExpress.XtraEditors.SimpleButton btnCikis;
        private DevExpress.XtraEditors.PictureEdit picLogo;
    }
}
