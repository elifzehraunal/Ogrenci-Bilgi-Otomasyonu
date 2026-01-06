namespace Ogrenci_Bilgi_Otomasyonu.Entity
{
    public class SinifDersOgretmen
    {
        public int ID { get; set; }
        public int SinifID { get; set; }
        public int DersID { get; set; }
        public int OgretmenID { get; set; }

        // Joined fields
        public string SinifAdi { get; set; }
        public string DersAdi { get; set; }
        public string OgretmenAdi { get; set; }
    }
}
