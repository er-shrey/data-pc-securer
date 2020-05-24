using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Email_Client;
using Folder_Compression;

namespace Data_and_PC_Securer
{
    public partial class Data_and_PC_Securer : Form
    {
        public Data_and_PC_Securer()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("delete from online", con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            con.Close();
            Password p = new Password();
            p.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Encrypt_File ef = new Encrypt_File();
            ef.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Encrypt_File ef = new Encrypt_File();
            ef.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Decrypt_file df = new Decrypt_file();
            df.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Decrypt_file df = new Decrypt_file();
            df.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Compression c = new Compression();
            c.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Compression c = new Compression();
            c.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Hide_Folder hf = new Hide_Folder();
            hf.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hide_Folder hf = new Hide_Folder();
            hf.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Intelligent_Mind_Text imt = new Intelligent_Mind_Text();
            imt.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Intelligent_Mind_Text imt = new Intelligent_Mind_Text();
            imt.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Hide_Message hm = new Hide_Message();
            hm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Hide_Message hm = new Hide_Message();
            hm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Email_Encryption ee = new Email_Encryption();
            ee.Show();
            //EmailClient ec = new EmailClient();
            //ec.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Email_Encryption ee = new Email_Encryption();
            ee.Show();
            //EmailClient ec = new EmailClient();
            //ec.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            WiFi_Encryption wf = new WiFi_Encryption();
            wf.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WiFi_Encryption wf = new WiFi_Encryption();
            wf.Show();
        }

        private void Data_and_PC_Securer_Load(object sender, EventArgs e)
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
                    label10.Text = rd[0].ToString();
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }
    }
}
