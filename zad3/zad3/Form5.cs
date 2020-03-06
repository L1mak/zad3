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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            dataGridView1.Rows.Clear();
            conn.con.Open();
            SqlCommand sql = new SqlCommand("SELECT [FIO_executor], [Grade]," +
                " [ФИО_менеджера] FROM executor, manager " +
                "WHERE dbo.executor.id_manager= dbo.manager.id", conn.con);
            SqlDataReader read = sql.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(
                    read[0].ToString(),
                    read[1].ToString(),
                    read[2].ToString()
                    );
            }
            conn.con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
