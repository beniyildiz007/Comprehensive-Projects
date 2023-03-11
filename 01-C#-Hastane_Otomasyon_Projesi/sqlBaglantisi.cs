using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _02_Hastane_Proejesi
{
    class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-HKL3D7O\SQLEXPRESS;Initial Catalog=HastaneProjesi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
