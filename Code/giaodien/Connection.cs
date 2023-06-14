using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace giaodien
{
    class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-68FB4LQ\MSSQLSERVER01;Initial Catalog=atbmtt;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
