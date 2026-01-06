using System.Data;
using System.Data.SqlClient;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    public class SinifDal
    {
        public DataTable TumSiniflariGetir()
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT SinifID, SinifAdi, Kapasite, Durum
                                 FROM TBL_Siniflar WHERE Durum = 1 ORDER BY SinifAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SinifListesiGetir()
        {
            DataTable dt = new DataTable();
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"SELECT SinifID, SinifAdi FROM TBL_Siniflar 
                                 WHERE Durum = 1 ORDER BY SinifAdi";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                da.Fill(dt);
            }
            return dt;
        }

        public void SinifEkle(string sinifAdi, int kapasite)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = @"INSERT INTO TBL_Siniflar (SinifAdi, Kapasite, Durum) VALUES (@SinifAdi, @Kapasite, 1)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@SinifAdi", sinifAdi);
                komut.Parameters.AddWithValue("@Kapasite", kapasite);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }

        public void SinifSil(int sinifId)
        {
            using (SqlConnection baglanti = SqlBaglantisi.BaglantiGetir())
            {
                string sorgu = "UPDATE TBL_Siniflar SET Durum = 0 WHERE SinifID = @SinifID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@SinifID", sinifId);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}
