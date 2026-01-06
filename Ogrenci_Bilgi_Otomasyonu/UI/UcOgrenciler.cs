using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcOgrenciler : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly OgrenciManager _manager = new OgrenciManager();
        private readonly SinifManager _sinifManager = new SinifManager();
        private int _secilenId = 0;
        private Timer slideTimer;

        public UcOgrenciler()
        {
            InitializeComponent();
            this.Load += UcOgrenciler_Load;
            this.pnlHeader.Paint += PnlHeader_Paint;
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlHeader.ClientRectangle,
                Color.FromArgb(52, 168, 83),
                Color.FromArgb(76, 175, 80),
                0F))
            {
                e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            }
        }

        private void UcOgrenciler_Load(object sender, EventArgs e)
        {
            groupControl.Left = this.Width;
            slideTimer = new Timer { Interval = 15 };
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            Listele();
            SiniflariYukle();
            
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null || kullanici.RolID != 1)
            {
                btnYeni.Visible = false;
                btnKaydet.Visible = false;
                btnSil.Visible = false;
            }
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

        private void Listele()
        {
            gridControl.DataSource = _manager.TumOgrencileriGetir();
        }

        private void SiniflariYukle()
        {
            lueSinif.Properties.DataSource = _sinifManager.SinifListesiGetir();
            lueSinif.Properties.DisplayMember = "SinifAdi";
            lueSinif.Properties.ValueMember = "SinifID";
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle >= 0)
            {
                _secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("OgrenciID"));
                var entity = _manager.OgrenciGetir(_secilenId);
                if (entity != null)
                {
                    txtOgrenciNo.Text = entity.OgrenciNo;
                    txtAd.Text = entity.Ad;
                    txtSoyad.Text = entity.Soyad;
                    txtTC.Text = entity.TC;
                    lueSinif.EditValue = entity.SinifID;
                    cmbCinsiyet.Text = entity.Cinsiyet;
                    txtTelefon.Text = entity.Telefon;
                    txtVeliAdi.Text = entity.VeliAdi;
                    txtVeliTelefon.Text = entity.VeliTelefon;
                }
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            // Otomatik öğrenci numarası ata
            txtOgrenciNo.Text = _manager.OtomatikNoOlustur();
            txtOgrenciNo.Properties.ReadOnly = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                XtraMessageBox.Show("Zorunlu alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entity = new Ogrenci
            {
                OgrenciID = _secilenId,
                OgrenciNo = txtOgrenciNo.Text,
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                TC = txtTC.Text,
                SinifID = lueSinif.EditValue as int?,
                Cinsiyet = cmbCinsiyet.Text,
                Telefon = txtTelefon.Text,
                VeliAdi = txtVeliAdi.Text,
                VeliTelefon = txtVeliTelefon.Text,
                Durum = true
            };

            try
            {
                if (_secilenId == 0) 
                    _manager.OgrenciEkle(entity);
                else 
                    _manager.OgrenciGuncelle(entity);
                XtraMessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (XtraMessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _manager.OgrenciSil(_secilenId);
                XtraMessageBox.Show("Silme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); 
                Temizle();
            }
        }

        private void Temizle()
        {
            _secilenId = 0;
            txtOgrenciNo.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
            txtTelefon.Text = "";
            txtVeliAdi.Text = "";
            txtVeliTelefon.Text = "";
            lueSinif.EditValue = null;
            cmbCinsiyet.SelectedIndex = -1;
        }
    }
}
