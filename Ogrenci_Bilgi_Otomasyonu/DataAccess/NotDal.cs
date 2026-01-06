using System;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    public class NotDal
    {
        public DataTable TumNotlariGetir()
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT n.NotID, o.OgrenciNo, o.Ad + ' ' + o.Soyad AS OgrenciAdi,
                                 d.DersAdi, s.SinifAdi, n.Yazili1, n.Yazili2, n.Yazili3,
                                 n.Sozlu1, n.Sozlu2, n.Ortalama, n.Donem, n.OgretimYili
                                 FROM TBL_Notlar n
                                 INNER JOIN TBL_Ogrenciler o ON n.OgrenciID = o.OgrenciID
                                 INNER JOIN TBL_Dersler d ON n.DersID = d.DersID
                                 LEFT JOIN TBL_Siniflar s ON o.SinifID = s.SinifID
                                 ORDER BY o.OgrenciNo, d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable OgretmenNotlariGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                // Sadece öğretmenin kendi derslerine ait notları getir
                string sorgu = @"SELECT n.NotID, o.OgrenciNo, o.Ad + ' ' + o.Soyad AS OgrenciAdi,
                                 d.DersAdi, s.SinifAdi, n.Yazili1, n.Yazili2, n.Yazili3,
                                 n.Sozlu1, n.Sozlu2, n.Ortalama, n.Donem, n.OgretimYili
                                 FROM TBL_Notlar n
                                 INNER JOIN TBL_Ogrenciler o ON n.OgrenciID = o.OgrenciID
                                 INNER JOIN TBL_Dersler d ON n.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler ogr ON d.OgretmenID = ogr.OgretmenID
                                 LEFT JOIN TBL_Siniflar s ON o.SinifID = s.SinifID
                                 WHERE ogr.KullaniciID = @KullaniciID
                                 ORDER BY o.OgrenciNo, d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable OgrenciNotlariGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                // Öğrencinin notlarını getir - öğretmen bilgisi TBL_Dersler'den
                string sorgu = @"SELECT n.NotID, d.DersAdi, n.Yazili1, n.Yazili2, n.Yazili3,
                                 n.Sozlu1, n.Sozlu2, n.Ortalama, n.Donem, n.OgretimYili,
                                 ISNULL(og.Ad + ' ' + og.Soyad, '-') AS OgretmenAdi
                                 FROM TBL_Notlar n
                                 INNER JOIN TBL_Dersler d ON n.DersID = d.DersID
                                 INNER JOIN TBL_Ogrenciler o ON n.OgrenciID = o.OgrenciID
                                 LEFT JOIN TBL_Ogretmenler og ON d.OgretmenID = og.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID
                                 ORDER BY d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable OgrenciNotlariGetirById(int ogrenciId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT n.NotID, n.OgrenciID, n.DersID, d.DersAdi, 
                                 n.Yazili1, n.Yazili2, n.Yazili3,
                                 n.Sozlu1, n.Sozlu2, n.Ortalama, n.Donem, n.OgretimYili
                                 FROM TBL_Notlar n
                                 INNER JOIN TBL_Dersler d ON n.DersID = d.DersID
                                 WHERE n.OgrenciID = @OgrenciID
                                 ORDER BY d.DersAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@OgrenciID", ogrenciId);
                da.Fill(dt);
            }
            return dt;
        }


        public int NotEkle(Not not)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Notlar 
                    (OgrenciID, DersID, Yazili1, Yazili2, Yazili3, Sozlu1, Sozlu2, Performans, Proje, Donem, OgretimYili)
                    VALUES (@OgrenciID, @DersID, @Yazili1, @Yazili2, @Yazili3, @Sozlu1, @Sozlu2, @Performans, @Proje, @Donem, @OgretimYili);
                    SELECT SCOPE_IDENTITY();";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgrenciID", not.OgrenciID);
                komut.Parameters.AddWithValue("@DersID", not.DersID);
                komut.Parameters.AddWithValue("@Yazili1", not.Yazili1 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Yazili2", not.Yazili2 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Yazili3", not.Yazili3 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Sozlu1", not.Sozlu1 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Sozlu2", not.Sozlu2 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Performans", not.Performans ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Proje", not.Proje ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Donem", not.Donem ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@OgretimYili", not.OgretimYili ?? (object)DBNull.Value);
                baglanti.Open();
                return Convert.ToInt32(komut.ExecuteScalar());
            }
        }

        public void NotGuncelle(Not not)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_Notlar SET
                    Yazili1=@Yazili1, Yazili2=@Yazili2, Yazili3=@Yazili3,
                    Sozlu1=@Sozlu1, Sozlu2=@Sozlu2, Performans=@Performans,
                    Proje=@Proje, Donem=@Donem, OgretimYili=@OgretimYili
                    WHERE NotID=@NotID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@NotID", not.NotID);
                komut.Parameters.AddWithValue("@Yazili1", not.Yazili1 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Yazili2", not.Yazili2 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Yazili3", not.Yazili3 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Sozlu1", not.Sozlu1 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Sozlu2", not.Sozlu2 ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Performans", not.Performans ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Proje", not.Proje ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Donem", not.Donem ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@OgretimYili", not.OgretimYili ?? (object)DBNull.Value);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        public void NotSil(int notId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "DELETE FROM TBL_Notlar WHERE NotID = @NotID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@NotID", notId);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}
