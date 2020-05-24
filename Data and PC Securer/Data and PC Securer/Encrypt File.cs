using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Data_and_PC_Securer
{
    public partial class Encrypt_File : Form
    {
        string passkey;
        string ofolder;
        string Sname;
        public Encrypt_File()
        {
            InitializeComponent();
            //key selection
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
                            passkey = rd1[1].ToString();
                            ofolder = rd1[2].ToString();
                            if (rd1[3].ToString() != "")
                            {
                                passkey = rd1[3].ToString();
                            }
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = @"c:\";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        mycheckedListBox.Items.Add(fileName, CheckState.Unchecked);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                mycheckedListBox.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                {
                    if (mycheckedListBox.GetItemChecked(i) == true)
                    {
                        mycheckedListBox.Items.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void selectall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectall.Checked == true)
                {
                    unselectall.Checked = false;
                    for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                    {
                        mycheckedListBox.SetItemChecked(i, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void unselectall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (unselectall.Checked == true)
                {
                    selectall.Checked = false;
                    for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                    {
                        mycheckedListBox.SetItemChecked(i, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "DES")
            {
                DES();
            }
            else if (comboBox1.Text == "AES")
            {
                AES();
            }
            else if (comboBox1.Text == "Uni Cipher")
            {
                Unicipher();
            }
        }

        public void DES()
        {
            try
            {
                for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                {
                    if (mycheckedListBox.GetItemChecked(i) == true)
                    {
                        try
                        {
                            ///normal encryption
                            try
                            {
                                UnicodeEncoding UE = new UnicodeEncoding();
                                byte[] key = UE.GetBytes(passkey);
                                string cryptFile = mycheckedListBox.Items[i].ToString();
                                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                                RijndaelManaged RMCrypto = new RijndaelManaged();
                                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                                FileStream fsIn = new FileStream(ofolder + "\\" + Path.GetFileName(mycheckedListBox.Items[i].ToString()), FileMode.Open);
                                int data;
                                while ((data = fsIn.ReadByte()) != -1) cs.WriteByte((byte)data);
                                fsIn.Close();
                                cs.Close();
                                fsCrypt.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Encryption failed!", "Error");
                            }
                        }
                        catch (Exception e11)
                        {
                            MessageBox.Show(e11.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check a Renaming Style First... See on lect Round Selections");
                MessageBox.Show(ex.ToString());
            }
        }

        public void Unicipher()
        {
            try
            {
                for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                {
                    if (mycheckedListBox.GetItemChecked(i) == true)
                    {
                        try
                        {
                            UnicodeEncoding UE = new UnicodeEncoding();
                            byte[] key = UE.GetBytes(passkey);
                            string cryptFile = mycheckedListBox.Items[i].ToString();
                            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                            RijndaelManaged RMCrypto = new RijndaelManaged();
                            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                            FileStream fsIn = new FileStream(ofolder + "\\" + Path.GetFileName(mycheckedListBox.Items[i].ToString()), FileMode.Open);
                            Sname = ofolder + "\\" + Path.GetFileName(mycheckedListBox.Items[i].ToString());
                            int data;
                            while ((data = fsIn.ReadByte()) != -1) cs.WriteByte((byte)data);
                            fsIn.Close();
                            cs.Close();
                            fsCrypt.Close();

                        }
                        catch (Exception e11)
                        {
                            MessageBox.Show(e11.ToString());
                        }
                        try
                        {
                            UnicodeEncoding UE = new UnicodeEncoding();
                            byte[] key = UE.GetBytes(passkey);
                            string cryptFile = Sname;
                            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                            RijndaelManaged RMCrypto = new RijndaelManaged();
                            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                            FileStream fsIn = new FileStream(Sname, FileMode.Open);
                            int data;
                            while ((data = fsIn.ReadByte()) != -1) cs.WriteByte((byte)data);
                            fsIn.Close();
                            cs.Close();
                            fsCrypt.Close();
                        }
                        catch (Exception e11)
                        {
                            MessageBox.Show(e11.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check a Renaming Style First... See on lect Round Selections");
                MessageBox.Show(ex.ToString());
            }
        }

        public void AES()
        {
            try
            {
                for (int i = 0; i < mycheckedListBox.Items.Count; i++)
                {
                    if (mycheckedListBox.GetItemChecked(i) == true)
                    {
                        try
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                UnicodeEncoding UE = new UnicodeEncoding();
                                byte[] key = UE.GetBytes(passkey);
                                string cryptFile = mycheckedListBox.Items[i].ToString();
                                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                                RijndaelManaged RMCrypto = new RijndaelManaged();
                                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                                FileStream fsIn = new FileStream(ofolder + "\\" + Path.GetFileName(mycheckedListBox.Items[i].ToString()), FileMode.Open);
                                int data;
                                while ((data = fsIn.ReadByte()) != -1) cs.WriteByte((byte)data);
                                fsIn.Close();
                                cs.Close();
                                fsCrypt.Close();
                            }
                        }
                        catch (Exception e11)
                        {
                            MessageBox.Show(e11.ToString());
                        }
                        for (int j = 0; j < 2; j++)
                        {
                            try
                            {
                                UnicodeEncoding UE = new UnicodeEncoding();
                                byte[] key = UE.GetBytes(passkey);
                                string cryptFile = Sname;
                                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                                RijndaelManaged RMCrypto = new RijndaelManaged();
                                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                                FileStream fsIn = new FileStream(Sname, FileMode.Open);
                                int data;
                                while ((data = fsIn.ReadByte()) != -1) cs.WriteByte((byte)data);
                                fsIn.Close();
                                cs.Close();
                                fsCrypt.Close();
                            }
                            catch (Exception e11)
                            {
                                MessageBox.Show(e11.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check a Renaming Style First... See on lect Round Selections");
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
