using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class SinifDersOgretmenManager
    {
        private readonly SinifDersOgretmenDal _dal = new SinifDersOgretmenDal();

        public DataTable TumAtamalariGetir()
        {
            return _dal.TumAtamalariGetir();
        }

        public DataTable SinifAtamalariniGetir(int sinifId)
        {
            return _dal.SinifAtamalariniGetir(sinifId);
        }

        public DataTable OgretmenAtamalariniGetir(int kullaniciId)
        {
            return _dal.OgretmenAtamalariniGetir(kullaniciId);
        }

        public DataTable OgretmenSiniflariniGetir(int kullaniciId)
        {
            return _dal.OgretmenSiniflariniGetir(kullaniciId);
        }

        public DataTable OgretmenSinifDersleriniGetir(int kullaniciId, int sinifId)
        {
            return _dal.OgretmenSinifDersleriniGetir(kullaniciId, sinifId);
        }

        public void AtamaEkle(SinifDersOgretmen entity)
        {
            _dal.AtamaEkle(entity);
        }

        public void AtamaGuncelle(SinifDersOgretmen entity)
        {
            _dal.AtamaGuncelle(entity);
        }

        public void AtamaSil(int id)
        {
            _dal.AtamaSil(id);
        }
    }
}
