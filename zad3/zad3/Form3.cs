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
            SqlCommand koeff = new SqlCommand($"SELECT [Junior_мин_ЗП],[Middle_мин_ЗП]," +
            $"[Senior_мин_ЗП],[Коэффициент_для_Анализ_и_проектирование]," +
            $"[Коэффициент_для_Техническое_обслуживание_и_сопровождение]," +
            $"[Коэффициент_для_Установка_оборудования],[Коэффициент_времени]," +
            $"[Коэффициент_сложности],[Коэффициент_для_перевода_в_денежный_эквивалент]" +
            $"FROM salary, dbo.koeff, manager WHERE salary.id_salary = '{Form2.id}' " +
            $"AND koeff.id='{Form2.id}' AND manager.id_koeff='{Form2.id}'", conn.con);
        SqlDataReader read = koeff.ExecuteReader();
                while (read.Read())
                {
                    textBox1.Text = read[0].ToString();
                    textBox2.Text = read[1].ToString();
                    textBox3.Text = read[2].ToString();
                    textBox4.Text = read[3].ToString();
                    textBox5.Text = read[4].ToString();
                    textBox6.Text = read[5].ToString();
                    textBox7.Text = read[6].ToString();
                    textBox8.Text = read[7].ToString();
                    textBox9.Text = read[8].ToString();
                }
            conn.con.Close();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.con.Open();
            SqlCommand update = new SqlCommand($"UPDATE ", conn.con);
            conn.con.Open();
        }
    }
}
