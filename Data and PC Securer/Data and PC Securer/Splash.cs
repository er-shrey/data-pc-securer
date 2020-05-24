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
    public partial class Splash : Form
    {
        int t = 0;
        public Splash()
        {
            InitializeComponent();
            timer1.Interval = 3000;
            timer1.Start();
            timer2.Interval = 300;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            if (t == 4)
            {
                this.DialogResult = DialogResult.No;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (t == 0)
            {
                label3.Text = "Initializing .";
                t++;
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                con.Open();
                label4.Text = "Database " + con.State.ToString();
                con.Close();
            }
            else if (t == 1)
            {
                label3.Text = "Initializing . .";
                t++;
            }
            else if (t == 2)
            {
                label3.Text = "Initializing . . .";
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator) == true)
                {
                    label4.Text = "User : Admin";
                }
                else
                {
                    label4.Text = "User : General";
                }
                t++;
            }
            else if (t == 3)
            {
                label3.Text = "Initializing . . .";
                t = 0;
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                SqlDataReader rd;
                cmd = new SqlCommand("select count(*) from passing ", con);
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    if (Convert.ToInt32(rd[0]) <= 0)
                    {
                        label4.Text = "No User Found";
                        t = 4;
                    }
                    else
                    {
                        label4.Text = "User Found" + Convert.ToInt32(rd[0]);
                    }
                }
            }
        }
    }
}
