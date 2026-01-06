using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class KullaniciManager
    {
        private readonly KullaniciDal _dal = new KullaniciDal();

        public Kullanici GirisYap(string kullaniciAdi, string sifre)
        {
            var kullanici = _dal.GirisKontrol(kullaniciAdi, sifre);
            if (kullanici != null)
            {
                _dal.SonGirisTarihiGuncelle(kullanici.KullaniciID);
            }
            return kullanici;
        }

        public DataTable TumKullanicilariGetir() => _dal.TumKullanicilariGetir();
        public int KullaniciEkle(Kullanici kullanici) => _dal.KullaniciEkle(kullanici);
        public void KullaniciGuncelle(Kullanici kullanici) => _dal.KullaniciGuncelle(kullanici);
        public void KullaniciSil(int kullaniciId) => _dal.KullaniciSil(kullaniciId);

        public Kullanici GirisKontrol(string kullaniciAdi, string sifre) => _dal.GirisKontrol(kullaniciAdi, sifre);
        public void SifreDegistir(int kullaniciId, string yeniSifre) => _dal.SifreDegistir(kullaniciId, yeniSifre);
    }
}
