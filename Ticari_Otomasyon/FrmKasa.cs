using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Charts; // DevExpress grafik kontrolleri için gerekli

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent(); // Form bileşenlerini başlat
        }

        // Veritabanı bağlantı sınıfından nesne oluştur
        sqlbaglantisi bgl = new sqlbaglantisi();

        // Müşteri hareketlerini getiren metot - Stored Procedure kullanır
        void musteriHareketleri()
        {
            DataTable dt = new DataTable();                                                      // Veri tablosu oluştur
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti()); // Stored Procedure çalıştır
            da.Fill(dt);                                                                         // Veri tablosunu doldur
            gridControl1.DataSource = dt;                                                       // İlk grid'e veri kaynağını ata
        }

        // Gider bilgilerini getiren metot
        void faturaBilgileri()
        {
            DataTable dt3 = new DataTable();                                                    // Veri tablosu oluştur
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti()); // Giderler tablosundan tüm verileri çek
            da1.Fill(dt3);                                                                       // Veri tablosunu doldur
            gridControl2.DataSource = dt3;                                                      // İkinci grid'e veri kaynağını ata
        }

        // Firma hareketlerini getiren metot - Stored Procedure kullanır
        void firmaHareketleri()
        {
            DataTable dt2 = new DataTable();                                                    // Veri tablosu oluştur
            SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti()); // Stored Procedure çalıştır
            da2.Fill(dt2);                                                                       // Veri tablosunu doldur
            gridControl3.DataSource = dt2;                                                      // Üçüncü grid'e veri kaynağını ata
        }

        public string ad; // Aktif kullanıcı adını tutacak değişken

        // Form yüklendiğinde çalışan olay metodu - Tüm istatistikleri hesaplar
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad; // Aktif kullanıcı adını label'a yaz

            musteriHareketleri();  // Müşteri hareketlerini yükle
            firmaHareketleri();    // Firma hareketlerini yükle
            faturaBilgileri();     // Gider bilgilerini yükle

            // Toplam Ciro Hesaplama - Tüm fatura detaylarının toplamı
            SqlCommand komut1 = new SqlCommand("Select Sum(TUTAR) From TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamTutar.Text = dr1[0].ToString() + " ₺"; // Toplam tutarı label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Son Ayın Toplam Giderleri - Elektrik, su, doğalgaz, internet ve ekstra giderlerin toplamı
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) From TBL_GIDERLER Order By ID Asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " ₺"; // Toplam ödemeleri label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Son Ayın Personel Maaşları Toplamı
            SqlCommand komut3 = new SqlCommand("Select MAASLAR From TBL_GIDERLER Order By ID Asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaaslari.Text = dr3[0].ToString() + " ₺"; // Personel maaşlarını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("Select Count(*) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString(); // Müşteri sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("Select Count(*) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString(); // Firma sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Firmaların Bulunduğu Farklı Şehir Sayısı - DISTINCT ile tekrarsız sayım
            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(IL)) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblSehirSayisi.Text = dr6[0].ToString(); // Firma şehir sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Müşterilerin Bulunduğu Farklı Şehir Sayısı - DISTINCT ile tekrarsız sayım
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblSehirSayisi2.Text = dr7[0].ToString(); // Müşteri şehir sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Toplam Personel Sayısı
            SqlCommand komut8 = new SqlCommand("Select Count(*) From TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPersonelSayisi.Text = dr8[0].ToString(); // Personel sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat

            // Toplam Stok Miktarı - Tüm ürünlerin adet toplamı
            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) From TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString(); // Stok sayısını label'a yaz
            }
            bgl.baglanti().Close(); // Bağlantıyı kapat
        }

        int sayac = 0; // Birinci timer için sayaç değişkeni

        // Birinci timer'ın tick olayı - Gider grafiklerini döngüsel olarak değiştirir
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++; // Sayacı artır

            // Elektrik Faturası Grafiği (0-5 saniye arası)
            if (sayac > 0 && sayac <= 5)
            {
                groupControl10.Text = "Elektrik Faturası";                                      // Grup başlığını değiştir
                chartControl1.Series["Aylar"].Points.Clear();                                   // Önceki grafik verilerini temizle
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    // Son 4 ayın elektrik faturalarını grafiğe ekle
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Su Faturası Grafiği (5-10 saniye arası)
            if (sayac > 5 && sayac <= 10)
            {
                groupControl10.Text = "Su Faturası";                                            // Grup başlığını değiştir
                chartControl1.Series["Aylar"].Points.Clear();                                   // Önceki grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın su faturalarını grafiğe ekle
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Doğalgaz Faturası Grafiği (11-15 saniye arası)
            if (sayac > 11 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz Faturası";                                      // Grup başlığını değiştir
                chartControl1.Series["Aylar"].Points.Clear();                                   // Önceki grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın doğalgaz faturalarını grafiğe ekle
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // İnternet Faturası Grafiği (15-20 saniye arası)
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İnternet Faturası";                                      // Grup başlığını değiştir
                chartControl1.Series["Aylar"].Points.Clear();                                   // Önceki grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın internet faturalarını grafiğe ekle
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Ekstra Giderler Grafiği (20-25 saniye arası)
            if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "Ekstra Giderler";                                        // Grup başlığını değiştir
                chartControl1.Series["Aylar"].Points.Clear();                                   // Önceki grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın ekstra giderlerini grafiğe ekle
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Sayaç 26'ya ulaştığında sıfırla - Döngüyü yeniden başlat
            if (sayac == 26)
            {
                sayac = 0;
            }
        }

        int sayac2 = 0; // İkinci timer için sayaç değişkeni

        // İkinci timer'ın tick olayı - İkinci grafik için aynı döngüyü çalıştırır
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++; // İkinci sayacı artır

            // Elektrik Faturası Grafiği (İkinci Chart Control için)
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "Elektrik Faturası";                                      // İkinci grup başlığını değiştir
                chartControl2.Series["Aylar"].Points.Clear();                                   // İkinci grafik verilerini temizle
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    // Son 4 ayın elektrik faturalarını ikinci grafiğe ekle
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Su Faturası Grafiği (İkinci Chart Control için)
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "Su Faturası";                                            // İkinci grup başlığını değiştir
                chartControl2.Series["Aylar"].Points.Clear();                                   // İkinci grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın su faturalarını ikinci grafiğe ekle
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Doğalgaz Faturası Grafiği (İkinci Chart Control için)
            if (sayac2 > 11 && sayac2 <= 15)
            {
                groupControl11.Text = "Doğalgaz Faturası";                                      // İkinci grup başlığını değiştir
                chartControl2.Series["Aylar"].Points.Clear();                                   // İkinci grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın doğalgaz faturalarını ikinci grafiğe ekle
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // İnternet Faturası Grafiği (İkinci Chart Control için)
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl11.Text = "İnternet Faturası";                                      // İkinci grup başlığını değiştir
                chartControl2.Series["Aylar"].Points.Clear();                                   // İkinci grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın internet faturalarını ikinci grafiğe ekle
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Ekstra Giderler Grafiği (İkinci Chart Control için)
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl11.Text = "Ekstra Giderler";                                        // İkinci grup başlığını değiştir
                chartControl2.Series["Aylar"].Points.Clear();                                   // İkinci grafik verilerini temizle
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER Order By ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    // Son 4 ayın ekstra giderlerini ikinci grafiğe ekle
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // İkinci sayaç 26'ya ulaştığında sıfırla - Döngüyü yeniden başlat
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}