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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label4.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                SqlDataReader rd;
                cmd = new SqlCommand("select * from online", con);
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    textBox1.Text = rd[0].ToString();
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
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
                    textBox5.Text = rd[2].ToString();
                    textBox4.Text = rd[3].ToString();
                    //if (textBox2.Text == rd[1].ToString())
                    //{
                    //    con.Close();
                    //    if (textBox3.Text != null)
                    //    {
                    //        SqlCommand cmd1;
                    //        try
                    //        {
                    //            con.Open();
                    //            cmd1 = new SqlCommand("update passing set password= '" + textBox3.Text + "'where uname= '" + textBox3.Text + "'", con);
                    //            int temp = cmd1.ExecuteNonQuery();
                    //            if (temp > 0)
                    //            {
                    //                MessageBox.Show("Password updated");
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("password not updated");
                    //            }
                    //            con.Close();
                    //        }
                    //        catch (Exception e5)
                    //        {
                    //            MessageBox.Show(e5.ToString());
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
                   if (textBox2.Text == rd[1].ToString())
                    {
                        con.Close();
                        if (textBox3.Text != null)
                        {
                            SqlCommand cmd1;
                            try
                            {
                                con.Open();
                                cmd1 = new SqlCommand("update passing set password= '" + textBox3.Text + "'where uname= '" + textBox1.Text + "'", con);
                                int temp = cmd1.ExecuteNonQuery();
                                if (temp > 0)
                                {
                                    MessageBox.Show("Password updated");
                                }
                                else
                                {
                                    MessageBox.Show("password not updated");
                                }
                                con.Close();
                            }
                            catch (Exception e5)
                            {
                                MessageBox.Show(e5.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                cmd = new SqlCommand("update passing set outputf= '" + textBox5.Text + "'where uname= '" + textBox1.Text + "'", con);
                int temp = cmd.ExecuteNonQuery();
                if (temp > 0)
                {
                    MessageBox.Show("Output Folder updated");
                }
                else
                {
                    MessageBox.Show("Output Folder not updated");
                }
                con.Close();
            }
            catch (Exception e6)
            {
                MessageBox.Show(e6.ToString());
            }
        }
    }
}
