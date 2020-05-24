using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Data_and_PC_Securer
{
    public partial class Hide_Folder : Form
    {
        public Hide_Folder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = System.IO.Path.GetFileName(textBox1.Text);
            // encrypt the only folder name
            foreach (char c in textBox2.Text)
            {
                char enc = (char)(c + 1);
                textBox2.Text = enc.ToString();
            }
            // rename folder with encrypted name
            File.Move(folderBrowserDialog1.SelectedPath.ToString(), System.IO.Path.GetDirectoryName(folderBrowserDialog1.SelectedPath).ToString() + "\\" + textBox2.Text);
            // save encrypt name with original folder name in DB // put attributes over it by DOS commands
            if (textBox1.Text != "" | textBox2.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                    SqlCommand cmd;
                    con.Open();
                    cmd = new SqlCommand("insert into hide_folder values('" + textBox2.Text + "','" + System.IO.Path.GetFileName(textBox1.Text) + "','" + System.IO.Path.GetDirectoryName(folderBrowserDialog1.SelectedPath) + "')", con);
                    int tempo = cmd.ExecuteNonQuery();
                    if (tempo > 0)
                    {
                        StreamWriter sw1 = new StreamWriter(@"c:\shrey.bat");
                        sw1.WriteLine("@ECHO OFF");
                        sw1.WriteLine("cd\\");
                        sw1.WriteLine("attrin +r +a +s +h +i " + System.IO.Path.GetDirectoryName(folderBrowserDialog1.SelectedPath) + "\\" + textBox2.Text + " /s /d /l ");
                        sw1.Close();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unknown error");
                    }
                }
                catch (Exception e7)
                {
                    MessageBox.Show(e7.ToString());
                }
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = @"c:\shrey.bat";
                    proc.StartInfo.RedirectStandardError = false;
                    proc.StartInfo.RedirectStandardOutput = false;
                    proc.StartInfo.UseShellExecute = false;
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (Exception)
                {

                }
                File.Delete(@"c:\shrey.bat");
            }
            else
            {
                MessageBox.Show("No Folder Selected");
            }
            // show the original name in hidden folder box
            refreshlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select encrypted name from the original folder name from DB
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                SqlDataReader rd;
                cmd = new SqlCommand("select * from hide_folder where Oname='" + mycheckedListBox.SelectedItem.ToString() + "'", con);
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    File.Delete(@"c:\shrey.bat");
                    StreamWriter sw1 = new StreamWriter(@"c:\shrey.bat");
                    sw1.WriteLine("@ECHO OFF");
                    sw1.WriteLine("cd\\");
                    sw1.WriteLine("attrin -r -a -s -h -i " + rd[2].ToString() + "\\" + rd[0].ToString() + " /s /d /l ");
                    sw1.Close();
                    // rename folder by original name
                    File.Move(rd[2].ToString() + "//" + rd[0].ToString(), rd[2].ToString() + "//" + rd[1].ToString());
                    
                    con.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
            // remove attrib from encrypted name folder
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = @"c:\shrey.bat";
                proc.StartInfo.RedirectStandardError = false;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception)
            {

            }
            File.Delete(@"c:\shrey.bat");
            // delete row
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                cmd = new SqlCommand("delete from hide_folder where Oname='" + mycheckedListBox.SelectedItem.ToString() + "'", con);
                con.Close();
            }
            catch (Exception e10)
            {
                MessageBox.Show(e10.ToString());
            }
            //refreshing list
            refreshlist();
        }

        private void refreshlist()
        {
            mycheckedListBox.Items.Clear();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SHREYKUMARJAIN\\SHREYKUMARJAIN; Initial Catalog=DataSecurer; Integrated Security=TRUE");
                SqlCommand cmd;
                con.Open();
                SqlDataReader rd;
                cmd = new SqlCommand("select Oname from hide_folder'" , con);
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    foreach (string a in rd)
                    {
                        mycheckedListBox.Items.Add(a);
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
