using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class FrmGiris : XtraForm
    {
        public static Kullanici AktifKullanici { get; set; }

        private Timer fadeTimer;
        private Timer slideTimer;
        private Timer pulseTimer;
        private Timer gradientTimer;
        private Timer fadeOutTimer;
        private Timer exitTimer;
        
        private double formOpacity = 0;
        private int loginPanelY = 0;
        private int targetLoginPanelY = 60;
        private bool pulseDirection = true;
        private int pulseValue = 0;
        private float gradientAngle = 0;

        private bool isDragging = false;
        private Point dragStartPoint;

        public FrmGiris()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Opacity = 0;

            this.pnlMain.MouseDown += PnlMain_MouseDown;
            this.pnlMain.MouseMove += PnlMain_MouseMove;
            this.pnlMain.MouseUp += PnlMain_MouseUp;
            this.pnlLogin.MouseDown += PnlMain_MouseDown;
            this.pnlLogin.MouseMove += PnlMain_MouseMove;
            this.pnlLogin.MouseUp += PnlMain_MouseUp;

            loginPanelY = 150;
            pnlLogin.Top = loginPanelY;

            StartAnimations();
            
            // Logo yükle
            LoadLogo();
            
            // Form ikonunu ayarla
            LoadIcon();
        }

        private void StartAnimations()
        {
            fadeTimer = new Timer { Interval = 20 };
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();

            slideTimer = new Timer { Interval = 15 };
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            pulseTimer = new Timer { Interval = 50 };
            pulseTimer.Tick += PulseTimer_Tick;
            pulseTimer.Start();

            gradientTimer = new Timer { Interval = 50 };
            gradientTimer.Tick += GradientTimer_Tick;
            gradientTimer.Start();
        }

        private void LoadLogo()
        {
            try
            {
                // Uygulama klasöründen logo yükle
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string logoPath = System.IO.Path.Combine(basePath, "Resources", "logo.png");
                
                if (System.IO.File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch (Exception)
            {
                // Logo yüklenemezse sessizce geç
            }
        }

        private new void LoadIcon()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string iconPath = System.IO.Path.Combine(basePath, "Resources", "icon.png");
                
                if (System.IO.File.Exists(iconPath))
                {
                    using (var bmp = new Bitmap(iconPath))
                    {
                        IntPtr hIcon = bmp.GetHicon();
                        this.Icon = System.Drawing.Icon.FromHandle(hIcon);
                    }
                }
            }
            catch (Exception)
            {
                // İkon yüklenemezse sessizce geç
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            formOpacity += 0.05;
            if (formOpacity >= 1)
            {
                formOpacity = 1;
                fadeTimer.Stop();
            }
            this.Opacity = formOpacity;
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (loginPanelY > targetLoginPanelY)
            {
                loginPanelY -= 5;
                pnlLogin.Top = loginPanelY;
            }
            else
            {
                slideTimer.Stop();
            }
        }

        private void PulseTimer_Tick(object sender, EventArgs e)
        {
            if (pulseDirection)
            {
                pulseValue += 3;
                if (pulseValue >= 30) pulseDirection = false;
            }
            else
            {
                pulseValue -= 3;
                if (pulseValue <= 0) pulseDirection = true;
            }

            int r = Math.Min(255, 108 + pulseValue);
            int g = Math.Min(255, 99 + pulseValue);
            int b = 255;
            btnGiris.Appearance.BackColor = Color.FromArgb(r, g, b);
        }

        private void GradientTimer_Tick(object sender, EventArgs e)
        {
            gradientAngle = (gradientAngle + 0.5f) % 360;
            this.Invalidate();
        }

        private void FrmGiris_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(108, 99, 255),
                Color.FromArgb(0, 188, 212),
                gradientAngle))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush, -100, -100, 300, 300);
                e.Graphics.FillEllipse(circleBrush, this.Width - 150, this.Height - 150, 250, 250);
                e.Graphics.FillEllipse(circleBrush, this.Width - 80, 50, 150, 150);
            }
        }

        private void PnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }
        }

        private void PnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.Location;
                newLocation.X += e.X - dragStartPoint.X;
                newLocation.Y += e.Y - dragStartPoint.Y;
                this.Location = newLocation;
            }
        }

        private void PnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                ShakeForm();
                XtraMessageBox.Show("Kullanıcı adı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                ShakeForm();
                XtraMessageBox.Show("Şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            btnGiris.Text = "Giriş yapılıyor...";
            btnGiris.Enabled = false;
            Application.DoEvents();

            try
            {
                var manager = new KullaniciManager();
                var kullanici = manager.GirisYap(txtKullaniciAdi.Text.Trim(), txtSifre.Text);

                if (kullanici != null)
                {
                    AktifKullanici = kullanici;
                    
                    btnGiris.Appearance.BackColor = Color.FromArgb(76, 175, 80);
                    btnGiris.Text = "Başarılı!";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);

                    XtraMessageBox.Show("Hoş geldiniz, " + kullanici.AdSoyad + "!\nRol: " + kullanici.RolAdi, 
                        "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FadeOutAndShowMain();
                }
                else
                {
                    ShakeForm();
                    btnGiris.Appearance.BackColor = Color.FromArgb(244, 67, 54);
                    btnGiris.Text = "Hata!";
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);

                    XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    btnGiris.Appearance.BackColor = Color.FromArgb(108, 99, 255);
                    btnGiris.Text = "Giriş Yap";
                    btnGiris.Enabled = true;
                    txtSifre.Text = "";
                    txtSifre.Focus();
                }
            }
            catch (Exception ex)
            {
                btnGiris.Appearance.BackColor = Color.FromArgb(108, 99, 255);
                btnGiris.Text = "Giriş Yap";
                btnGiris.Enabled = true;
                XtraMessageBox.Show("Veritabanı bağlantı hatası!\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShakeForm()
        {
            var original = this.Location;
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                this.Location = new Point(original.X + rnd.Next(-10, 10), original.Y + rnd.Next(-5, 5));
                System.Threading.Thread.Sleep(25);
            }
            this.Location = original;
        }

        private void FadeOutAndShowMain()
        {
            fadeOutTimer = new Timer { Interval = 20 };
            fadeOutTimer.Tick += FadeOutTimer_Tick;
            fadeOutTimer.Start();
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity <= 0)
            {
                fadeOutTimer.Stop();
                var frmAna = new FrmAnaModul();
                frmAna.Show();
                this.Hide();
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            exitTimer = new Timer { Interval = 20 };
            exitTimer.Tick += ExitTimer_Tick;
            exitTimer.Start();
        }

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity <= 0)
            {
                exitTimer.Stop();
                Application.Exit();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (fadeTimer != null) fadeTimer.Stop();
            if (slideTimer != null) slideTimer.Stop();
            if (pulseTimer != null) pulseTimer.Stop();
            if (gradientTimer != null) gradientTimer.Stop();
            base.OnFormClosed(e);
        }
    }
}
