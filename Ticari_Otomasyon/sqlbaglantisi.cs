using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // SQL Server bağlantısı için gerekli

namespace Ticari_Otomasyon
{
    // Veritabanı bağlantı işlemlerini yöneten sınıf
    class sqlbaglantisi
    {
        // Veritabanına bağlantı kuran ve açık bağlantı döndüren metot
        public SqlConnection baglanti()
        {
            // SQL Server bağlantı string'i - Yerel SQL Express sunucusuna bağlanır
            // Data Source: Sunucu adı ve instance
            // Initial Catalog: Veritabanı adı (DboTicariOtomasyon)
            // Integrated Security: Windows kimlik doğrulaması kullan
            // Encrypt: Şifreleme kapalı (yerel bağlantı için)
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-90M90HO\\SQLEXPRESS;Initial Catalog=DboTicariOtomasyon;Integrated Security=True;Encrypt=False");
            
            baglan.Open(); // Bağlantıyı aç
            return baglan; // Açık bağlantıyı döndür
        }
    }
}
