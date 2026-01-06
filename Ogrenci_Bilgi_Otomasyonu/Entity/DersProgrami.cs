using System;

namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    public class DersProgrami
    {
        public int ProgramID { get; set; }
        public int SinifID { get; set; }
        public int DersID { get; set; }
        public int OgretmenID { get; set; }
        public string Gun { get; set; }
        public int DersSaati { get; set; }
        public string BaslangicSaatiStr { get; set; }
        public string BitisSaatiStr { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public bool Durum { get; set; }

        // Navigation Properties
        public string SinifAdi { get; set; }
        public string DersAdi { get; set; }
        public string OgretmenAdi { get; set; }
    }
}
