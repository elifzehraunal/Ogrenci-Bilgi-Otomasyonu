using System;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    /// <summary>
    /// Öğrenci veri erişim katmanı - CRUD işlemleri
    /// </summary>
    public class OgrenciDal
    {
        /// <summary>
        /// Tüm öğrencileri listeler
        /// </summary>
        public DataTable TumOgrencileriGetir()
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT o.OgrenciID, o.OgrenciNo, o.Ad, o.Soyad, o.TC, 
                                        o.DogumTarihi, o.Cinsiyet, o.Telefon, o.Email,
                                        s.SinifAdi, o.VeliAdi, o.VeliTelefon, o.Durum
                                 FROM TBL_Ogrenciler o
                                 LEFT JOIN TBL_Siniflar s ON o.SinifID = s.SinifID
                                 WHERE o.Durum = 1
                                 ORDER BY o.OgrenciNo";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Sınıfa göre öğrencileri listeler
        /// </summary>
        public DataTable SinifaGoreOgrencileriGetir(int sinifId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT o.OgrenciID, o.OgrenciNo, o.Ad, o.Soyad, o.TC, 
                                        o.DogumTarihi, o.Cinsiyet, o.Telefon, o.Email,
                                        s.SinifAdi, o.VeliAdi, o.VeliTelefon
                                 FROM TBL_Ogrenciler o
                                 LEFT JOIN TBL_Siniflar s ON o.SinifID = s.SinifID
                                 WHERE o.SinifID = @SinifID AND o.Durum = 1
                                 ORDER BY o.OgrenciNo";

                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@SinifID", sinifId);
                da.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Öğrenci detayını getirir
        /// </summary>
        public Ogrenci OgrenciGetir(int ogrenciId)
        {
            Ogrenci ogrenci = null;

            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT o.*, s.SinifAdi
                                 FROM TBL_Ogrenciler o
                                 LEFT JOIN TBL_Siniflar s ON o.SinifID = s.SinifID
                                 WHERE o.OgrenciID = @OgrenciID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgrenciID", ogrenciId);

                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    ogrenci = new Ogrenci
                    {
                        OgrenciID = Convert.ToInt32(dr["OgrenciID"]),
                        KullaniciID = dr["KullaniciID"] != DBNull.Value ? Convert.ToInt32(dr["KullaniciID"]) : (int?)null,
                        OgrenciNo = dr["OgrenciNo"].ToString(),
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        TC = dr["TC"].ToString(),
                        DogumTarihi = dr["DogumTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["DogumTarihi"]) : (DateTime?)null,
                        Cinsiyet = dr["Cinsiyet"].ToString(),
                        Adres = dr["Adres"].ToString(),
                        Telefon = dr["Telefon"].ToString(),
                        Email = dr["Email"].ToString(),
                        SinifID = dr["SinifID"] != DBNull.Value ? Convert.ToInt32(dr["SinifID"]) : (int?)null,
                        VeliAdi = dr["VeliAdi"].ToString(),
                        VeliSoyadi = dr["VeliSoyadi"].ToString(),
                        VeliTelefon = dr["VeliTelefon"].ToString(),
                        VeliEmail = dr["VeliEmail"].ToString(),
                        VeliMeslek = dr["VeliMeslek"].ToString(),
                        VeliAdres = dr["VeliAdres"].ToString(),
                        KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"]),
                        Durum = Convert.ToBoolean(dr["Durum"]),
                        FotoUrl = dr["FotoUrl"].ToString(),
                        SinifAdi = dr["SinifAdi"].ToString()
                    };
                }
            }

            return ogrenci;
        }

        /// <summary>
        /// Yeni öğrenci ekler
        /// </summary>
        public int OgrenciEkle(Ogrenci ogrenci)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Ogrenciler 
                                 (KullaniciID, OgrenciNo, Ad, Soyad, TC, DogumTarihi, Cinsiyet, 
                                  Adres, Telefon, Email, SinifID, VeliAdi, VeliSoyadi, 
                                  VeliTelefon, VeliEmail, VeliMeslek, VeliAdres, Durum, FotoUrl)
                                 VALUES 
                                 (@KullaniciID, @OgrenciNo, @Ad, @Soyad, @TC, @DogumTarihi, @Cinsiyet,
                                  @Adres, @Telefon, @Email, @SinifID, @VeliAdi, @VeliSoyadi,
                                  @VeliTelefon, @VeliEmail, @VeliMeslek, @VeliAdres, @Durum, @FotoUrl);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciID", ogrenci.KullaniciID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);
                komut.Parameters.AddWithValue("@Ad", ogrenci.Ad);
                komut.Parameters.AddWithValue("@Soyad", ogrenci.Soyad);
                komut.Parameters.AddWithValue("@TC", ogrenci.TC);
                komut.Parameters.AddWithValue("@DogumTarihi", ogrenci.DogumTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Cinsiyet", ogrenci.Cinsiyet ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Adres", ogrenci.Adres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Telefon", ogrenci.Telefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Email", ogrenci.Email ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@SinifID", ogrenci.SinifID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliAdi", ogrenci.VeliAdi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliSoyadi", ogrenci.VeliSoyadi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliTelefon", ogrenci.VeliTelefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliEmail", ogrenci.VeliEmail ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliMeslek", ogrenci.VeliMeslek ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliAdres", ogrenci.VeliAdres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Durum", ogrenci.Durum);
                komut.Parameters.AddWithValue("@FotoUrl", ogrenci.FotoUrl ?? (object)DBNull.Value);

                baglanti.Open();
                return Convert.ToInt32(komut.ExecuteScalar());
            }
        }

        /// <summary>
        /// Öğrenci günceller
        /// </summary>
        public void OgrenciGuncelle(Ogrenci ogrenci)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_Ogrenciler SET
                                 OgrenciNo = @OgrenciNo, Ad = @Ad, Soyad = @Soyad, TC = @TC,
                                 DogumTarihi = @DogumTarihi, Cinsiyet = @Cinsiyet, Adres = @Adres,
                                 Telefon = @Telefon, Email = @Email, SinifID = @SinifID,
                                 VeliAdi = @VeliAdi, VeliSoyadi = @VeliSoyadi, VeliTelefon = @VeliTelefon,
                                 VeliEmail = @VeliEmail, VeliMeslek = @VeliMeslek, VeliAdres = @VeliAdres,
                                 Durum = @Durum, FotoUrl = @FotoUrl
                                 WHERE OgrenciID = @OgrenciID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgrenciID", ogrenci.OgrenciID);
                komut.Parameters.AddWithValue("@OgrenciNo", ogrenci.OgrenciNo);
                komut.Parameters.AddWithValue("@Ad", ogrenci.Ad);
                komut.Parameters.AddWithValue("@Soyad", ogrenci.Soyad);
                komut.Parameters.AddWithValue("@TC", ogrenci.TC);
                komut.Parameters.AddWithValue("@DogumTarihi", ogrenci.DogumTarihi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Cinsiyet", ogrenci.Cinsiyet ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Adres", ogrenci.Adres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Telefon", ogrenci.Telefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Email", ogrenci.Email ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@SinifID", ogrenci.SinifID ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliAdi", ogrenci.VeliAdi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliSoyadi", ogrenci.VeliSoyadi ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliTelefon", ogrenci.VeliTelefon ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliEmail", ogrenci.VeliEmail ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliMeslek", ogrenci.VeliMeslek ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@VeliAdres", ogrenci.VeliAdres ?? (object)DBNull.Value);
                komut.Parameters.AddWithValue("@Durum", ogrenci.Durum);
                komut.Parameters.AddWithValue("@FotoUrl", ogrenci.FotoUrl ?? (object)DBNull.Value);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Öğrenci siler (Soft delete - Durumu pasif yapar)
        /// </summary>
        public void OgrenciSil(int ogrenciId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Ogrenciler SET Durum = 0 WHERE OgrenciID = @OgrenciID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgrenciID", ogrenciId);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Öğrenci numarasının benzersiz olup olmadığını kontrol eder
        /// </summary>
        public bool OgrenciNoKontrol(string ogrenciNo, int haricTutulacakId = 0)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "SELECT COUNT(*) FROM TBL_Ogrenciler WHERE OgrenciNo = @OgrenciNo AND OgrenciID != @ID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                komut.Parameters.AddWithValue("@ID", haricTutulacakId);

                baglanti.Open();
                int count = Convert.ToInt32(komut.ExecuteScalar());
                return count == 0;
            }
        }

        /// <summary>
        /// TC'nin benzersiz olup olmadığını kontrol eder
        /// </summary>
        public bool TCKontrol(string tc, int haricTutulacakId = 0)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "SELECT COUNT(*) FROM TBL_Ogrenciler WHERE TC = @TC AND OgrenciID != @ID";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@TC", tc);
                komut.Parameters.AddWithValue("@ID", haricTutulacakId);

                baglanti.Open();
                int count = Convert.ToInt32(komut.ExecuteScalar());
                return count == 0;
            }
        }

        /// <summary>
        /// Otomatik öğrenci numarası oluşturur (Yıl + Sıra No)
        /// </summary>
        public string OtomatikNoOlustur()
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string yil = DateTime.Now.Year.ToString();
                string sorgu = @"SELECT ISNULL(MAX(CAST(RIGHT(OgrenciNo, 3) AS INT)), 0) + 1 
                                 FROM TBL_Ogrenciler 
                                 WHERE OgrenciNo LIKE @Yil + '%'";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Yil", yil);

                baglanti.Open();
                int sonrakiNo = Convert.ToInt32(komut.ExecuteScalar());
                return yil + sonrakiNo.ToString("D3"); // Örn: 2024001, 2024002
            }
        }
    }
}
