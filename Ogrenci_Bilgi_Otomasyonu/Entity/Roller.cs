namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    /// <summary>
    /// Rol entity sınıfı - Yönetici, Öğretmen, Öğrenci rollerini temsil eder
    /// </summary>
    public class Roller
    {
        public int RolID { get; set; }
        public string RolAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
