using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace zad3
{
    public class conn
    {
        private static SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP-R3TPO26M\\SQLEXPRESS", InitialCatalog = "jojo", IntegratedSecurity = true
        };

        public static SqlConnection con = new SqlConnection(sql.ConnectionString);
        public static DataSet data = new DataSet();
        public void dann()
            {
            data.Tables.Clear();
            List<string> list = new List<string>()
            {
            "SELECT * FROM dbo.executor",
            "SELECT * FROM dbo.manager",
            "SELECT * FROM dbo.koeff",
            "SELECT * FROM dbo.salary",
            "SELECT * FROM dbo.tasks"
            };
            for (int i = 0; i < list.Count; i++)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dannie = new SqlDataAdapter(new SqlCommand(list[i], con));
                
                dannie.Fill(dt);
                
                data.Tables.Add(dt);
            }
            }
    }
}
