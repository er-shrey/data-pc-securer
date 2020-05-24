using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Principal;

namespace Data_and_PC_Securer
{
    public partial class Password : Form
    {
        string name;
        public Password()
        {
            InitializeComponent();
        }

        private void unlock_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter Password First");
                textBox1.Focus();
            }
            else
            {
                if (name != null)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                        SqlCommand cmd;
                        con.Open();
                        SqlDataReader rd;
                        cmd = new SqlCommand("select * from passing where uname='" + name + "'", con);
                        rd = cmd.ExecuteReader();
                        if (rd.Read() == true)
                        {
                            if (textBox1.Text == rd[1].ToString())
                            {
                                con.Close();
                                try
                                {
                                    SqlCommand cmd1;
                                    con.Open();
                                    cmd1 = new SqlCommand("insert into online values('" + name + "')", con);
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
                                timer1.Start();
                                timer1.Interval = 50;
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password");
                                textBox1.Clear();
                                textBox1.Focus();
                            }
                        }
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                }
                else
                {
                    Verify_Name vn = new Verify_Name();
                    vn.Show();
                    vn.get_pass(textBox1.Text);
                    this.Hide();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Size tempsize = pictureBox2.Size;
            tempsize.Height--;
            pictureBox2.Size = tempsize;
            pictureBox3.Size = tempsize;
            if (tempsize.Height < 0)
            {
                timer1.Stop();
                Data_and_PC_Securer dp = new Data_and_PC_Securer();
                this.Hide();
                dp.Show();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox7.Visible == false)
            {
                pictureBox6.ImageLocation = @"E:\Main Project\Data and PC Securer\Data and PC Securer\Resources\SlArrow2.png";
                timer2.Start();
                timer2.Interval = 1;
            }
            else
            {
                pictureBox6.ImageLocation = @"E:\Main Project\Data and PC Securer\Data and PC Securer\Resources\SlArrow.png";
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                pictureBox7.Visible = false;
                //pictureBox8.Visible = false;
                //label1.Visible = false;
                //label2.Visible = false;
                //textBox2.Visible = false;
                //textBox3.Visible = false;
                //button4.Visible = false;
                groupBox1.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Size tempsize = pictureBox7.Size;
            tempsize.Width++;
            pictureBox7.Visible = true;
            pictureBox7.Size = tempsize;
            if (tempsize.Width >= 286)
            {
                timer2.Stop();
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (pictureBox8.Visible == false)
            //{
            //    pictureBox8.Visible = true;
            //    label1.Visible = true;
            //    label2.Visible = true;
            //    textBox2.Visible = true;
            //    textBox3.Visible = true;
            //    button4.Visible = true;
            //}
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator) == true)
            {
                if (groupBox1.Visible == false)
                {
                    groupBox1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Only Admin of this Computer can Add User");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator).ToString() == "true")
            {
                name = "administrator";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" | textBox3.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                    SqlCommand cmd;
                    con.Open();
                    cmd = new SqlCommand("insert into passing values('" + textBox2.Text + "','" + textBox3.Text + "')", con);
                    int tempo = cmd.ExecuteNonQuery();
                    if (tempo > 0)
                    {
                        MessageBox.Show("User Added");
                    }
                    else
                    {
                        MessageBox.Show("Unknown error during Adding User");
                    }
                }
                catch (Exception e7)
                {
                    MessageBox.Show(e7.ToString());
                }
            }
        }
    }
}
