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
    public partial class Encrypt_full_Drive : Form
    {
        public Encrypt_full_Drive()
        {
            InitializeComponent();
        }

        private void Encrypt_full_Drive_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            richTextBox3.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                checkedListBox1.Items.Add(d.Name);
                richTextBox3.Text = richTextBox3.Text + d.DriveType +" :  " + d.VolumeLabel + "\n";
            }
        }
    }
}
