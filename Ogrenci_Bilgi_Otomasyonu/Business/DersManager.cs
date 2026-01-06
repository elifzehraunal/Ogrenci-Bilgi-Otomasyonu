using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class DersManager
    {
        private readonly DersDal _dal = new DersDal();

        public DataTable TumDersleriGetir() => _dal.TumDersleriGetir();
        public DataTable DersListesiGetir() => _dal.DersListesiGetir();
        public DataTable OgretmenDersleriniGetir(int kullaniciId) => _dal.OgretmenDersleriniGetir(kullaniciId);
        public Ders DersGetir(int dersId) => _dal.DersGetir(dersId);
        public int DersEkle(Ders ders) => _dal.DersEkle(ders);
        public void DersGuncelle(Ders ders) => _dal.DersGuncelle(ders);
        public void DersSil(int dersId) => _dal.DersSil(dersId);
    }
}
