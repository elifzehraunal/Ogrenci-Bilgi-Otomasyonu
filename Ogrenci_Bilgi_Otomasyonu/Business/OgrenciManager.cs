using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class OgrenciManager
    {
        private readonly OgrenciDal _dal = new OgrenciDal();
        private readonly KullaniciDal _kullaniciDal = new KullaniciDal();

        public DataTable TumOgrencileriGetir() => _dal.TumOgrencileriGetir();
        public DataTable SinifaGoreOgrencileriGetir(int sinifId) => _dal.SinifaGoreOgrencileriGetir(sinifId);
        public Ogrenci OgrenciGetir(int ogrenciId) => _dal.OgrenciGetir(ogrenciId);
        
        /// <summary>
        /// Öğrenci ekler ve otomatik olarak kullanıcı hesabı oluşturur
        /// Kullanıcı Adı: TC Numarası
        /// Şifre: TC Numarası
        /// Rol: Öğrenci (RolID = 3)
        /// </summary>
        public int OgrenciEkle(Ogrenci ogrenci)
        {
            // Önce kullanıcı hesabı oluştur
            var kullanici = new Kullanici
            {
                KullaniciAdi = ogrenci.TC,  // TC numarası kullanıcı adı olarak
                Sifre = ogrenci.TC,          // TC numarası şifre olarak
                RolID = 3,                   // 3 = Öğrenci rolü
                Durum = true
            };
            
            int kullaniciId = _kullaniciDal.KullaniciEkle(kullanici);
            
            // Öğrenciye kullanıcı ID'sini ata
            ogrenci.KullaniciID = kullaniciId;
            
            // Öğrenciyi ekle
            return _dal.OgrenciEkle(ogrenci);
        }
        
        public void OgrenciGuncelle(Ogrenci ogrenci) => _dal.OgrenciGuncelle(ogrenci);
        public void OgrenciSil(int ogrenciId) => _dal.OgrenciSil(ogrenciId);
        public bool OgrenciNoKontrol(string ogrenciNo, int haricId = 0) => _dal.OgrenciNoKontrol(ogrenciNo, haricId);
        public bool TCKontrol(string tc, int haricId = 0) => _dal.TCKontrol(tc, haricId);
        public string OtomatikNoOlustur() => _dal.OtomatikNoOlustur();
    }
}

