using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcNotlar : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly NotManager _manager = new NotManager();
        private readonly OgrenciManager _ogrenciManager = new OgrenciManager();
        private readonly DersManager _dersManager = new DersManager();
        private readonly SinifManager _sinifManager = new SinifManager();
        private readonly SinifDersOgretmenManager _sdoManager = new SinifDersOgretmenManager();
        private int _secilenId = 0;
        private Timer slideTimer;

        public UcNotlar()
        {
            InitializeComponent();
            this.Load += UcNotlar_Load;
            this.pnlHeader.Paint += PnlHeader_Paint;
            
            // Event tanımlamalarını burada yapıyoruz ki Designer dosyasını bozmayalım
            this.lueSinif.EditValueChanged += lueSinif_EditValueChanged;
            this.lueDers.EditValueChanged += lueDers_EditValueChanged;
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlHeader.ClientRectangle,
                Color.FromArgb(108, 99, 255),
                Color.FromArgb(156, 39, 176),
                0F))
            {
                e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            }
        }

        private void UcNotlar_Load(object sender, EventArgs e)
        {
            groupControl.Left = this.Width;
            slideTimer = new Timer { Interval = 15 };
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            YetkileriAyarla();
            ComboYukle();
            Listele();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            int targetX = this.Width - groupControl.Width;
            if (groupControl.Left > targetX)
            {
                groupControl.Left -= 30;
                if (groupControl.Left < targetX) groupControl.Left = targetX;
            }
            else
            {
                slideTimer.Stop();
            }
        }

        private void YetkileriAyarla()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            if (kullanici.RolID == 2)
            {
                btnSil.Visible = false;
                lblBaslik.Text = "📝 NOT GİRİŞİ - ÖĞRETMEN";
            }
            else if (kullanici.RolID == 3)
            {
                groupControl.Visible = false;
                lblBaslik.Text = "📊 NOTLARİM";
            }
        }

        private void ComboYukle()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            if (kullanici.RolID == 2)
            {
                // ÖĞRETMEN: TBL_SinifDersOgretmen'den atandığı sınıfları göster
                var ogretmenSiniflari = _sdoManager.OgretmenSiniflariniGetir(kullanici.KullaniciID);
                lueSinif.Properties.DataSource = ogretmenSiniflari;
                lueSinif.Properties.DisplayMember = "SinifAdi";
                lueSinif.Properties.ValueMember = "SinifID";

                lueDers.Properties.DataSource = null;
                lueDers.Properties.ReadOnly = true;
            }
            else
            {
                // YÖNETİCİ: Tüm sınıfları göster
                lueSinif.Properties.DataSource = _sinifManager.SinifListesiGetir();
                lueSinif.Properties.DisplayMember = "SinifAdi";
                lueSinif.Properties.ValueMember = "SinifID";

                lueDers.Properties.DataSource = _dersManager.DersListesiGetir();
                lueDers.Properties.DisplayMember = "DersAdi";
                lueDers.Properties.ValueMember = "DersID";
            }
        }

        private void lueSinif_EditValueChanged(object sender, EventArgs e)
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            if (lueSinif.EditValue != null)
            {
                int sinifId = Convert.ToInt32(lueSinif.EditValue);
                string sinifAdi = lueSinif.Text;

                // Grid'i filtrele
                gridView.ActiveFilterString = $"[SinifAdi] = '{sinifAdi}'";

                // Seçilen sınıftaki öğrencileri yükle
                var ogrenciler = _ogrenciManager.SinifaGoreOgrencileriGetir(sinifId);
                lueOgrenci.Properties.DataSource = ogrenciler;
                lueOgrenci.Properties.DisplayMember = "AdSoyad";
                lueOgrenci.Properties.ValueMember = "OgrenciID";
                lueOgrenci.EditValue = null;

                if (kullanici.RolID == 2)
                {
                    // ÖĞRETMEN: TBL_SinifDersOgretmen'den bu sınıfta verdiği dersleri yükle
                    var ogretmenDersleri = _sdoManager.OgretmenSinifDersleriniGetir(kullanici.KullaniciID, sinifId);
                    lueDers.Properties.DataSource = ogretmenDersleri;
                    lueDers.Properties.DisplayMember = "DersAdi";
                    lueDers.Properties.ValueMember = "DersID";
                    lueDers.Properties.ReadOnly = false;

                    if (ogretmenDersleri.Rows.Count > 0)
                    {
                        lueDers.EditValue = ogretmenDersleri.Rows[0]["DersID"];
                    }
                    else
                    {
                        lueDers.EditValue = null;
                    }
                }
            }
            else
            {
                gridView.ActiveFilterString = ""; // Filtreyi temizle
                lueOgrenci.Properties.DataSource = null;
                if (kullanici.RolID == 2)
                {
                    lueDers.Properties.DataSource = null;
                }
            }
        }

        private void lueDers_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDers.EditValue != null && lueSinif.EditValue != null)
            {
                string sinifAdi = lueSinif.Text;
                string dersAdi = lueDers.Text;
                gridView.ActiveFilterString = $"[SinifAdi] = '{sinifAdi}' AND [DersAdi] = '{dersAdi}'";
            }
            else if (lueSinif.EditValue != null)
            {
                string sinifAdi = lueSinif.Text;
                gridView.ActiveFilterString = $"[SinifAdi] = '{sinifAdi}'";
            }
        }

        private void Listele()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            if (kullanici.RolID == 3) // Öğrenci
            {
                gridControl.DataSource = _manager.OgrenciNotlariGetir(kullanici.KullaniciID);
            }
            else if (kullanici.RolID == 2) // Öğretmen
            {
                gridControl.DataSource = _manager.OgretmenNotlariGetir(kullanici.KullaniciID);
            }
            else // Admin
            {
                gridControl.DataSource = _manager.TumNotlariGetir();
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle >= 0)
            {
                _secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("NotID"));
                
                var ogrenciId = gridView.GetFocusedRowCellValue("OgrenciID");
                if (ogrenciId != null)
                {
                    var ogrenci = _ogrenciManager.OgrenciGetir(Convert.ToInt32(ogrenciId));
                    if (ogrenci != null && ogrenci.SinifID != null)
                    {
                        lueSinif.EditValue = ogrenci.SinifID;
                    }
                }
                
                lueOgrenci.EditValue = gridView.GetFocusedRowCellValue("OgrenciID");
                lueDers.EditValue = gridView.GetFocusedRowCellValue("DersID");
                spnYazili1.EditValue = gridView.GetFocusedRowCellValue("Yazili1") ?? 0;
                spnYazili2.EditValue = gridView.GetFocusedRowCellValue("Yazili2") ?? 0;
                spnSozlu1.EditValue = gridView.GetFocusedRowCellValue("Sozlu1") ?? 0;
                spnSozlu2.EditValue = gridView.GetFocusedRowCellValue("Sozlu2") ?? 0;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (lueSinif.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir sınıf seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueSinif.Focus();
                return;
            }

            if (lueOgrenci.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir öğrenci seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueOgrenci.Focus();
                return;
            }

            if (lueDers.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir ders seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueDers.Focus();
                return;
            }

            var entity = new Not
            {
                NotID = _secilenId,
                OgrenciID = Convert.ToInt32(lueOgrenci.EditValue),
                DersID = Convert.ToInt32(lueDers.EditValue),
                Yazili1 = Convert.ToDecimal(spnYazili1.EditValue),
                Yazili2 = Convert.ToDecimal(spnYazili2.EditValue),
                Sozlu1 = Convert.ToDecimal(spnSozlu1.EditValue),
                Sozlu2 = Convert.ToDecimal(spnSozlu2.EditValue),
                Donem = "1. Dönem",
                OgretimYili = "2024-2025"
            };

            try
            {
                if (_secilenId == 0) 
                    _manager.NotEkle(entity);
                else 
                    _manager.NotGuncelle(entity);
                    
                XtraMessageBox.Show("Not başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); 
                Temizle();
            }
            catch (Exception ex) 
            { 
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_secilenId == 0) return;
            if (XtraMessageBox.Show("Bu notu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _manager.NotSil(_secilenId);
                XtraMessageBox.Show("Not silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); 
                Temizle();
            }
        }

        private void Temizle()
        {
            _secilenId = 0;
            lueSinif.EditValue = null;
            lueOgrenci.EditValue = null;
            
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null || kullanici.RolID != 2)
            {
                lueDers.EditValue = null;
            }
            else
            {
                lueDers.Properties.DataSource = null;
            }
            
            spnYazili1.EditValue = 0;
            spnYazili2.EditValue = 0;
            spnSozlu1.EditValue = 0;
            spnSozlu2.EditValue = 0;
        }
    }
}
