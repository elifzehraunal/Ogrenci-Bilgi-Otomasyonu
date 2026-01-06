using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class FrmAnaModul : XtraForm
    {
        private Timer fadeTimer;
        private Timer welcomeTimer;
        private double formOpacity = 0;
        private SimpleButton activeButton = null;

        // Sürükle-bırak için değişkenler
        private bool isDragging = false;
        private Point dragStartPoint;

        public FrmAnaModul()
        {
            InitializeComponent();
            this.FormClosed += FrmAnaModul_FormClosed;
            this.Opacity = 0;
            
            // Header'ı sürüklenebilir yap
            this.pnlHeader.MouseDown += PnlHeader_MouseDown;
            this.pnlHeader.MouseMove += PnlHeader_MouseMove;
            this.pnlHeader.MouseUp += PnlHeader_MouseUp;
            
            // Çift tıklama ile maximize/restore
            this.pnlHeader.DoubleClick += PnlHeader_DoubleClick;
            
            // Gradient boyama
            this.pnlSidebar.Paint += PnlSidebar_Paint;
            this.pnlHeader.Paint += PnlHeader_Paint;
            this.pnlContent.Paint += PnlContent_Paint;
            
            StartFadeIn();
        }

        #region Gradient Paneller

        private void PnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Control;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(108, 99, 255),   // Mor
                Color.FromArgb(75, 0, 130),     // Koyu Mor
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Control;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(108, 99, 255),   // Mor
                Color.FromArgb(0, 206, 201),    // Turkuaz
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void PnlContent_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Control;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(30, 30, 60),     // Koyu Lacivert
                Color.FromArgb(50, 50, 80),     // Orta Lacivert
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        #endregion

        #region Sürükle-Bırak ve Maximize

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }
        }

        private void PnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPos = PointToScreen(e.Location);
                this.Location = new Point(currentPos.X - dragStartPoint.X - pnlSidebar.Width, currentPos.Y - dragStartPoint.Y);
            }
        }

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void PnlHeader_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        #region Animasyonlar

        private void StartFadeIn()
        {
            fadeTimer = new Timer { Interval = 20 };
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            formOpacity += 0.05;
            if (formOpacity >= 1)
            {
                formOpacity = 1;
                fadeTimer.Stop();
                ShowWelcomeMessage();
            }
            this.Opacity = formOpacity;
        }

        private string GetRolEmoji(int? rolID)
        {
            if (rolID == null) return "👤";
            switch (rolID.Value)
            {
                case 1: return "👑";
                case 2: return "👨‍🏫";
                case 3: return "🎓";
                default: return "👤";
            }
        }

        private void ShowWelcomeMessage()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici != null)
            {
                string emoji = GetRolEmoji(kullanici.RolID);
                string hosgeldin = emoji + " Hoş geldiniz, " + kullanici.AdSoyad + "!";
                
                var welcomePanel = new PanelControl
                {
                    Size = new Size(400, 100),
                    Location = new Point((pnlContent.Width - 400) / 2, (pnlContent.Height - 100) / 2),
                    BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
                };
                welcomePanel.Appearance.BackColor = Color.FromArgb(108, 99, 255);
                welcomePanel.Appearance.Options.UseBackColor = true;

                var welcomeLabel = new LabelControl
                {
                    Text = hosgeldin,
                    AutoSizeMode = LabelAutoSizeMode.None,
                    Dock = DockStyle.Fill
                };
                welcomeLabel.Appearance.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                welcomeLabel.Appearance.ForeColor = Color.White;
                welcomeLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                welcomeLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                welcomeLabel.Appearance.Options.UseFont = true;
                welcomeLabel.Appearance.Options.UseForeColor = true;
                welcomeLabel.Appearance.Options.UseTextOptions = true;

                welcomePanel.Controls.Add(welcomeLabel);
                pnlContent.Controls.Add(welcomePanel);

                welcomeTimer = new Timer { Interval = 2500 };
                welcomeTimer.Tick += WelcomeTimer_Tick;
                welcomeTimer.Tag = welcomePanel;
                welcomeTimer.Start();
            }
        }

        private void WelcomeTimer_Tick(object sender, EventArgs e)
        {
            welcomeTimer.Stop();
            var panel = welcomeTimer.Tag as Control;
            if (panel != null)
            {
                pnlContent.Controls.Remove(panel);
                panel.Dispose();
            }
        }

        #endregion

        private void FrmAnaModul_Load_1(object sender, EventArgs e)
        {
            YetkileriAyarla();
            var kullanici = FrmGiris.AktifKullanici;
            string emoji = GetRolEmoji(kullanici?.RolID);
            this.Text = emoji + " Öğrenci Bilgi Sistemi - " + kullanici?.RolAdi + " (" + kullanici?.AdSoyad + ")";
            lblKullanici.Text = emoji + " " + kullanici?.AdSoyad + " | " + kullanici?.RolAdi;
        }

        private void YetkileriAyarla()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            switch (kullanici.RolID)
            {
                case 1: // Admin - tüm yetkiler (ortalama hesapla hariç)
                    btnOrtalamaHesapla.Visible = false;
                    break;
                case 2: // Öğretmen
                    btnDersListesi.Visible = false;
                    btnOtomatikProgram.Visible = false;
                    btnOrtalamaHesapla.Visible = false;
                    break;
                case 3: // Öğrenci
                    btnOgrenciListesi.Visible = false;
                    btnOgretmenListesi.Visible = false;
                    btnDersListesi.Visible = false;
                    btnOtomatikProgram.Visible = false;
                    btnNotGirisi.Text = "  📊  Notlarım";
                    // Öğrenci ortalama hesapla görebilir
                    break;
            }
            
            // Butonları yeniden düzenle
            ReorganizeButtons();
        }

        private void ReorganizeButtons()
        {
            // Görünür butonları sırala (Çıkış hariç)
            SimpleButton[] menuButtons = new SimpleButton[]
            {
                btnOgrenciListesi,
                btnOgretmenListesi,
                btnDersListesi,
                btnNotGirisi,
                btnDersProgrami,
                btnOtomatikProgram,
                btnOrtalamaHesapla,
                btnAyarlar
            };

            int buttonHeight = 45;
            int gap = 5;
            
            // Görünür buton sayısını hesapla
            int visibleCount = 0;
            foreach (var btn in menuButtons)
            {
                if (btn.Visible) visibleCount++;
            }
            
            // Logo + başlık alanı (0-130) ve çıkış butonu alanı (640-700)
            // Kullanılabilir alan: 130 - 620 = 490px
            int availableHeight = 490;
            int totalButtonsHeight = visibleCount * buttonHeight + (visibleCount - 1) * gap;
            
            // Butonları ortala
            int startY = 130 + (availableHeight - totalButtonsHeight) / 2;
            int currentY = startY;

            foreach (var btn in menuButtons)
            {
                if (btn.Visible)
                {
                    btn.Location = new Point(10, currentY);
                    currentY += buttonHeight + gap;
                }
            }
        }

        private void SetActiveButton(SimpleButton button)
        {
            // Önceki aktif butonu resetle
            if (activeButton != null)
            {
                activeButton.Appearance.BackColor = Color.Transparent;
            }
            
            // Yeni aktif butonu ayarla
            activeButton = button;
            if (activeButton != null)
            {
                activeButton.Appearance.BackColor = Color.FromArgb(108, 99, 255);
            }
        }

        private void IcerikGoster(Control control)
        {
            pnlContent.SuspendLayout();
            
            foreach (Control c in pnlContent.Controls)
            {
                c.Dispose();
            }
            pnlContent.Controls.Clear();
            
            control.Dock = DockStyle.Fill;
            control.Location = new Point(0, 0);
            pnlContent.Controls.Add(control);
            
            pnlContent.ResumeLayout();
        }

        #region Buton Clickleri

        private void btnOgrenciListesi_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnOgrenciListesi);
            IcerikGoster(new UcOgrenciler());
        }

        private void btnOgretmenListesi_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnOgretmenListesi);
            IcerikGoster(new UcOgretmenler());
        }

        private void btnDersListesi_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnDersListesi);
            IcerikGoster(new UcDersler());
        }

        private void btnNotGirisi_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnNotGirisi);
            IcerikGoster(new UcNotlar());
        }

        private void btnDersProgrami_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnDersProgrami);
            IcerikGoster(new UcDersProgrami());
        }

        private void btnAyarlar_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnAyarlar);
            IcerikGoster(new UcAyarlar());
        }

        private void btnOtomatikProgram_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnOtomatikProgram);
            IcerikGoster(new UcOtomatikDersProgrami());
        }

        private void btnOrtalamaHesapla_ItemClick(object sender, EventArgs e)
        {
            SetActiveButton(btnOrtalamaHesapla);
            IcerikGoster(new UcOrtalamaHesapla());
        }

        private void btnCikis_ItemClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("🚪 Çıkmak istediğinize emin misiniz?", 
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Timer exitTimer = new Timer { Interval = 20 };
                exitTimer.Tick += ExitTimer_Tick;
                exitTimer.Start();
            }
        }

        #endregion

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity <= 0)
            {
                ((Timer)sender).Stop();
                FrmGiris.AktifKullanici = null;
                Application.Exit();
            }
        }

        private void FrmAnaModul_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fadeTimer != null) fadeTimer.Stop();
            if (welcomeTimer != null) welcomeTimer.Stop();
            Application.Exit();
        }
    }
}
