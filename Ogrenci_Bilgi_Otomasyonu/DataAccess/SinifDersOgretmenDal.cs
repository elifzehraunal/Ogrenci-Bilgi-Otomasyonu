using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    public class SinifDersOgretmenDal
    {
        /// <summary>
        /// Tüm sınıf-ders-öğretmen atamalarını getirir
        /// </summary>
        public DataTable TumAtamalariGetir()
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT sdo.ID, sdo.SinifID, sdo.DersID, sdo.OgretmenID,
                                 s.SinifAdi, d.DersAdi, 
                                 o.Ad + ' ' + o.Soyad AS OgretmenAdi
                                 FROM TBL_SinifDersOgretmen sdo
                                 INNER JOIN TBL_Siniflar s ON sdo.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON sdo.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON sdo.OgretmenID = o.OgretmenID
                                 ORDER BY s.SinifAdi, d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Sınıfa göre ders-öğretmen atamalarını getirir
        /// </summary>
        public DataTable SinifAtamalariniGetir(int sinifId)
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT sdo.ID, sdo.SinifID, sdo.DersID, sdo.OgretmenID,
                                 s.SinifAdi, d.DersAdi, 
                                 o.Ad + ' ' + o.Soyad AS OgretmenAdi
                                 FROM TBL_SinifDersOgretmen sdo
                                 INNER JOIN TBL_Siniflar s ON sdo.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON sdo.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON sdo.OgretmenID = o.OgretmenID
                                 WHERE sdo.SinifID = @SinifID
                                 ORDER BY d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                da.SelectCommand.Parameters.AddWithValue("@SinifID", sinifId);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Öğretmenin atandığı sınıf-dersleri getirir
        /// </summary>
        public DataTable OgretmenAtamalariniGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT sdo.ID, sdo.SinifID, sdo.DersID, sdo.OgretmenID,
                                 s.SinifAdi, d.DersAdi
                                 FROM TBL_SinifDersOgretmen sdo
                                 INNER JOIN TBL_Siniflar s ON sdo.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON sdo.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON sdo.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID
                                 ORDER BY s.SinifAdi, d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Öğretmenin girdiği sınıfları getirir
        /// </summary>
        public DataTable OgretmenSiniflariniGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT DISTINCT sdo.SinifID, s.SinifAdi
                                 FROM TBL_SinifDersOgretmen sdo
                                 INNER JOIN TBL_Siniflar s ON sdo.SinifID = s.SinifID
                                 INNER JOIN TBL_Ogretmenler o ON sdo.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID
                                 ORDER BY s.SinifAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Öğretmenin belirli bir sınıfta verdiği dersleri getirir
        /// </summary>
        public DataTable OgretmenSinifDersleriniGetir(int kullaniciId, int sinifId)
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT sdo.DersID, d.DersAdi
                                 FROM TBL_SinifDersOgretmen sdo
                                 INNER JOIN TBL_Dersler d ON sdo.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON sdo.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID AND sdo.SinifID = @SinifID
                                 ORDER BY d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                da.SelectCommand.Parameters.AddWithValue("@SinifID", sinifId);
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Atama ekle
        /// </summary>
        public void AtamaEkle(SinifDersOgretmen entity)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_SinifDersOgretmen (SinifID, DersID, OgretmenID)
                                 VALUES (@SinifID, @DersID, @OgretmenID)";
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@SinifID", entity.SinifID);
                cmd.Parameters.AddWithValue("@DersID", entity.DersID);
                cmd.Parameters.AddWithValue("@OgretmenID", entity.OgretmenID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Atama güncelle
        /// </summary>
        public void AtamaGuncelle(SinifDersOgretmen entity)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_SinifDersOgretmen 
                                 SET OgretmenID = @OgretmenID
                                 WHERE SinifID = @SinifID AND DersID = @DersID";
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@SinifID", entity.SinifID);
                cmd.Parameters.AddWithValue("@DersID", entity.DersID);
                cmd.Parameters.AddWithValue("@OgretmenID", entity.OgretmenID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Atama sil
        /// </summary>
        public void AtamaSil(int id)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM TBL_SinifDersOgretmen WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
