using System.Data.SqlClient;

namespace Ogrenci_Bilgi_Otomasyonu.DataAccess
{
    /// <summary>
    /// Merkezi SQL Server bağlantı sınıfı
    /// Tüm veritabanı işlemleri bu sınıf üzerinden bağlantı alır
    /// </summary>
    public class SqlBaglantisi
    {
        // Windows Authentication kullanarak localhost'a bağlantı
        private static readonly string connectionString = 
            @"Server=.;Database=DB_OgrenciBilgiOtomasyonu;Integrated Security=True;";

        /// <summary>
        /// Yeni bir SQL bağlantısı oluşturur
        /// </summary>
        /// <returns>SqlConnection nesnesi</returns>
        public static SqlConnection BaglantiGetir()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Connection string'i döndürür
        /// </summary>
        public static string ConnectionString => connectionString;
    }
}
