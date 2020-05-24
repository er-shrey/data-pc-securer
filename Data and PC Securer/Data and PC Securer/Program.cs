using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Email_Client;

namespace Data_and_PC_Securer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Splash sp = new Splash();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Password());

            }
            else
            {
                MessageBox.Show("No User Found Add First User");
                Application.Run(new Password());
            }
        }
    }
}
