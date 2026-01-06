using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcAyarlar : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly string _ayarlarDosyasi;
        private readonly KullaniciManager _kullaniciManager = new KullaniciManager();

        public UcAyarlar()
        {
            InitializeComponent();
            _ayarlarDosyasi = Path.Combine(Application.StartupPath, "ayarlar.config");
            this.Load += UcAyarlar_Load;
        }

        private void UcAyarlar_Load(object sender, EventArgs e)
        {
            AyarlariYukle();
            KullaniciBilgileriniYukle();
            
            // Admin olmayan kullanıcılar için API ayarlarını gizle
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici?.RolID != 1) // 1 = Admin
            {
                groupApiSettings.Visible = false;
            }
        }

        private void KullaniciBilgileriniYukle()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici != null)
            {
                lblKullaniciAdi.Text = kullanici.KullaniciAdi;
                lblRol.Text = kullanici.RolAdi;
                lblSonGiris.Text = kullanici.SonGirisTarihi?.ToString("dd.MM.yyyy HH:mm") ?? "-";
            }
        }

        private void AyarlariYukle()
        {
            try
            {
                if (File.Exists(_ayarlarDosyasi))
                {
                    var satirlar = File.ReadAllLines(_ayarlarDosyasi);
                    foreach (var satir in satirlar)
                    {
                        var parcalar = satir.Split('=');
                        if (parcalar.Length == 2)
                        {
                            switch (parcalar[0].Trim())
                            {
                                case "ApiKey": txtApiKey.Text = parcalar[1].Trim(); break;
                                case "ApiProvider": cmbApiProvider.Text = parcalar[1].Trim(); break;
                                case "OtomatikYedekleme": chkOtomatikYedekleme.Checked = parcalar[1].Trim() == "True"; break;
                                case "BildirimGoster": chkBildirimGoster.Checked = parcalar[1].Trim() == "True"; break;
                                case "KaranlikTema": chkKaranlikTema.Checked = parcalar[1].Trim() == "True"; break;
                                case "OtomatikGuncelleme": chkOtomatikGuncelleme.Checked = parcalar[1].Trim() == "True"; break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ayarlar yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var ayarlar = new[]
                {
                    $"ApiKey={txtApiKey.Text}",
                    $"ApiProvider={cmbApiProvider.Text}",
                    $"OtomatikYedekleme={chkOtomatikYedekleme.Checked}",
                    $"BildirimGoster={chkBildirimGoster.Checked}",
                    $"KaranlikTema={chkKaranlikTema.Checked}",
                    $"OtomatikGuncelleme={chkOtomatikGuncelleme.Checked}"
                };

                File.WriteAllLines(_ayarlarDosyasi, ayarlar);
                XtraMessageBox.Show("Ayarlar başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Ayarlar kaydedilirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            // Validasyonlar
            if (string.IsNullOrWhiteSpace(txtMevcutSifre.Text))
            {
                XtraMessageBox.Show("Mevcut şifrenizi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMevcutSifre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYeniSifre.Text))
            {
                XtraMessageBox.Show("Yeni şifrenizi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text.Length < 6)
            {
                XtraMessageBox.Show("Yeni şifre en az 6 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifre.Focus();
                return;
            }

            if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                XtraMessageBox.Show("Yeni şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniSifreTekrar.Focus();
                return;
            }

            // Mevcut şifreyi doğrula
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            var dogrulama = _kullaniciManager.GirisKontrol(kullanici.KullaniciAdi, txtMevcutSifre.Text);
            if (dogrulama == null)
            {
                XtraMessageBox.Show("Mevcut şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMevcutSifre.Focus();
                return;
            }

            // Şifreyi güncelle
            try
            {
                _kullaniciManager.SifreDegistir(kullanici.KullaniciID, txtYeniSifre.Text);
                XtraMessageBox.Show("Şifreniz başarıyla değiştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Alanları temizle
                txtMevcutSifre.Text = "";
                txtYeniSifre.Text = "";
                txtYeniSifreTekrar.Text = "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Şifre değiştirme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApiTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                XtraMessageBox.Show("Lütfen API anahtarını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbApiProvider.Text))
            {
                XtraMessageBox.Show("Lütfen bir yapay zeka sağlayıcısı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnApiTest.Enabled = false;
                var olusturucu = new DersProgramiOlusturucu();
                string sonuc = await olusturucu.TestApiConnection(cmbApiProvider.Text, txtApiKey.Text);
                
                if (sonuc.Contains("Başarılı"))
                    XtraMessageBox.Show(sonuc, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(sonuc, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnApiTest.Enabled = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtApiKey.Text = "";
            cmbApiProvider.SelectedIndex = -1;
            chkOtomatikYedekleme.Checked = false;
            chkBildirimGoster.Checked = true;
            chkKaranlikTema.Checked = false;
            chkOtomatikGuncelleme.Checked = true;
        }
    }
}
