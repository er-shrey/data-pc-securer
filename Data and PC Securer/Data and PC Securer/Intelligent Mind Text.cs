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
    public partial class Intelligent_Mind_Text : Form
    {
        public Intelligent_Mind_Text()
        {
            InitializeComponent();
            richTextBox1.KeyPress += new KeyPressEventHandler(richTextBox1_KeyPress);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            richTextBox1.Text = richTextBox1.Text.Replace("A", "4");
            richTextBox1.Text = richTextBox1.Text.Replace("E", "3");
            richTextBox1.Text = richTextBox1.Text.Replace("I", "1");
            richTextBox1.Text = richTextBox1.Text.Replace("O", "0");
            richTextBox1.Text = richTextBox1.Text.Replace("S", "5");
            richTextBox1.Text = richTextBox1.Text.Replace("T", "7");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text|*.txt";
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }
            string file_name = saveFileDialog1.FileName;
            MessageBox.Show(file_name);
            StreamWriter sw = new StreamWriter(file_name);
            sw.WriteLine(richTextBox1.Text);
            sw.Flush();
            sw.Close();
        }
    }
}
