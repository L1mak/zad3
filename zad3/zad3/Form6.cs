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
        List<int> SADAME = new List<int>();
        private void load()
        {
            conn SANECHINE = new conn();
            SANECHINE.dann();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Add("Создать");
            foreach (string s in Form1.s)
            {
                foreach (DataRow dr in conn.data.Tables[3].Rows)
                    if (dr[1].ToString() == s)
                    {
                        comboBox1.Items.Add("Задача №" + dr[0].ToString());
                        SADAME.Add(int.Parse(dr[0].ToString()));
                    }
            }
            foreach (string isp in Form1.s)
            {
                foreach (DataRow dr in conn.data.Tables[3].Rows)
                    if (dr[1].ToString() == isp)
                    {
                        if (!comboBox2.Items.Contains(dr[8].ToString()))
                        comboBox2.Items.Add(dr[8].ToString());
                    }
            }

                
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

        }


        private void Form6_Load(object sender, EventArgs e)
        {

            load();
            
        }

        private void update_text()
        {
            string n = 
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex-1]-1][2].ToString();
            textBox1.Text = n;
            string o =
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][3].ToString();
            textBox2.Text = o;
            string sr =
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][4].ToString();
            dateTimePicker1.Value = DateTime.Parse(sr);
            string d = 
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][5].ToString();
            dateTimePicker2.Value = DateTime.Parse(d);
            string s = 
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][6].ToString();
            textBox3.Text = s;
            string v = 
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][7].ToString();
            textBox6.Text = v;
            string i =
            conn.data.Tables[3].Rows[SADAME[comboBox1.SelectedIndex - 1]-1][8].ToString();
            foreach (DataRow drr in conn.data.Tables[3].Rows)
            {
                if (drr[9].ToString() == "plan")
                 comboBox4.SelectedIndex = 0;
                if (drr[9].ToString() == "runing")
                comboBox4.SelectedIndex = 1;
                if (drr[9].ToString() == "finished")
                    comboBox4.SelectedIndex = 2;
                if (drr[9].ToString() == "canceled")
               comboBox4.SelectedIndex = 3;
            }
            foreach (DataRow doto in conn.data.Tables[3].Rows)
            {
                if (doto[10].ToString() == "support")
                    comboBox5.SelectedIndex = 0;
                if (doto[10].ToString() == "deployment")
                    comboBox5.SelectedIndex = 1;
                if (doto[10].ToString() == "analysis")
                    comboBox5.SelectedIndex = 2;

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBox3.Text = "";
                textBox6.Text = "";

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string stat = comboBox4.SelectedIndex == 0?"plan": comboBox4.SelectedIndex == 1?
                "runing": comboBox4.SelectedIndex == 2?"finished":"canceled";
            string har = comboBox5.SelectedIndex == 0 ? "support":comboBox5.SelectedIndex == 1?
                "deployment":"analysis";
            conn.con.Open();
            SqlCommand update = new SqlCommand($"UPDATE tasks SET " +
                $"[Заголовок]= '{textBox1.Text}',[Описание_задачи]= '{textBox2.Text}'," +
                $"[Срок_исполнения]= '{dateTimePicker1.Value}'," +
                $"[Дата_выполнения]= '{dateTimePicker2.Value}',[Сложность]= '{textBox3.Text}'," +
                $"[Время_на_задачу]= '{textBox6.Text}',[Исполнитель_Задачи]= '{comboBox2.Text}'," +
                $"[Статус]= '{stat}',[Характер_работы]= '{har}'" +
                $" WHERE [id_task] = '{SADAME[comboBox1.SelectedIndex - 1]}'", conn.con);
            update.ExecuteNonQuery();
            conn.con.Close();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRow dr in conn.data.Tables[3].Rows)
                i = int.Parse(dr[0].ToString());
            string stat = comboBox4.SelectedIndex == 0 ? "plan" : comboBox4.SelectedIndex == 1 ? "runing" : comboBox4.SelectedIndex == 2 ? "finished" : "canceled";
            string har = comboBox5.SelectedIndex == 0 ? "support" : comboBox5.SelectedIndex == 1 ? "deployment" : "analysis";
            conn.con.Open();
            SqlCommand create = new SqlCommand($"INSERT INTO tasks" +
                $"([id_task],[Login_executor],[Заголовок],[Описание_задачи]," +
                $"[Срок_исполнения],[Дата_выполнения]," +
                $"[Сложность],[Время_на_задачу],[Исполнитель_Задачи],[Статус]," +
                $"[Характер_работы]) VALUES ('{i+1}', " +
                $"'{Form1.s[comboBox1.SelectedIndex]}','{textBox1.Text}', '{textBox2.Text}'," +
                $" '{dateTimePicker1.Value}', '{dateTimePicker2.Value}'," +
                $"'{textBox3.Text}','{textBox6.Text}','{comboBox2.Text}','{stat}','{har}')"
                , conn.con);
            create.ExecuteNonQuery();
            conn.con.Close();
            load();

        }
    }
}
