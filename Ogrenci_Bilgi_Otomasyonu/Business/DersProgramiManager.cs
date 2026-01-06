using System.Collections.Generic;
using System.Data;
using Ogrenci_Bilgi_Otomasyonu.DataAccess;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class DersProgramiManager
    {
        private readonly DersProgramiDal _dal = new DersProgramiDal();

        public List<DersProgrami> TumProgramlariGetir()
        {
            return _dal.TumProgramlariGetir();
        }

        public List<DersProgrami> SinifProgramiGetir(int sinifId)
        {
            return _dal.SinifProgramiGetir(sinifId);
        }

        public List<DersProgrami> OgretmenProgramiGetir(int kullaniciId)
        {
            return _dal.OgretmenProgramiGetir(kullaniciId);
        }

        public List<DersProgrami> OgrenciProgramiGetir(int kullaniciId)
        {
            return _dal.OgrenciProgramiGetir(kullaniciId);
        }

        public int ProgramEkle(DersProgrami entity)
        {
            return _dal.ProgramEkle(entity);
        }

        public void ProgramGuncelle(DersProgrami entity)
        {
            _dal.ProgramGuncelle(entity);
        }

        public void ProgramSil(int programId)
        {
            _dal.ProgramSil(programId);
        }

        public void TumProgramiSil()
        {
            _dal.TumProgramiSil();
        }

        public void DersProgramiEkle(DersProgrami entity)
        {
            _dal.DersProgramiEkle(entity);
        }

        // Öğretmenin ders verdiği sınıfları getirir
        public DataTable OgretmenSiniflariniGetir(int kullaniciId)
        {
            return _dal.OgretmenSiniflariniGetir(kullaniciId);
        }

        // Öğretmenin belirli bir sınıfta verdiği dersleri getirir
        public DataTable OgretmenSinifDersleriniGetir(int kullaniciId, int sinifId)
        {
            return _dal.OgretmenSinifDersleriniGetir(kullaniciId, sinifId);
        }
    }
}
