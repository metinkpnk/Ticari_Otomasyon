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

namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent(); // Form bileşenlerini başlat
        }

        // Veritabanı bağlantı sınıfından nesne oluştur
        sqlbaglantisi bgl = new sqlbaglantisi();

        // Form üzerindeki tüm metin kutularını temizleyen metot
        void temizle()
        {
            TxtId.Text = "";           // ID alanını temizle
            TxtAd.Text = "";           // Ürün adı alanını temizle
            TxtMarka.Text = "";        // Marka alanını temizle
            TxtModel.Text = "";        // Model alanını temizle
            MskYil.Text = "";          // Yıl alanını temizle
            NudAdet.Value = 0;         // Adet sayısını sıfırla
            TxtAlis.Text = "";         // Alış fiyatı alanını temizle
            TxtSatis.Text = "";        // Satış fiyatı alanını temizle
            RchDetay.Text = "";        // Detay alanını temizle
        }

        // Veritabanından ürün listesini çekip grid'e yükleyen metot
        void listele()
        {
            DataTable dt = new DataTable();                                                    // Veri tablosu oluştur
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_URUNLER", bgl.baglanti()); // SQL sorgusu ile veri adaptörü oluştur
            da.Fill(dt);                                                                       // Veri tablosunu doldur
            gridControl1.DataSource = dt;                                                     // Grid kontrolüne veri kaynağını ata
        }

        // Form yüklendiğinde çalışan olay metodu
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();  // Ürün listesini yükle
            temizle();  // Form alanlarını temizle
        }

        // Kaydet butonuna tıklandığında çalışan olay metodu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Yeni ürün kaydetme işlemi - Parametreli sorgu ile SQL Injection saldırılarını önle
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);                              // Ürün adını parametre olarak ekle
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);                           // Marka bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);                           // Model bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p4", MskYil.Text);                             // Yıl bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));     // Adet sayısını integer'a çevirip ekle
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));             // Alış fiyatını decimal'a çevirip ekle
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));            // Satış fiyatını decimal'a çevirip ekle
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);                           // Detay bilgisini parametre olarak ekle
            komut.ExecuteNonQuery();                                                       // SQL komutunu çalıştır
            bgl.baglanti().Close();                                                        // Veritabanı bağlantısını kapat
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı göster
            listele();                                                                     // Listeyi yenile
        }

        // Sil butonuna tıklandığında çalışan olay metodu
        private void BtnSil_Click(object sender, EventArgs e)
        {
            // Seçili ürünü silme işlemi
            SqlCommand komutsil = new SqlCommand("delete from TBL_URUNLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtId.Text);                          // Silinecek ürünün ID'sini parametre olarak ekle
            komutsil.ExecuteNonQuery();                                                   // SQL komutunu çalıştır
            bgl.baglanti().Close();                                                       // Veritabanı bağlantısını kapat
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error); // Silme mesajı göster
            listele();                                                                    // Listeyi yenile
        }

        // Grid'de satır seçimi değiştiğinde çalışan olay metodu
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);               // Seçili satırın verilerini al
            TxtId.Text = dr["ID"].ToString();                                            // ID'yi form alanına aktar
            TxtAd.Text = dr["URUNAD"].ToString();                                        // Ürün adını form alanına aktar
            TxtMarka.Text = dr["MARKA"].ToString();                                      // Marka bilgisini form alanına aktar
            TxtModel.Text = dr["MODEL"].ToString();                                      // Model bilgisini form alanına aktar
            MskYil.Text = dr["YIL"].ToString();                                          // Yıl bilgisini form alanına aktar
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());                        // Adet sayısını form alanına aktar
            TxtAlis.Text = dr["ALISFIYAT"].ToString();                                   // Alış fiyatını form alanına aktar
            TxtSatis.Text = dr["SATISFIYAT"].ToString();                                 // Satış fiyatını form alanına aktar
            RchDetay.Text = dr["DETAY"].ToString();                                      // Detay bilgisini form alanına aktar
        }

        // Güncelle butonuna tıklandığında çalışan olay metodu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // Mevcut ürün bilgilerini güncelleme işlemi
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);                            // Güncellenecek ürün adını parametre olarak ekle
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);                         // Güncellenecek marka bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);                         // Güncellenecek model bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p4", MskYil.Text);                           // Güncellenecek yıl bilgisini parametre olarak ekle
            komut.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));   // Güncellenecek adet sayısını parametre olarak ekle
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));           // Güncellenecek alış fiyatını parametre olarak ekle
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));          // Güncellenecek satış fiyatını parametre olarak ekle
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);                         // Güncellenecek detay bilgisini parametre olarak ekle
            komut.Parameters.Add("@p9", TxtId.Text);                                     // Güncellenecek ürünün ID'sini parametre olarak ekle
            komut.ExecuteNonQuery();                                                     // SQL komutunu çalıştır
            bgl.baglanti().Close();                                                      // Veritabanı bağlantısını kapat
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Güncelleme mesajı göster
            listele();                                                                   // Listeyi yenile
        }

        // Grid kontrolüne tıklandığında çalışan olay metodu (şu an boş)
        private void gridControl1_Click(object sender, EventArgs e)
        {
            // Bu metot şu an kullanılmıyor
        }

        // Temizle butonuna tıklandığında çalışan olay metodu
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle(); // Form alanlarını temizle
        }
    }
}
