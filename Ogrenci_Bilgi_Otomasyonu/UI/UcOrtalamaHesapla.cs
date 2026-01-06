using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcOrtalamaHesapla : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly NotManager _notManager = new NotManager();
        private readonly OgrenciManager _ogrenciManager = new OgrenciManager();
        private readonly SinifManager _sinifManager = new SinifManager();

        public UcOrtalamaHesapla()
        {
            InitializeComponent();
            this.Load += UcOrtalamaHesapla_Load;
        }

        private void UcOrtalamaHesapla_Load(object sender, EventArgs e)
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            if (kullanici.RolID == 1)
            {
                // Yönetici - tüm öğrencilerin takdir/teşekkür durumunu göster
                TumOgrencileriGoster();
            }
            else if (kullanici.RolID == 3)
            {
                // Öğrenci - kendi notlarını göster
                OgrenciNotlariniGoster(kullanici.KullaniciID);
            }
            else
            {
                lblOrtalama.Text = "-";
                lblDurum.Text = "Bu özellik öğrenciler ve yöneticiler içindir.";
            }
        }

        private void TumOgrencileriGoster()
        {
            try
            {
                var ogrenciler = _ogrenciManager.TumOgrencileriGetir();
                
                // Yeni DataTable oluştur
                var sonuclar = new DataTable();
                sonuclar.Columns.Add("OgrenciNo", typeof(string));
                sonuclar.Columns.Add("AdSoyad", typeof(string));
                sonuclar.Columns.Add("Sinif", typeof(string));
                sonuclar.Columns.Add("GenelOrtalama", typeof(decimal));
                sonuclar.Columns.Add("DersSayisi", typeof(int));
                sonuclar.Columns.Add("Durum", typeof(string));

                int takdirSayisi = 0;
                int tesekkurSayisi = 0;
                int basarisizSayisi = 0;

                foreach (DataRow ogr in ogrenciler.Rows)
                {
                    int ogrenciId = Convert.ToInt32(ogr["OgrenciID"]);
                    string ogrenciNo = ogr["OgrenciNo"]?.ToString() ?? "";
                    string adSoyad = ogr["AdSoyad"]?.ToString() ?? "";
                    string sinif = ogr["SinifAdi"]?.ToString() ?? "";

                    // Öğrencinin notlarını getir
                    var notlar = _notManager.OgrenciNotlariGetirById(ogrenciId);
                    
                    if (notlar == null || notlar.Rows.Count == 0)
                    {
                        sonuclar.Rows.Add(ogrenciNo, adSoyad, sinif, 0, 0, "Not Yok");
                        continue;
                    }

                    decimal toplamOrtalama = 0;
                    int dersSayisi = 0;

                    foreach (DataRow not in notlar.Rows)
                    {
                        decimal yazili1 = not["Yazili1"] != DBNull.Value ? Convert.ToDecimal(not["Yazili1"]) : 0;
                        decimal yazili2 = not["Yazili2"] != DBNull.Value ? Convert.ToDecimal(not["Yazili2"]) : 0;
                        decimal sozlu1 = not["Sozlu1"] != DBNull.Value ? Convert.ToDecimal(not["Sozlu1"]) : 0;
                        decimal sozlu2 = not["Sozlu2"] != DBNull.Value ? Convert.ToDecimal(not["Sozlu2"]) : 0;

                        // Ders ortalaması: (Yazılı1 + Yazılı2 + Sözlü1 + Sözlü2) / 4
                        decimal dersOrtalamasi = (yazili1 + yazili2 + sozlu1 + sozlu2) / 4m;
                        toplamOrtalama += dersOrtalamasi;
                        dersSayisi++;
                    }

                    decimal genelOrtalama = dersSayisi > 0 ? toplamOrtalama / dersSayisi : 0;

                    string durum = "";
                    if (genelOrtalama >= 85)
                    {
                        durum = "TAKDİR";
                        takdirSayisi++;
                    }
                    else if (genelOrtalama >= 70)
                    {
                        durum = "TEŞEKKÜR";
                        tesekkurSayisi++;
                    }
                    else if (genelOrtalama >= 50)
                    {
                        durum = "Geçti";
                    }
                    else
                    {
                        durum = "Başarısız";
                        basarisizSayisi++;
                    }

                    sonuclar.Rows.Add(ogrenciNo, adSoyad, sinif, Math.Round(genelOrtalama, 2), dersSayisi, durum);
                }

                // Grid'i temizle
                gridView.Columns.Clear();
                gridControl.DataSource = null;
                gridControl.DataSource = sonuclar;

                // Kolon başlıkları
                if (gridView.Columns["OgrenciNo"] != null) gridView.Columns["OgrenciNo"].Caption = "Öğrenci No";
                if (gridView.Columns["AdSoyad"] != null) gridView.Columns["AdSoyad"].Caption = "Ad Soyad";
                if (gridView.Columns["Sinif"] != null) gridView.Columns["Sinif"].Caption = "Sınıf";
                if (gridView.Columns["GenelOrtalama"] != null) gridView.Columns["GenelOrtalama"].Caption = "Ortalama";
                if (gridView.Columns["DersSayisi"] != null) gridView.Columns["DersSayisi"].Caption = "Ders Sayısı";
                if (gridView.Columns["Durum"] != null) gridView.Columns["Durum"].Caption = "Belge Durumu";

                gridView.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OgrenciNotlariniGoster(int kullaniciId)
        {
            try
            {
                var notlar = _notManager.OgrenciNotlariGetir(kullaniciId);
                
                if (notlar == null || notlar.Rows.Count == 0)
                {
                    lblOrtalama.Text = "Henüz not bulunmuyor";
                    lblDurum.Text = "-";
                    lblDurum.ForeColor = Color.Gray;
                    return;
                }

                decimal toplamOrtalama = 0;
                int dersSayisi = 0;

                foreach (DataRow row in notlar.Rows)
                {
                    decimal yazili1 = row["Yazili1"] != DBNull.Value ? Convert.ToDecimal(row["Yazili1"]) : 0;
                    decimal yazili2 = row["Yazili2"] != DBNull.Value ? Convert.ToDecimal(row["Yazili2"]) : 0;
                    decimal sozlu1 = row["Sozlu1"] != DBNull.Value ? Convert.ToDecimal(row["Sozlu1"]) : 0;
                    decimal sozlu2 = row["Sozlu2"] != DBNull.Value ? Convert.ToDecimal(row["Sozlu2"]) : 0;

                    // Ders ortalaması: (Yazılı1 + Yazılı2 + Sözlü1 + Sözlü2) / 4
                    decimal dersOrtalamasi = (yazili1 + yazili2 + sozlu1 + sozlu2) / 4m;
                    toplamOrtalama += dersOrtalamasi;
                    dersSayisi++;
                }

                decimal genelOrtalama = dersSayisi > 0 ? toplamOrtalama / dersSayisi : 0;

                lblOrtalama.Text = genelOrtalama.ToString("F2");
                lblDersSayisi.Text = dersSayisi.ToString();

                string durum;
                Color renk;

                if (genelOrtalama >= 85)
                {
                    durum = "TAKDİR BELGESİ";
                    renk = Color.FromArgb(255, 193, 7);
                }
                else if (genelOrtalama >= 70)
                {
                    durum = "TEŞEKKÜR BELGESİ";
                    renk = Color.FromArgb(76, 175, 80);
                }
                else if (genelOrtalama >= 50)
                {
                    durum = "GEÇTİ";
                    renk = Color.FromArgb(33, 150, 243);
                }
                else
                {
                    durum = "BAŞARISIZ";
                    renk = Color.FromArgb(244, 67, 54);
                }

                lblDurum.Text = durum;
                lblDurum.ForeColor = renk;

                progressOrtalama.Properties.Maximum = 100;
                progressOrtalama.EditValue = Math.Min((int)genelOrtalama, 100);

                gridControl.DataSource = notlar;
                
                if (gridView.Columns["DersAdi"] != null) gridView.Columns["DersAdi"].Caption = "Ders";
                if (gridView.Columns["Yazili1"] != null) gridView.Columns["Yazili1"].Caption = "1. Yazılı";
                if (gridView.Columns["Yazili2"] != null) gridView.Columns["Yazili2"].Caption = "2. Yazılı";
                if (gridView.Columns["Sozlu1"] != null) gridView.Columns["Sozlu1"].Caption = "1. Sözlü";
                if (gridView.Columns["Sozlu2"] != null) gridView.Columns["Sozlu2"].Caption = "2. Sözlü";
                if (gridView.Columns["Ortalama"] != null) gridView.Columns["Ortalama"].Caption = "Ders Ort.";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hesaplama hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            UcOrtalamaHesapla_Load(sender, e);
        }
    }
}
