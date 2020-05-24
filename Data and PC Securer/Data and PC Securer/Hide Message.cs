using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Data_and_PC_Securer
{
    public partial class Hide_Message : Form
    {
        public Hide_Message()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //save text file
                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(openFileDialog1.FileName) + "\\shrey.txt");
                sw.WriteLine(richTextBox1.Text);
                sw.Flush();
                sw.Close();
                //savebat file
                StreamWriter sw1 = new StreamWriter(Path.GetDirectoryName(openFileDialog1.FileName) + "\\shrey.bat");
                sw1.WriteLine("echo off");
                sw1.WriteLine("cd " + Path.GetDirectoryName(openFileDialog1.FileName));
                sw1.WriteLine("copy /b " + openFileDialog1.SafeFileName + "+shrey.txt " + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "1" + Path.GetExtension(openFileDialog1.FileName));
                sw1.Flush();
                sw1.Close();
            }
            catch
            {
            }
            //running bat file
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = Path.GetDirectoryName(openFileDialog1.FileName) + "\\shrey.bat";
                proc.StartInfo.RedirectStandardError = false;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                proc.WaitForExit();
                MessageBox.Show("Message Hided");
            }
            catch (Exception)
            {
                MessageBox.Show("There exist a file named as :" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "1" + Path.GetExtension(openFileDialog1.FileName) + " please remove it first\nfrom the folder from image");
                File.Delete(Path.GetDirectoryName(openFileDialog1.FileName) + "\\shrey.txt");
                File.Delete(Path.GetDirectoryName(openFileDialog1.FileName) + "\\shrey.bat");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = true;
                MessageBox.Show("To Retrive Message: 1.Open Image in Notepad \n2.Move to the End of File... You Can See The Message");
            }
        }
    }
}
