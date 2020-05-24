using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Email_Client
{
    static class Program
    {
      
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmailClient());
        }
    }
}