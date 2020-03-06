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
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
            
        }
        private void load()
        {
            dataGridView1.Rows.Clear();
            if (Form2.id != 0)
            {
                Form1.s.Clear();
                foreach (DataRow dr in conn.data.Tables[0].Rows)
                    if (dr[5].ToString() == Form2.id.ToString())
                    {
                        Form1.s.Add(dr[1].ToString());
                    }
            }
            foreach (string k in Form1.s)
                foreach (DataRow dr in conn.data.Tables[3].Rows)
                    if (k == dr[1].ToString())
                    {
                        DataGridViewRow dg = new DataGridViewRow();
                        dg.Cells.Add(new DataGridViewTextBoxCell { Value = dr[0].ToString() });
                        dg.Cells.Add(new DataGridViewTextBoxCell { Value = dr[2].ToString() });
                        dg.Cells.Add(new DataGridViewTextBoxCell { Value = dr[9].ToString() });
                        foreach (DataRow drr in conn.data.Tables[0].Rows)
                            if (drr[1].ToString() == k)
                            {
                                dg.Cells.Add(new DataGridViewTextBoxCell { Value = drr[4].ToString() });
                                foreach (DataRow drg in conn.data.Tables[1].Rows)
                                    if (drg[0].ToString() == drr[5].ToString())
                                        dg.Cells.Add(new DataGridViewTextBoxCell { Value = drg[3] });
                            }
                        dataGridView1.Rows.Add(dg);
                    }
            if (Form2.id != 0)
                comboBox1.Visible = true;
            else
                label2.Visible = false;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
