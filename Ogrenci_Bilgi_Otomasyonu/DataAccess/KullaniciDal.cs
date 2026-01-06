using System;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    /// <summary>
    /// Kullanıcı veri erişim katmanı - Login ve kullanıcı işlemleri
    /// </summary>
    public class KullaniciDal
    {
        /// <summary>
        /// Kullanıcı girişini kontrol eder
        /// </summary>
        /// <param name="kullaniciAdi">Kullanıcı adı</param>
        /// <param name="sifre">Şifre</param>
        /// <returns>Başarılıysa Kullanici nesnesi, değilse null</returns>
        public Kullanici GirisKontrol(string kullaniciAdi, string sifre)
        {
            Kullanici kullanici = null;

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                // Hem öğrenci hem öğretmen tablosundan isim bilgisini getir
                string sorgu = @"SELECT k.KullaniciID, k.KullaniciAdi, k.Sifre, k.RolID, k.Durum, 
                                        k.SonGirisTarihi, k.OlusturmaTarihi, r.RolAdi,
                                        COALESCE(og.Ad + ' ' + og.Soyad, ogr.Ad + ' ' + ogr.Soyad, k.KullaniciAdi) AS AdSoyad
                                 FROM TBL_Kullanicilar k
                                 INNER JOIN TBL_Roller r ON k.RolID = r.RolID
                                 LEFT JOIN TBL_Ogrenciler ogr ON k.KullaniciID = ogr.KullaniciID
                                 LEFT JOIN TBL_Ogretmenler og ON k.KullaniciID = og.KullaniciID
                                 WHERE k.KullaniciAdi = @KullaniciAdi AND k.Sifre = @Sifre AND k.Durum = 1";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", sifre);

                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    kullanici = new Kullanici
                    {
                        KullaniciID = Convert.ToInt32(dr["KullaniciID"]),
                        KullaniciAdi = dr["KullaniciAdi"].ToString(),
                        Sifre = dr["Sifre"].ToString(),
                        RolID = Convert.ToInt32(dr["RolID"]),
                        Durum = Convert.ToBoolean(dr["Durum"]),
                        SonGirisTarihi = dr["SonGirisTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["SonGirisTarihi"]) : (DateTime?)null,
                        OlusturmaTarihi = dr["OlusturmaTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["OlusturmaTarihi"]) : DateTime.Now,
                        RolAdi = dr["RolAdi"].ToString(),
                        AdSoyad = dr["AdSoyad"].ToString()
                    };
                }
            }

            return kullanici;
        }

        /// <summary>
        /// Kullanıcının son giriş tarihini günceller
        /// </summary>
        public void SonGirisTarihiGuncelle(int kullaniciId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Kullanicilar SET SonGirisTarihi = @Tarih WHERE KullaniciID = @ID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now);
                komut.Parameters.AddWithValue("@ID", kullaniciId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tüm kullanıcıları listeler
        /// </summary>
        public DataTable TumKullanicilariGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT k.KullaniciID, k.KullaniciAdi, r.RolAdi, k.Durum, 
                                        k.SonGirisTarihi, k.OlusturmaTarihi
                                 FROM TBL_Kullanicilar k
                                 INNER JOIN TBL_Roller r ON k.RolID = r.RolID
                                 ORDER BY k.KullaniciID";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Yeni kullanıcı ekler
        /// </summary>
        public int KullaniciEkle(Kullanici kullanici)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Kullanicilar (KullaniciAdi, Sifre, RolID, Durum)
                                 VALUES (@KullaniciAdi, @Sifre, @RolID, @Durum);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                komut.Parameters.AddWithValue("@RolID", kullanici.RolID);
                komut.Parameters.AddWithValue("@Durum", kullanici.Durum);

                baglanti.Open();
                return Convert.ToInt32(komut.ExecuteScalar());
            }
        }

        /// <summary>
        /// Kullanıcı günceller
        /// </summary>
        public void KullaniciGuncelle(Kullanici kullanici)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_Kullanicilar 
                                 SET KullaniciAdi = @KullaniciAdi, Sifre = @Sifre, 
                                     RolID = @RolID, Durum = @Durum
                                 WHERE KullaniciID = @KullaniciID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciID", kullanici.KullaniciID);
                komut.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                komut.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                komut.Parameters.AddWithValue("@RolID", kullanici.RolID);
                komut.Parameters.AddWithValue("@Durum", kullanici.Durum);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Kullanıcı siler
        /// </summary>
        public void KullaniciSil(int kullaniciId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "DELETE FROM TBL_Kullanicilar WHERE KullaniciID = @ID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ID", kullaniciId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Kullanıcı şifresini değiştirir
        /// </summary>
        public void SifreDegistir(int kullaniciId, string yeniSifre)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Kullanicilar SET Sifre = @Sifre WHERE KullaniciID = @ID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Sifre", yeniSifre);
                komut.Parameters.AddWithValue("@ID", kullaniciId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}
