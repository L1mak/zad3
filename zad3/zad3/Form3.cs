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

namespace zad3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn.con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM ",conn.con);
            SqlDataReader read = conn.koeff.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Junior_мин_ЗП"].ToString();
            }
            conn.con.Close();
            }
    }
}
