using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcOtomatikDersProgrami : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DersProgramiOlusturucu _olusturucu = new DersProgramiOlusturucu();
        private readonly DersProgramiManager _manager = new DersProgramiManager();
        private readonly SinifManager _sinifManager = new SinifManager();
        private readonly DersManager _dersManager = new DersManager();
        private readonly OgretmenManager _ogretmenManager = new OgretmenManager();

        private List<DersProgrami> _olusturulanProgram;
        private DataTable _siniflar;
        private DataTable _dersler;
        private DataTable _ogretmenler;

        // 5 ders saati
        private readonly string[] _saatler = { "08:30-09:10", "09:20-10:00", "10:10-10:50", "11:00-11:40", "12:30-13:10" };
        private readonly string[] _gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };

        public UcOtomatikDersProgrami()
        {
            InitializeComponent();
            this.Load += UcOtomatikDersProgrami_Load;
        }

        private void UcOtomatikDersProgrami_Load(object sender, EventArgs e)
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null || kullanici.RolID != 1)
            {
                XtraMessageBox.Show("Bu özellik sadece yöneticiler için kullanılabilir!", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            VerileriYukle();
            lblDurum.Text = "Program oluşturmak için 'Otomatik Oluştur' butonuna tıklayın.";
        }

        private void VerileriYukle()
        {
            _siniflar = _sinifManager.SinifListesiGetir();
            _dersler = _dersManager.DersListesiGetir();
            _ogretmenler = _ogretmenManager.OgretmenListesiGetir();

            lblSinifSayisi.Text = _siniflar.Rows.Count.ToString();
            lblDersSayisi.Text = _dersler.Rows.Count.ToString();
            lblOgretmenSayisi.Text = _ogretmenler.Rows.Count.ToString();
        }

        private async void btnOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                btnOlustur.Enabled = false;
                lblDurum.Text = "Program oluşturuluyor...";
                progressBar.Visible = true;
                Application.DoEvents();

                // Yerel algoritma ile oluştur
                _olusturulanProgram = _olusturucu.YerelProgramOlustur();

                if (_olusturulanProgram == null || _olusturulanProgram.Count == 0)
                {
                    lblDurum.Text = "Program oluşturulamadı veya boş!";
                    lblDurum.ForeColor = Color.Red;
                    return;
                }

                var cakismalar = _olusturucu.CakismaKontrol(_olusturulanProgram);
                
                if (cakismalar.Count > 0)
                {
                    lblDurum.Text = cakismalar.Count + " çakışma tespit edildi!";
                    lblDurum.ForeColor = Color.Orange;
                }
                else
                {
                    lblDurum.Text = "Program başarıyla oluşturuldu! (" + _olusturulanProgram.Count + " ders slotu)";
                    lblDurum.ForeColor = Color.Green;
                }

                ProgramiGoruntule();

                btnOnayla.Enabled = true;
                btnYenidenOlustur.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDurum.Text = "Program oluşturulurken hata oluştu!";
            }
            finally
            {
                btnOlustur.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void ProgramiGoruntule()
        {
            tabSiniflar.TabPages.Clear();

            foreach (DataRow sinifRow in _siniflar.Rows)
            {
                int sinifId = Convert.ToInt32(sinifRow["SinifID"]);
                string sinifAdi = sinifRow["SinifAdi"].ToString();

                var tab = new TabPage(sinifAdi);
                var tablo = SinifTablosuOlustur(sinifId);
                tablo.Dock = DockStyle.Fill;
                tab.Controls.Add(tablo);
                tabSiniflar.TabPages.Add(tab);
            }
        }

        private TableLayoutPanel SinifTablosuOlustur(int sinifId)
        {
            var tablo = new TableLayoutPanel
            {
                ColumnCount = 6,
                RowCount = _saatler.Length + 1,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };

            tablo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            for (int i = 0; i < 5; i++)
                tablo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            // Header satırı
            tablo.Controls.Add(BaslikOlustur("Saat"), 0, 0);
            for (int i = 0; i < _gunler.Length; i++)
                tablo.Controls.Add(BaslikOlustur(_gunler[i]), i + 1, 0);

            // Saat satırları
            for (int s = 0; s < _saatler.Length; s++)
            {
                tablo.Controls.Add(SaatHucresiOlustur(_saatler[s]), 0, s + 1);

                for (int g = 0; g < _gunler.Length; g++)
                {
                    DersProgrami slot = null;
                    if (_olusturulanProgram != null)
                    {
                        int dersSaati = s + 1;
                        foreach (var p in _olusturulanProgram)
                        {
                            if (p.SinifID == sinifId && p.Gun == _gunler[g] && p.DersSaati == dersSaati)
                            {
                                slot = p;
                                break;
                            }
                        }
                    }

                    if (slot != null)
                    {
                        string dersAdi = "";
                        string ogretmenAdi = "";

                        foreach (DataRow d in _dersler.Rows)
                        {
                            if (Convert.ToInt32(d["DersID"]) == slot.DersID)
                            {
                                dersAdi = d["DersAdi"].ToString();
                                break;
                            }
                        }

                        foreach (DataRow o in _ogretmenler.Rows)
                        {
                            if (Convert.ToInt32(o["OgretmenID"]) == slot.OgretmenID)
                            {
                                ogretmenAdi = o["AdSoyad"].ToString();
                                break;
                            }
                        }

                        tablo.Controls.Add(DersHucresiOlustur(dersAdi, ogretmenAdi, slot.DersID), g + 1, s + 1);
                    }
                    else
                    {
                        tablo.Controls.Add(BosHucresiOlustur(), g + 1, s + 1);
                    }
                }
            }

            return tablo;
        }

        private Label BaslikOlustur(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
        }

        private Label SaatHucresiOlustur(string saat)
        {
            return new Label
            {
                Text = saat,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(232, 234, 246),
                Font = new Font("Segoe UI", 9)
            };
        }

        private Panel DersHucresiOlustur(string dersAdi, string ogretmenAdi, int dersId)
        {
            var renkler = new Color[]
            {
                Color.FromArgb(76, 175, 80), Color.FromArgb(33, 150, 243), Color.FromArgb(255, 152, 0),
                Color.FromArgb(156, 39, 176), Color.FromArgb(0, 150, 136), Color.FromArgb(244, 67, 54)
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = renkler[dersId % renkler.Length],
                Padding = new Padding(3)
            };

            var lbl = new Label
            {
                Text = dersAdi + "\n" + ogretmenAdi,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            panel.Controls.Add(lbl);
            return panel;
        }

        private Label BosHucresiOlustur()
        {
            return new Label
            {
                Text = "",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(250, 250, 250)
            };
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (_olusturulanProgram == null || _olusturulanProgram.Count == 0)
            {
                XtraMessageBox.Show("Önce program oluşturmanız gerekiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cevap = XtraMessageBox.Show(
                "Oluşturulan " + _olusturulanProgram.Count + " ders slotu veritabanına kaydedilecek.\n\n" +
                "Mevcut ders programı silinecek ve yenisi eklenecektir.\n\nOnaylıyor musunuz?",
                "Program Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    // Mevcut programı sil
                    _manager.TumProgramiSil();

                    // Yeni programı ekle
                    int eklenen = 0;
                    foreach (var slot in _olusturulanProgram)
                    {
                        _manager.DersProgramiEkle(slot);
                        eklenen++;
                    }

                    XtraMessageBox.Show(
                        "Ders programı başarıyla kaydedildi!\n\nToplam " + eklenen + " ders slotu eklendi.",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    lblDurum.Text = "Program onaylandı ve kaydedildi!";
                    lblDurum.ForeColor = Color.Green;
                    btnOnayla.Enabled = false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnYenidenOlustur_Click(object sender, EventArgs e)
        {
            _olusturulanProgram = null;
            tabSiniflar.TabPages.Clear();
            lblDurum.Text = "Program yeniden oluşturmak için 'Otomatik Oluştur' butonuna tıklayın.";
            lblDurum.ForeColor = Color.Black;
            btnOnayla.Enabled = false;
        }
    }
}
