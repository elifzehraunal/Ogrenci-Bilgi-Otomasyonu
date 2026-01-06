using System;

namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Öğretmen entity sınıfı
    /// </summary>
    public class Ogretmen
    {
        public int OgretmenID { get; set; }
        public int? KullaniciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Brans { get; set; }
        public DateTime? BaslamaTarihi { get; set; }
        public bool Durum { get; set; }
        public string FotoUrl { get; set; }

        // Navigation properties
        public string AdSoyad => $"{Ad} {Soyad}";
    }
}
