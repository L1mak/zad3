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
        public static string s;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.con.Open();
            SqlCommand auth1 = new SqlCommand($"SELECT * FROM dbo.executor " +
                $"where [Login_executor] = '{textBox1.Text}' AND Password = '{textBox2.Text}'",
                conn.con);
            SqlCommand auth2 = new SqlCommand($"SELECT * FROM dbo.manager where " +
                $"[login_manager] = '{textBox1.Text}' AND password = '{textBox2.Text}'",
                conn.con);
            SqlDataReader read1 = auth1.ExecuteReader();
            if (read1.HasRows)
            {
                read1.Read();
                    s = read1[1].ToString();
                MessageBox.Show("Вы успешно авторизовались");
                read1.Close();
                conn coh = new conn();
                coh.dann();
                Form2 fm = new Form2();
                fm.Show();
                this.Hide();
            }
            else
            {
                read1.Close();
                SqlDataReader read2 = auth2.ExecuteReader();
                {
                    if (read2.HasRows)
                    {
                        read2.Read();
                        Form2.id = int.Parse(read2["id"].ToString());
                        MessageBox.Show("Вы успешно авторизовались");
                        read2.Close();
                        conn coh = new conn();
                        coh.dann();
                        Form2 fm = new Form2();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Попробуйте снова");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            conn.con.Close();
        }
    }
}
