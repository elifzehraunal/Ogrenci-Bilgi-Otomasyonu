namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Sınıf entity sınıfı - Okul sınıflarını temsil eder (5-A, 6-B vb.)
    /// </summary>
    public class Sinif
    {
        public int SinifID { get; set; }
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }
        public bool Durum { get; set; }
    }
}
