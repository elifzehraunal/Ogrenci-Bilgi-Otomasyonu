using System;

namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Not entity sınıfı - Öğrenci notlarını temsil eder
    /// </summary>
    public class Not
    {
        public int NotID { get; set; }
        public int OgrenciID { get; set; }
        public int DersID { get; set; }
        public decimal? Yazili1 { get; set; }
        public decimal? Yazili2 { get; set; }
        public decimal? Yazili3 { get; set; }
        public decimal? Sozlu1 { get; set; }
        public decimal? Sozlu2 { get; set; }
        public decimal? Performans { get; set; }
        public decimal? Proje { get; set; }
        public decimal? Ortalama { get; set; }
        public string Donem { get; set; }
        public string OgretimYili { get; set; }
        public DateTime KayitTarihi { get; set; }

        // Navigation properties
        public string OgrenciAdi { get; set; }
        public string OgrenciNo { get; set; }
        public string DersAdi { get; set; }
        public string SinifAdi { get; set; }
    }
}
