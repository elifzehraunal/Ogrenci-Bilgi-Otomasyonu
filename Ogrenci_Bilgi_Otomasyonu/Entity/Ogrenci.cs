using System;

namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Öğrenci entity sınıfı - Veli bilgileri dahil
    /// </summary>
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        public int? KullaniciID { get; set; }
        public string OgrenciNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int? SinifID { get; set; }

        // Veli Bilgileri
        public string VeliAdi { get; set; }
        public string VeliSoyadi { get; set; }
        public string VeliTelefon { get; set; }
        public string VeliEmail { get; set; }
        public string VeliMeslek { get; set; }
        public string VeliAdres { get; set; }

        // Kayıt Bilgileri
        public DateTime KayitTarihi { get; set; }
        public bool Durum { get; set; }
        public string FotoUrl { get; set; }

        // Navigation properties
        public string SinifAdi { get; set; }
        public string AdSoyad => $"{Ad} {Soyad}";
    }
}
