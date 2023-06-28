using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LifDBMS
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = DESKTOP-TO2BQDR\\SQLEXPRESS; initial catalog = Lif; integrated security = true";
            return Conn;
        }
    }
}
