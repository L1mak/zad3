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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=303-9\\MSSQLSERVERRR; Initial Catalog = jojo; Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand auth1 = new SqlCommand($"SELECT executor.[Login_executor]," +
                $" executor.Password FROM dbo.executor where [Login_executor] = '{textBox1.Text}'" +
                $" AND Password = '{textBox2.Text}'", conn);
            SqlCommand auth2 = new SqlCommand($"SELECT manager.[login_manager]," +
                $" manager.Password FROM dbo.manager where [login_manager] = '{textBox1.Text}'" +
                $" AND password = '{textBox2.Text}'", conn);
            SqlDataReader read1 = auth1.ExecuteReader();
            if (read1.HasRows)
            {
                Form2.id = 1;
                MessageBox.Show("Вы успешно авторизовались");
                Form2 fm = new Form2();
                fm.Show();
                this.Hide();
                read1.Close();
            }
            else
            {
                SqlDataReader read2 = auth2.ExecuteReader();
                if (read2.HasRows)
                {
                    MessageBox.Show("Вы успешно авторизовались");
                    Form2 fm = new Form2();
                    fm.Show();
                    this.Hide();
                    read2.Close();
                }
                else
                {
                    MessageBox.Show("Попробуйте снова");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            conn.Close();
        }
    }
}
