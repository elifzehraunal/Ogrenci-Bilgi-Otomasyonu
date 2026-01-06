namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Ders entity sınıfı
    /// </summary>
    public class Ders
    {
        public int DersID { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public int? OgretmenID { get; set; }
        public int HaftalikSaat { get; set; }
        public int Kredi { get; set; }
        public bool Durum { get; set; }

        // Navigation properties
        public string OgretmenAdi { get; set; }
    }
}
