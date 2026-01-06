using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ogrenci_Bilgi_Otomasyonu.Business;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    public partial class UcDersProgrami : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly DersProgramiManager _manager = new DersProgramiManager();
        private readonly SinifManager _sinifManager = new SinifManager();
        private TableLayoutPanel tblSchedule;
        private int _secilenSinifId = 0;

        private readonly Color[] DersRenkleri = new Color[]
        {
            Color.FromArgb(66, 133, 244),
            Color.FromArgb(52, 168, 83),
            Color.FromArgb(251, 188, 4),
            Color.FromArgb(234, 67, 53),
            Color.FromArgb(103, 58, 183),
            Color.FromArgb(0, 172, 193),
            Color.FromArgb(255, 112, 67),
            Color.FromArgb(156, 39, 176),
            Color.FromArgb(0, 150, 136),
            Color.FromArgb(121, 85, 72)
        };

        private Dictionary<string, Color> _dersRenkMap = new Dictionary<string, Color>();

        public UcDersProgrami()
        {
            InitializeComponent();
            this.Load += UcDersProgrami_Load;
        }

        private void UcDersProgrami_Load(object sender, EventArgs e)
        {
            SiniflariYukle();
            YetkileriAyarla();
        }

        private void YetkileriAyarla()
        {
            var kullanici = FrmGiris.AktifKullanici;
            if (kullanici == null) return;

            switch (kullanici.RolID)
            {
                case 1:
                    pnlFiltre.Visible = true;
                    lblBaslik.Text = "📅 HAFTALIK DERS PROGRAMI";
                    break;
                case 2:
                    pnlFiltre.Visible = false;
                    lblBaslik.Text = "📅 DERS PROGRAMIM - ÖĞRETMEN";
                    OgretmenPrograminiGoster(kullanici.KullaniciID);
                    break;
                case 3:
                    pnlFiltre.Visible = false;
                    lblBaslik.Text = "📅 DERS PROGRAMIM";
                    OgrenciPrograminiGoster(kullanici.KullaniciID);
                    break;
            }
        }

        private void SiniflariYukle()
        {
            var siniflar = _sinifManager.SinifListesiGetir();
            lueSinifFiltre.Properties.DataSource = siniflar;
            lueSinifFiltre.Properties.DisplayMember = "SinifAdi";
            lueSinifFiltre.Properties.ValueMember = "SinifID";
        }

        private void lueSinifFiltre_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSinifFiltre.EditValue != null)
            {
                _secilenSinifId = Convert.ToInt32(lueSinifFiltre.EditValue);
                var sinifAdi = lueSinifFiltre.Text;
                lblBaslik.Text = "📅 DERS PROGRAMI - " + sinifAdi;
                ProgramiGoster(_manager.SinifProgramiGetir(_secilenSinifId));
            }
        }

        private void OgretmenPrograminiGoster(int kullaniciId)
        {
            ProgramiGoster(_manager.OgretmenProgramiGetir(kullaniciId));
        }

        private void OgrenciPrograminiGoster(int kullaniciId)
        {
            ProgramiGoster(_manager.OgrenciProgramiGetir(kullaniciId));
        }

        private void ProgramiGoster(List<DersProgrami> programlar)
        {
            pnlSchedule.Controls.Clear();
            _dersRenkMap.Clear();

            tblSchedule = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // 6 sütun: Saat + 5 gün
            tblSchedule.ColumnCount = 6;
            tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            for (int i = 0; i < 5; i++)
                tblSchedule.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            // 6 satır: Başlık + 5 ders saati
            tblSchedule.RowCount = 6;
            tblSchedule.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            for (int i = 0; i < 5; i++)
                tblSchedule.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            // Başlık satırı
            string[] gunler = { "SAAT", "PAZARTESİ", "SALI", "ÇARŞAMBA", "PERŞEMBE", "CUMA" };
            for (int col = 0; col < 6; col++)
            {
                var lbl = CreateHeaderLabel(gunler[col]);
                tblSchedule.Controls.Add(lbl, col, 0);
            }

            // Saat sütunu - 5 ders
            string[,] saatler = {
                { "1", "08:30", "09:10" },
                { "2", "09:20", "10:00" },
                { "3", "10:10", "10:50" },
                { "4", "11:00", "11:40" },
                { "5", "12:30", "13:10" }
            };

            for (int row = 0; row < 5; row++)
            {
                var lblSaat = CreateTimeLabel(saatler[row, 0] + ". Ders\n" + saatler[row, 1] + "\n" + saatler[row, 2]);
                tblSchedule.Controls.Add(lblSaat, 0, row + 1);
            }

            // Boş hücreler
            for (int row = 1; row <= 5; row++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    tblSchedule.Controls.Add(CreateEmptyCell(), col, row);
                }
            }

            // Renk ataması
            int renkIndex = 0;
            foreach (var program in programlar)
            {
                if (program.DersAdi != null && !_dersRenkMap.ContainsKey(program.DersAdi))
                {
                    _dersRenkMap[program.DersAdi] = DersRenkleri[renkIndex % DersRenkleri.Length];
                    renkIndex++;
                }
            }

            // Dersleri yerleştir
            foreach (var program in programlar)
            {
                int col = GunSutunu(program.Gun);
                int row = program.DersSaati;

                if (col > 0 && row > 0 && row <= 5)
                {
                    var control = tblSchedule.GetControlFromPosition(col, row);
                    if (control != null) tblSchedule.Controls.Remove(control);
                    tblSchedule.Controls.Add(CreateLessonPanel(program), col, row);
                }
            }

            pnlSchedule.Controls.Add(tblSchedule);
        }

        private int GunSutunu(string gun)
        {
            if (gun == null) return 0;
            switch (gun)
            {
                case "Pazartesi": return 1;
                case "Salı": return 2;
                case "Çarşamba": return 3;
                case "Perşembe": return 4;
                case "Cuma": return 5;
                default: return 0;
            }
        }

        private Label CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Margin = new Padding(0)
            };
        }

        private Label CreateTimeLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(232, 234, 246),
                ForeColor = Color.FromArgb(63, 81, 181),
                Margin = new Padding(0)
            };
        }

        private Panel CreateEmptyCell()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(250, 250, 250),
                Margin = new Padding(0)
            };
        }

        private Panel CreateLessonPanel(DersProgrami program)
        {
            Color renk = Color.FromArgb(66, 133, 244);
            if (program.DersAdi != null && _dersRenkMap.ContainsKey(program.DersAdi))
            {
                renk = _dersRenkMap[program.DersAdi];
            }

            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = renk,
                Margin = new Padding(1),
                Cursor = Cursors.Hand
            };

            var lblDers = new Label
            {
                Text = program.DersAdi ?? "Ders",
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnl.Controls.Add(lblDers);

            var kullanici = FrmGiris.AktifKullanici;
            string altBilgi = "";
            if (kullanici != null && kullanici.RolID == 2)
            {
                altBilgi = program.SinifAdi ?? "";
            }
            else
            {
                altBilgi = program.OgretmenAdi ?? "";
            }

            var lblAlt = new Label
            {
                Text = altBilgi,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(230, 230, 230),
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnl.Controls.Add(lblAlt);

            return pnl;
        }
    }
}
