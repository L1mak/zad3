using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=303-9\\MSSQLSERVERRR; Inital Catalog=jojo; Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }
    }
}
