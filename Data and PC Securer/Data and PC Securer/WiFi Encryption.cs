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
    public partial class WiFi_Encryption : Form
    {
        public WiFi_Encryption()
        {
            InitializeComponent();
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
                    con.Close();
                    try
                    {
                        SqlConnection con1 = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                        SqlCommand cmd1;
                        con1.Open();
                        SqlDataReader rd1;
                        cmd1 = new SqlCommand("select * from passing where uname='" + rd[0].ToString() + "'", con1);
                        rd1 = cmd.ExecuteReader();
                        if (rd1.Read() == true)
                        {
                            openFileDialog1.InitialDirectory = rd1[2].ToString();
                        }
                        con1.Close();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
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
