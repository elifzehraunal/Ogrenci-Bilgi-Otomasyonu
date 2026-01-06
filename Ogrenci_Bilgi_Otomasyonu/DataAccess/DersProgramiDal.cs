using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    public class DersProgramiDal
    {
        /// <summary>
        /// Tüm ders programlarını getirir (Yönetici için)
        /// </summary>
        public List<DersProgrami> TumProgramlariGetir()
        {
            var liste = new List<DersProgrami>();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT dp.*, s.SinifAdi, d.DersAdi, 
                                 ISNULL(o.Ad + ' ' + o.Soyad, '-') AS OgretmenAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Siniflar s ON dp.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON dp.DersID = d.DersID
                                 LEFT JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE dp.Durum = 1
                                 ORDER BY s.SinifAdi, 
                                    CASE dp.Gun 
                                        WHEN 'Pazartesi' THEN 1 
                                        WHEN 'Salı' THEN 2 
                                        WHEN 'Çarşamba' THEN 3 
                                        WHEN 'Perşembe' THEN 4 
                                        WHEN 'Cuma' THEN 5 
                                    END, dp.DersSaati";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(OkuDersProgrami(dr));
                        }
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Sınıfa göre ders programını getirir
        /// </summary>
        public List<DersProgrami> SinifProgramiGetir(int sinifId)
        {
            var liste = new List<DersProgrami>();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT dp.*, s.SinifAdi, d.DersAdi,
                                 ISNULL(o.Ad + ' ' + o.Soyad, '-') AS OgretmenAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Siniflar s ON dp.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON dp.DersID = d.DersID
                                 LEFT JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE dp.SinifID = @SinifID AND dp.Durum = 1
                                 ORDER BY CASE dp.Gun 
                                        WHEN 'Pazartesi' THEN 1 
                                        WHEN 'Salı' THEN 2 
                                        WHEN 'Çarşamba' THEN 3 
                                        WHEN 'Perşembe' THEN 4 
                                        WHEN 'Cuma' THEN 5 
                                    END, dp.DersSaati";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@SinifID", sinifId);
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(OkuDersProgrami(dr));
                        }
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Öğretmenin verdiği derslerin programını getirir
        /// </summary>
        public List<DersProgrami> OgretmenProgramiGetir(int kullaniciId)
        {
            var liste = new List<DersProgrami>();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT dp.*, s.SinifAdi, d.DersAdi,
                                 ISNULL(o.Ad + ' ' + o.Soyad, '-') AS OgretmenAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Siniflar s ON dp.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON dp.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID AND dp.Durum = 1
                                 ORDER BY s.SinifAdi,
                                    CASE dp.Gun 
                                        WHEN 'Pazartesi' THEN 1 
                                        WHEN 'Salı' THEN 2 
                                        WHEN 'Çarşamba' THEN 3 
                                        WHEN 'Perşembe' THEN 4 
                                        WHEN 'Cuma' THEN 5 
                                    END, dp.DersSaati";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(OkuDersProgrami(dr));
                        }
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Öğrencinin sınıfına ait ders programını getirir
        /// </summary>
        public List<DersProgrami> OgrenciProgramiGetir(int kullaniciId)
        {
            var liste = new List<DersProgrami>();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT dp.*, s.SinifAdi, d.DersAdi,
                                 ISNULL(o.Ad + ' ' + o.Soyad, '-') AS OgretmenAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Siniflar s ON dp.SinifID = s.SinifID
                                 INNER JOIN TBL_Dersler d ON dp.DersID = d.DersID
                                 LEFT JOIN TBL_Ogretmenler o ON d.OgretmenID = o.OgretmenID
                                 WHERE dp.SinifID = (SELECT SinifID FROM TBL_Ogrenciler WHERE KullaniciID = @KullaniciID)
                                 AND dp.Durum = 1
                                 ORDER BY CASE dp.Gun 
                                        WHEN 'Pazartesi' THEN 1 
                                        WHEN 'Salı' THEN 2 
                                        WHEN 'Çarşamba' THEN 3 
                                        WHEN 'Perşembe' THEN 4 
                                        WHEN 'Cuma' THEN 5 
                                    END, dp.DersSaati";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(OkuDersProgrami(dr));
                        }
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Yeni ders programı ekle
        /// </summary>
        public int ProgramEkle(DersProgrami entity)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_DersProgrami (SinifID, DersID, OgretmenID, Gun, DersSaati, BaslangicSaati, BitisSaati, Durum)
                                VALUES (@SinifID, @DersID, @OgretmenID, @Gun, @DersSaati, @BaslangicSaati, @BitisSaati, 1);
                                SELECT SCOPE_IDENTITY()";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@SinifID", entity.SinifID);
                    cmd.Parameters.AddWithValue("@DersID", entity.DersID);
                    cmd.Parameters.AddWithValue("@OgretmenID", entity.OgretmenID);
                    cmd.Parameters.AddWithValue("@Gun", entity.Gun);
                    cmd.Parameters.AddWithValue("@DersSaati", entity.DersSaati);
                    cmd.Parameters.AddWithValue("@BaslangicSaati", entity.BaslangicSaati != TimeSpan.Zero ? (object)entity.BaslangicSaati : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BitisSaati", entity.BitisSaati != TimeSpan.Zero ? (object)entity.BitisSaati : DBNull.Value);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Ders programı güncelle
        /// </summary>
        public void ProgramGuncelle(DersProgrami entity)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"UPDATE TBL_DersProgrami 
                                SET SinifID = @SinifID, DersID = @DersID, Gun = @Gun, 
                                    DersSaati = @DersSaati, BaslangicSaati = @BaslangicSaati, BitisSaati = @BitisSaati
                                WHERE ProgramID = @ProgramID";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@ProgramID", entity.ProgramID);
                    cmd.Parameters.AddWithValue("@SinifID", entity.SinifID);
                    cmd.Parameters.AddWithValue("@DersID", entity.DersID);
                    cmd.Parameters.AddWithValue("@Gun", entity.Gun);
                    cmd.Parameters.AddWithValue("@DersSaati", entity.DersSaati);
                    cmd.Parameters.AddWithValue("@BaslangicSaati", entity.BaslangicSaati != TimeSpan.Zero ? (object)entity.BaslangicSaati : DBNull.Value);
                    cmd.Parameters.AddWithValue("@BitisSaati", entity.BitisSaati != TimeSpan.Zero ? (object)entity.BitisSaati : DBNull.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Ders programı sil (soft delete)
        /// </summary>
        public void ProgramSil(int programId)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_DersProgrami SET Durum = 0 WHERE ProgramID = @ProgramID";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@ProgramID", programId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private DersProgrami OkuDersProgrami(SqlDataReader dr)
        {
            return new DersProgrami
            {
                ProgramID = Convert.ToInt32(dr["ProgramID"]),
                SinifID = Convert.ToInt32(dr["SinifID"]),
                DersID = Convert.ToInt32(dr["DersID"]),
                Gun = dr["Gun"].ToString(),
                DersSaati = Convert.ToInt32(dr["DersSaati"]),
                BaslangicSaati = dr["BaslangicSaati"] != DBNull.Value ? TimeSpan.Parse(dr["BaslangicSaati"].ToString()) : TimeSpan.Zero,
                BitisSaati = dr["BitisSaati"] != DBNull.Value ? TimeSpan.Parse(dr["BitisSaati"].ToString()) : TimeSpan.Zero,
                BaslangicSaatiStr = dr["BaslangicSaati"]?.ToString(),
                BitisSaatiStr = dr["BitisSaati"]?.ToString(),
                Durum = Convert.ToBoolean(dr["Durum"]),
                SinifAdi = dr["SinifAdi"]?.ToString(),
                DersAdi = dr["DersAdi"]?.ToString(),
                OgretmenAdi = dr["OgretmenAdi"]?.ToString()
            };
        }

        /// <summary>
        /// Tüm ders programını siler (hard delete)
        /// </summary>
        public void TumProgramiSil()
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "DELETE FROM TBL_DersProgrami";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Otomatik oluşturulan ders programı ekler (TimeSpan destekli)
        /// </summary>
        public void DersProgramiEkle(DersProgrami entity)
        {
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_DersProgrami (SinifID, DersID, OgretmenID, Gun, DersSaati, BaslangicSaati, BitisSaati, Durum)
                                VALUES (@SinifID, @DersID, @OgretmenID, @Gun, @DersSaati, @BaslangicSaati, @BitisSaati, 1)";
                using (var cmd = new SqlCommand(sorgu, con))
                {
                    cmd.Parameters.AddWithValue("@SinifID", entity.SinifID);
                    cmd.Parameters.AddWithValue("@DersID", entity.DersID);
                    cmd.Parameters.AddWithValue("@OgretmenID", entity.OgretmenID);
                    cmd.Parameters.AddWithValue("@Gun", entity.Gun ?? "");
                    cmd.Parameters.AddWithValue("@DersSaati", entity.DersSaati);
                    cmd.Parameters.AddWithValue("@BaslangicSaati", entity.BaslangicSaati.ToString(@"hh\:mm"));
                    cmd.Parameters.AddWithValue("@BitisSaati", entity.BitisSaati.ToString(@"hh\:mm"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Öğretmenin ders verdiği sınıfları getirir (Ders programından)
        /// </summary>
        public DataTable OgretmenSiniflariniGetir(int kullaniciId)
        {
            DataTable dt = new DataTable();
            using (var con = SqlBaglantisi.BaglantiGetir())
            {
                // Öğretmenin KullaniciID'sinden OgretmenID'yi bul ve dersleri getir
                string sorgu = @"SELECT DISTINCT s.SinifID, s.SinifAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Siniflar s ON dp.SinifID = s.SinifID
                                 INNER JOIN TBL_Ogretmenler o ON dp.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID
                                 ORDER BY s.SinifAdi";
                using (var da = new SqlDataAdapter(sorgu, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    da.Fill(dt);
                }
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
                string sorgu = @"SELECT DISTINCT d.DersID, d.DersAdi
                                 FROM TBL_DersProgrami dp
                                 INNER JOIN TBL_Dersler d ON dp.DersID = d.DersID
                                 INNER JOIN TBL_Ogretmenler o ON dp.OgretmenID = o.OgretmenID
                                 WHERE o.KullaniciID = @KullaniciID AND dp.SinifID = @SinifID
                                 ORDER BY d.DersAdi";
                using (var da = new SqlDataAdapter(sorgu, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                    da.SelectCommand.Parameters.AddWithValue("@SinifID", sinifId);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
