using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace zad3
{
    public class conn
    {
        private static SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder()
        {
            DataSource = "303-9\\MSSQLSERVERRR", InitialCatalog = "jojo", IntegratedSecurity = true
        };
        public static SqlConnection con = new SqlConnection(sql.ConnectionString);
    }
}
