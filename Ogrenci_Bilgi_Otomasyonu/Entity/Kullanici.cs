using System;

namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Kullanıcı entity sınıfı - Giriş yapan tüm kullanıcıları temsil eder
    /// </summary>
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public int RolID { get; set; }
        public bool Durum { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        // Navigation property
        public string RolAdi { get; set; }
        public string AdSoyad { get; set; }
    }
}
