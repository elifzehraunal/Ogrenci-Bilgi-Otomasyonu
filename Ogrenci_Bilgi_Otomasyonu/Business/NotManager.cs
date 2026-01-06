using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class NotManager
    {
        private readonly NotDal _dal = new NotDal();

        public DataTable TumNotlariGetir()
        {
            return _dal.TumNotlariGetir();
        }

        public DataTable OgretmenNotlariGetir(int kullaniciId)
        {
            return _dal.OgretmenNotlariGetir(kullaniciId);
        }

        public DataTable OgrenciNotlariGetir(int kullaniciId)
        {
            return _dal.OgrenciNotlariGetir(kullaniciId);
        }

        public DataTable OgrenciNotlariGetirById(int ogrenciId)
        {
            return _dal.OgrenciNotlariGetirById(ogrenciId);
        }

        public int NotEkle(Not not)
        {
            return _dal.NotEkle(not);
        }

        public void NotGuncelle(Not not)
        {
            _dal.NotGuncelle(not);
        }

        public void NotSil(int notId)
        {
            _dal.NotSil(notId);
        }
    }
}
