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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,SUM(ADET) as 'ADET' from TBL_URUNLER group by URUNAD having SUM(ADET)<=20 order by SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select TOP 10 TARIH,SAAT,BASLIK from TBL_NOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void firmaHareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            gridControlSon10.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
           stoklar();

           ajanda();

           firmaHareketler();

           fihrist();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            haberler();

        }
    }
}
