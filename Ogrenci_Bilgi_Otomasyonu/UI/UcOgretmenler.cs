using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcOgretmenler : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly OgretmenManager _manager = new OgretmenManager();
        private int _secilenId = 0;
        private Timer slideTimer;

        public UcOgretmenler()
        {
            InitializeComponent();
            this.Load += UcOgretmenler_Load;
            this.pnlHeader.Paint += PnlHeader_Paint;
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlHeader.ClientRectangle,
                Color.FromArgb(255, 112, 67),
                Color.FromArgb(255, 152, 0),
                0F))
            {
                e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            }
        }

        private void UcOgretmenler_Load(object sender, EventArgs e)
        {
            groupControl.Left = this.Width;
            slideTimer = new Timer { Interval = 15 };
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            Listele();
            
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
            gridControl.DataSource = _manager.TumOgretmenleriGetir();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle >= 0)
            {
                _secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("OgretmenID"));
                var entity = _manager.OgretmenGetir(_secilenId);
                if (entity != null)
                {
                    txtAd.Text = entity.Ad;
                    txtSoyad.Text = entity.Soyad;
                    txtTC.Text = entity.TC;
                    cmbBrans.Text = entity.Brans;
                    cmbCinsiyet.Text = entity.Cinsiyet;
                    txtTelefon.Text = entity.Telefon;
                    txtEmail.Text = entity.Email;
                }
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                XtraMessageBox.Show("Zorunlu alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entity = new Ogretmen
            {
                OgretmenID = _secilenId,
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                TC = txtTC.Text,
                Brans = cmbBrans.Text,
                Cinsiyet = cmbCinsiyet.Text,
                Telefon = txtTelefon.Text,
                Email = txtEmail.Text,
                Durum = true
            };

            try
            {
                if (_secilenId == 0) 
                    _manager.OgretmenEkle(entity);
                else 
                    _manager.OgretmenGuncelle(entity);
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
                _manager.OgretmenSil(_secilenId);
                XtraMessageBox.Show("Silme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); 
                Temizle();
            }
        }

        private void Temizle()
        {
            _secilenId = 0;
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
            cmbBrans.SelectedIndex = -1;
            txtTelefon.Text = "";
            txtEmail.Text = "";
            cmbCinsiyet.SelectedIndex = -1;
        }
    }
}
