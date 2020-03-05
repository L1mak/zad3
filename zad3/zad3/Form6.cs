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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
            if (Form2.id != 0)
            {
                int i = 0;
                foreach (DataRow dr in conn.data.Tables[0].Rows)
                {
                    if (dr[5].ToString() == Form2.id.ToString())
                        comboBox1.Items.Add("Задача №" + conn.data.Tables[3].Rows[i][0]);
                    i++;
                }
                
            }
            comboBox1.SelectedIndex = 0;
            

        }
        private void update_text()
        {
            string n = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][2].ToString();
            textBox1.Text = n;
            string o = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][3].ToString();
            textBox2.Text = o;
            string sr = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][4].ToString();
            textBox3.Text = sr;
            string d = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][5].ToString();
            textBox4.Text = d;
            string s = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][6].ToString();
            textBox5.Text = s;
            string v = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][7].ToString();
            textBox6.Text = v;
            string i = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][8].ToString();
            textBox7.Text = i;
            string st = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][9].ToString();
            textBox8.Text = st;
            string h = conn.data.Tables[3].Rows[int.Parse(comboBox1.Text[comboBox1.Text.Length - 1].ToString()) - 1][10].ToString();
            textBox9.Text = h;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                button2.Visible = false;
                button1.Visible = true;
            }
            else
            {
                update_text();
                button2.Visible = true;
                button1.Visible = false;
            }
            
        }
    }
}
