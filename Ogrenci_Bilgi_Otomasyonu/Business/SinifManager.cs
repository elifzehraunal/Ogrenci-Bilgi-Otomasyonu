using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class SinifManager
    {
        private readonly SinifDal _dal = new SinifDal();

        public DataTable TumSiniflariGetir() => _dal.TumSiniflariGetir();
        public DataTable SinifListesiGetir() => _dal.SinifListesiGetir();
        public void SinifEkle(string sinifAdi, int kapasite) => _dal.SinifEkle(sinifAdi, kapasite);
        public void SinifSil(int sinifId) => _dal.SinifSil(sinifId);
    }
}
