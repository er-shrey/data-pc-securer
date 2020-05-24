using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Folder_Compression
{
    public partial class Compression : Form
    {
        string recieve;
        int count = 0;
        float prog;
       // int file_count = 0;
        public Compression()
        {
            InitializeComponent();
        }

        private void Folder_Compression_Load(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    recieve = folderBrowserDialog1.SelectedPath;
                    label1.Text = recieve;
                    DirectoryInfo di = new DirectoryInfo(recieve);
                    //counting files
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        count++;
                    }
                    prog = 100 / count;
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Compress(FileInfo fi)
        {
            using (FileStream inFile = fi.OpenRead())
            {
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    using (FileStream outFile = File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                        {
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                Compress.Write(buffer, 0, numRead);
                            }
                        }
                    }
                }
            }
            File.Delete(fi.FullName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            // Compress the directory's files. 
            DirectoryInfo di = new DirectoryInfo(recieve);
            foreach (FileInfo fi in di.GetFiles())
            {
                label2.Text = fi.Name;
                Compress(fi);
                //file_count++;
                prog += prog;
                progressBar1.Increment((int)prog);
            }
            MessageBox.Show("Compression Completed");
            this.UseWaitCursor = false;
        }
    }
}
