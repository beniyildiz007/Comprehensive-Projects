using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre"); //Mesaj kimden gönderilecekse onun mail bilgileri buraya girilecek
            istemci.Port = 587; //Türkiye mail port numarası
            istemci.Host = "smtp.live.com"; //Windows host adresi (live yerine gmail de yazılabilir)
            istemci.EnableSsl = true;
            mesajim.To.Add(txtMesaj.Text);
            mesajim.From = new MailAddress("Mail"); //Mesaj kimden gönderilecekse onun mail adresi yazılacak
            mesajim.Subject = txtKonu.Text; //Mesajımızın konusu
            mesajim.Body = txtMesaj.Text; //Mesajımız
            istemci.Send(mesajim); //Mesajımızı gönderme komutu
        }
    }
}
