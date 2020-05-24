using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Email_Client;

namespace Data_and_PC_Securer
{
    public partial class Email_Encryption : Form
    {
        public Email_Encryption()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (char c in richTextBox1.Text)
            {
                char enc = (char)(c + 11);
                richTextBox1.Text = enc.ToString();
            }
            EmailClient ec = new EmailClient();
            ec.Show();
            ec.get_text(richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (char c in richTextBox1.Text)
            {
                char enc = (char)(c - 11);
                richTextBox1.Text = enc.ToString();
            }
        }
    }
}
