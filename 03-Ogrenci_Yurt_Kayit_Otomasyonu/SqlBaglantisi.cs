using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _03_Ogrenci_Yurt_Kayit_Otomasyonu
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=dbYurtOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
