using System;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    /// <summary>
    /// Ders veri erişim katmanı - CRUD işlemleri
    /// </summary>
    public class DersDal
    {
        /// <summary>
        /// Tüm dersleri listeler
        /// </summary>
        public DataTable TumDersleriGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT d.DersID, d.DersAdi, d.DersKodu, d.OgretmenID, d.HaftalikSaat, d.Kredi,
                                        ISNULL(o.Ad + ' ' + o.Soyad, 'Atanmadı') AS OgretmenAdi, d.Durum
                                 FROM TBL_Dersler d
                                 LEFT JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE d.Durum = 1
                                 ORDER BY d.DersAdi";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// LookUpEdit için ders listesi
        /// </summary>
        public DataTable DersListesiGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT DersID, DersAdi, DersKodu
                                 FROM TBL_Dersler
                                 WHERE Durum = 1
                                 ORDER BY DersAdi";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Öğretmenin kendi derslerini getirir (KullaniciID üzerinden)
        /// </summary>
        public DataTable OgretmenDersleriniGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT d.DersID, d.DersAdi, d.DersKodu
                                 FROM TBL_Dersler d
                                 INNER JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE d.Durum = 1 AND o.KullaniciID = @KullaniciID
                                 ORDER BY d.DersAdi";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciID", kullaniciId);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Ders detayını getirir
        /// </summary>
        public Ders DersGetir(int dersId)
        {
            Ders ders = null;

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT d.*, ISNULL(o.Ad + ' ' + o.Soyad, '') AS OgretmenAdi
                                 FROM TBL_Dersler d
                                 LEFT JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE d.DersID = @DersID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@DersID", dersId);

                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    ders = new Ders
                    {
                        DersID = Convert.ToInt32(dr["DersID"]),
                        DersAdi = dr["DersAdi"].ToString(),
                        DersKodu = dr["DersKodu"].ToString(),
                        OgretmenID = dr["OgretmenID"] != DBNull.Value ? Convert.ToInt32(dr["OgretmenID"]) : (int?)null,
                        HaftalikSaat = Convert.ToInt32(dr["HaftalikSaat"]),
                        Kredi = Convert.ToInt32(dr["Kredi"]),
                        Durum = Convert.ToBoolean(dr["Durum"]),
                        OgretmenAdi = dr["OgretmenAdi"].ToString()
                    };
                }
            }

            return ders;
        }

        /// <summary>
        /// Yeni ders ekler
        /// </summary>
        public int DersEkle(Ders ders)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Dersler 
                                 (DersAdi, DersKodu, OgretmenID, HaftalikSaat, Kredi, Durum)
                                 VALUES 
                                 (@DersAdi, @DersKodu, @OgretmenID, @HaftalikSaat, @Kredi, @Durum);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@DersAdi", ders.DersAdi);
                komut.Parameters.AddWithValue("@DersKodu", ders.DersKodu ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@OgretmenID", ders.OgretmenID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@HaftalikSaat", ders.HaftalikSaat);
                komut.Parameters.AddWithValue("@Kredi", ders.Kredi);
                komut.Parameters.AddWithValue("@Durum", ders.Durum);

                baglanti.Open();
                return Convert.ToInt32(komut.ExecuteScalar());
            }
        }

        /// <summary>
        /// Ders günceller
        /// </summary>
        public void DersGuncelle(Ders ders)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_Dersler SET
                                 DersAdi = @DersAdi, DersKodu = @DersKodu, OgretmenID = @OgretmenID,
                                 HaftalikSaat = @HaftalikSaat, Kredi = @Kredi, Durum = @Durum
                                 WHERE DersID = @DersID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@DersID", ders.DersID);
                komut.Parameters.AddWithValue("@DersAdi", ders.DersAdi);
                komut.Parameters.AddWithValue("@DersKodu", ders.DersKodu ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@OgretmenID", ders.OgretmenID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@HaftalikSaat", ders.HaftalikSaat);
                komut.Parameters.AddWithValue("@Kredi", ders.Kredi);
                komut.Parameters.AddWithValue("@Durum", ders.Durum);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ders siler (Soft delete)
        /// </summary>
        public void DersSil(int dersId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Dersler SET Durum = 0 WHERE DersID = @DersID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@DersID", dersId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}
