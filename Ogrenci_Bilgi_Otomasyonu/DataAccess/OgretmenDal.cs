using System;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    /// <summary>
    /// Öğretmen veri erişim katmanı - CRUD işlemleri
    /// </summary>
    public class OgretmenDal
    {
        /// <summary>
        /// Tüm öğretmenleri listeler
        /// </summary>
        public DataTable TumOgretmenleriGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT OgretmenID, Ad, Soyad, TC, DogumTarihi, Cinsiyet,
                                        Telefon, Email, Brans, BaslamaTarihi, Durum
                                 FROM TBL_Ogretmenler
                                 WHERE Durum = 1
                                 ORDER BY Ad, Soyad";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// LookUpEdit için öğretmen listesi
        /// </summary>
        public DataTable OgretmenListesiGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT OgretmenID, Ad + ' ' + Soyad AS AdSoyad, Brans
                                 FROM TBL_Ogretmenler
                                 WHERE Durum = 1
                                 ORDER BY Ad, Soyad";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Öğretmen detayını getirir
        /// </summary>
        public Ogretmen OgretmenGetir(int ogretmenId)
        {
            Ogretmen ogretmen = null;

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "SELECT * FROM TBL_Ogretmenler WHERE OgretmenID = @OgretmenID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgretmenID", ogretmenId);

                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    ogretmen = new Ogretmen
                    {
                        OgretmenID = Convert.ToInt32(dr["OgretmenID"]),
                        KullaniciID = dr["KullaniciID"] != DBNull.Value ? Convert.ToInt32(dr["KullaniciID"]) : (int?)null,
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        TC = dr["TC"].ToString(),
                        DogumTarihi = dr["DogumTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["DogumTarihi"]) : (DateTime?)null,
                        Cinsiyet = dr["Cinsiyet"].ToString(),
                        Adres = dr["Adres"].ToString(),
                        Telefon = dr["Telefon"].ToString(),
                        Email = dr["Email"].ToString(),
                        Brans = dr["Brans"].ToString(),
                        BaslamaTarihi = dr["BaslamaTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["BaslamaTarihi"]) : (DateTime?)null,
                        Durum = Convert.ToBoolean(dr["Durum"]),
                        FotoUrl = dr["FotoUrl"].ToString()
                    };
                }
            }

            return ogretmen;
        }

        /// <summary>
        /// Yeni öğretmen ekler
        /// </summary>
        public int OgretmenEkle(Ogretmen ogretmen)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Ogretmenler 
                                 (KullaniciID, Ad, Soyad, TC, DogumTarihi, Cinsiyet, 
                                  Adres, Telefon, Email, Brans, BaslamaTarihi, Durum, FotoUrl)
                                 VALUES 
                                 (@KullaniciID, @Ad, @Soyad, @TC, @DogumTarihi, @Cinsiyet,
                                  @Adres, @Telefon, @Email, @Brans, @BaslamaTarihi, @Durum, @FotoUrl);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciID", ogretmen.KullaniciID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Ad", ogretmen.Ad);
                komut.Parameters.AddWithValue("@Soyad", ogretmen.Soyad);
                komut.Parameters.AddWithValue("@TC", ogretmen.TC);
                komut.Parameters.AddWithValue("@DogumTarihi", ogretmen.DogumTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Cinsiyet", ogretmen.Cinsiyet ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Adres", ogretmen.Adres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Telefon", ogretmen.Telefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Email", ogretmen.Email ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Brans", ogretmen.Brans ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@BaslamaTarihi", ogretmen.BaslamaTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Durum", ogretmen.Durum);
                komut.Parameters.AddWithValue("@FotoUrl", ogretmen.FotoUrl ?? (object)DBNull.Value);

                baglanti.Open();
                return Convert.ToInt32(komut.ExecuteScalar());
            }
        }

        /// <summary>
        /// Öğretmen günceller
        /// </summary>
        public void OgretmenGuncelle(Ogretmen ogretmen)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_Ogretmenler SET
                                 Ad = @Ad, Soyad = @Soyad, TC = @TC, DogumTarihi = @DogumTarihi,
                                 Cinsiyet = @Cinsiyet, Adres = @Adres, Telefon = @Telefon,
                                 Email = @Email, Brans = @Brans, BaslamaTarihi = @BaslamaTarihi,
                                 Durum = @Durum, FotoUrl = @FotoUrl
                                 WHERE OgretmenID = @OgretmenID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgretmenID", ogretmen.OgretmenID);
                komut.Parameters.AddWithValue("@Ad", ogretmen.Ad);
                komut.Parameters.AddWithValue("@Soyad", ogretmen.Soyad);
                komut.Parameters.AddWithValue("@TC", ogretmen.TC);
                komut.Parameters.AddWithValue("@DogumTarihi", ogretmen.DogumTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Cinsiyet", ogretmen.Cinsiyet ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Adres", ogretmen.Adres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Telefon", ogretmen.Telefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Email", ogretmen.Email ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Brans", ogretmen.Brans ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@BaslamaTarihi", ogretmen.BaslamaTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Durum", ogretmen.Durum);
                komut.Parameters.AddWithValue("@FotoUrl", ogretmen.FotoUrl ?? (object)DBNull.Value);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Öğretmen siler (Soft delete)
        /// </summary>
        public void OgretmenSil(int ogretmenId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Ogretmenler SET Durum = 0 WHERE OgretmenID = @OgretmenID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgretmenID", ogretmenId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}
