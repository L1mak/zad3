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
        public static SqlCommand koeff = new SqlCommand($"SELECT [Junior_мин_ЗП],[Middle_мин_ЗП]," +
            $"[Senior_мин_ЗП],[Коэффициент_для_Анализ_и_проектирование]," +
            $"[Коэффициент_для_Техническое_обслуживание_и_сопровождение]," +
            $"[Коэффициент_для_Установка_оборудования],[Коэффициент_времени]," +
            $"[Коэффициент_сложности],[Коэффициент_для_перевода_в_денежный_эквивалент]" +
            $"FROM salary, dbo.koeff WHERE salary.id_salary AND koeff.id_koeff = '{Form2.id}'", conn.con);
    }
}
