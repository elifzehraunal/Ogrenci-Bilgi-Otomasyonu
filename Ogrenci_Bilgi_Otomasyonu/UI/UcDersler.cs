using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcDersler : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DersManager _manager = new DersManager();
        private readonly OgretmenManager _ogretmenManager = new OgretmenManager();
        private int _secilenId = 0;

        public UcDersler()
        {
            InitializeComponent();
            this.Load += UcDersler_Load;
        }

        private void UcDersler_Load(object sender, EventArgs e)
        {
            Listele();
            OgretmenleriYukle();
            
            // Admin olmayan kullanıcılar için düzenleme özelliklerini gizle
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici?.RolID != 1) // 1 = Admin
            {
                btnYeni.Visible = false;
                btnKaydet.Visible = false;
                btnSil.Visible = false;
            }
        }

        private void Listele() => gridControl.DataSource = _manager.DersListesiGetir();

        private void OgretmenleriYukle()
        {
            lueOgretmen.Properties.DataSource = _ogretmenManager.TumOgretmenleriGetir();
            lueOgretmen.Properties.DisplayMember = "AdSoyad";
            lueOgretmen.Properties.ValueMember = "OgretmenID";
            lueOgretmen.Properties.NullText = "Öğretmen Seçiniz";

            // Kolonları düzenle
            lueOgretmen.Properties.Columns.Clear();
            lueOgretmen.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Ad", 30));
            lueOgretmen.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Soyad", "Soyad", 30));
            lueOgretmen.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Brans", "Branş", 40));
            
            // Popup ayarları
            lueOgretmen.Properties.PopupWidth = 300;
            lueOgretmen.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView.FocusedRowHandle >= 0)
            {
                _secilenId = Convert.ToInt32(gridView.GetFocusedRowCellValue("DersID"));
                var entity = _manager.DersGetir(_secilenId);
                if (entity != null)
                {
                    txtDersAdi.Text = entity.DersAdi;
                    txtDersKodu.Text = entity.DersKodu;
                    lueOgretmen.EditValue = entity.OgretmenID;
                    spnHaftalikSaat.EditValue = entity.HaftalikSaat;
                }
            }
        }

        private void btnYeni_Click(object sender, EventArgs e) => Temizle();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDersAdi.Text))
            {
                XtraMessageBox.Show("Ders adı zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entity = new Ders
            {
                DersID = _secilenId,
                DersAdi = txtDersAdi.Text,
                DersKodu = txtDersKodu.Text,
                OgretmenID = lueOgretmen.EditValue as int?,
                HaftalikSaat = Convert.ToInt32(spnHaftalikSaat.EditValue),
                Durum = true
            };

            try
            {
                if (_secilenId == 0) _manager.DersEkle(entity);
                else _manager.DersGuncelle(entity);
                XtraMessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); Temizle();
            }
            catch (Exception ex) { XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_secilenId == 0) return;
            if (XtraMessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { _manager.DersSil(_secilenId); Listele(); Temizle(); }
        }

        private void Temizle()
        {
            _secilenId = 0;
            txtDersAdi.Text = txtDersKodu.Text = "";
            lueOgretmen.EditValue = null;
            spnHaftalikSaat.EditValue = 3;
        }
    }
}
