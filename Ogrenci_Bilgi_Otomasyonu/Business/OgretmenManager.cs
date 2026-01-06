using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class OgretmenManager
    {
        private readonly OgretmenDal _dal = new OgretmenDal();
        private readonly KullaniciDal _kullaniciDal = new KullaniciDal();

        public DataTable TumOgretmenleriGetir() => _dal.TumOgretmenleriGetir();
        public DataTable OgretmenListesiGetir() => _dal.OgretmenListesiGetir();
        public Ogretmen OgretmenGetir(int ogretmenId) => _dal.OgretmenGetir(ogretmenId);
        
        /// <summary>
        /// Öğretmen ekler ve otomatik olarak kullanıcı hesabı oluşturur
        /// Kullanıcı Adı: TC Numarası
        /// Şifre: TC Numarası
        /// Rol: Öğretmen (RolID = 2)
        /// </summary>
        public int OgretmenEkle(Ogretmen ogretmen)
        {
            // Önce kullanıcı hesabı oluştur
            var kullanici = new Kullanici
            {
                KullaniciAdi = ogretmen.TC,  // TC numarası kullanıcı adı olarak
                Sifre = ogretmen.TC,          // TC numarası şifre olarak
                RolID = 2,                    // 2 = Öğretmen rolü
                Durum = true
            };
            
            int kullaniciId = _kullaniciDal.KullaniciEkle(kullanici);
            
            // Öğretmene kullanıcı ID'sini ata
            ogretmen.KullaniciID = kullaniciId;
            
            // Öğretmeni ekle
            return _dal.OgretmenEkle(ogretmen);
        }
        
        public void OgretmenGuncelle(Ogretmen ogretmen) => _dal.OgretmenGuncelle(ogretmen);
        public void OgretmenSil(int ogretmenId) => _dal.OgretmenSil(ogretmenId);
    }
}

