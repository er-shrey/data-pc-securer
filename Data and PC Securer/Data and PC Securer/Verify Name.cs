using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Data_and_PC_Securer
{
    public partial class Verify_Name : Form
    {
        string pass;
        public Verify_Name()
        {
            InitializeComponent();
        }
        public void get_pass(string p)
        {
            pass = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter Name First");
                textBox1.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                    SqlCommand cmd;
                    con.Open();
                    SqlDataReader rd;
                    cmd = new SqlCommand("select * from passing where uname='" + textBox1.Text + "'", con);
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        if (pass == rd[1].ToString())
                        {
                            con.Close();
                            try
                            {
                                SqlCommand cmd1;
                                con.Open();
                                cmd1 = new SqlCommand("insert into online values('" + textBox1.Text + "')", con);
                                int tempo = cmd.ExecuteNonQuery();
                                if (tempo > 0)
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Must Work Offline");
                                }
                                con.Close();
                            }
                            catch (Exception e2)
                            {
                                MessageBox.Show(e2.ToString());
                            }
                            Data_and_PC_Securer dp = new Data_and_PC_Securer();
                            this.Close();
                            dp.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password or invalid User Name");
                            Password pw = new Password();
                            pw.Show();
                            this.Close();                           
                        }
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            }
        }
    }
}
