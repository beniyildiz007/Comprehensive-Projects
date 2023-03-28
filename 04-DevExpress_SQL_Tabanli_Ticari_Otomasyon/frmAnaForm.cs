using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_DevExpress_SQL_Tabanli_Ticari_Otomasyon
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        frmUrunler fr;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new frmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }


        frmMusteriler fr2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new frmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        frmFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new frmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }


        frmPersonel fr4;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new frmPersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }


        frmRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new frmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }


        frmGiderler fr6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new frmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        frmBankalar fr7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new frmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }

        frmFaturalar fr8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new frmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }

        }


        frmNotlar fr9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new frmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }

        }

        frmHareketler fr10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr10==null || fr10.IsDisposed)
            {
                fr10 = new frmHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }


        frmStoklar fr11;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new frmStoklar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        frmAyarlar fr12;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new frmAyarlar();
                fr12.Show();
            }
        }


        public string kullanici;
        frmKasa fr13;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new frmKasa();
                fr13.ad = kullanici;
                fr13.MdiParent = this;
                fr13.Show();
            }

        }

        frmAnaSayfa fr14;
        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new frmAnaSayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }

        }

        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new frmAnaSayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
    }
}
