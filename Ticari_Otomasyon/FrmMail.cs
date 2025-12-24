using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;        // Ağ işlemleri için gerekli
using System.Net.Mail;   // E-posta gönderme işlemleri için gerekli
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent(); // Form bileşenlerini başlat
        }

        public string mail; // Dışarıdan alınacak e-posta adresi

        // Form yüklendiğinde çalışan olay metodu
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail; // Dışarıdan gelen e-posta adresini textbox'a yaz
        }

        // Gönder butonuna tıklandığında çalışan olay metodu
        private void BtnGonder_Click(object sender, EventArgs e)
        {
            // E-posta mesajı nesnesi oluştur
            MailMessage mesajim = new MailMessage();
            
            // SMTP istemci nesnesi oluştur (Gmail için)
            SmtpClient istemci = new SmtpClient();
            
            // Gmail SMTP ayarları
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre"); // Gönderen e-posta ve şifre (güvenlik için değiştirilmeli)
            istemci.Port = 587;                    // Gmail SMTP port numarası
            istemci.Host = "smtp.gmail.com";       // Gmail SMTP sunucu adresi
            istemci.EnableSsl = true;              // SSL şifreleme aktif
            
            // E-posta detaylarını ayarla
            mesajim.To.Add(TxtMail.Text);          // Alıcı e-posta adresi
            mesajim.From = new MailAddress("Mail"); // Gönderen e-posta adresi (güvenlik için değiştirilmeli)
            mesajim.Subject = TxtKonu.Text;        // E-posta konusu
            mesajim.Body = TxtMesaj.Text;          // E-posta içeriği
            
            // E-postayı gönder
            istemci.Send(mesajim);
        }
    }
}
