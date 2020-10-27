using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChangeDetection
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
            Application.Run(new AddFile());
        }

        /// <summary>
        /// NOTE: When using this on a new computer, you would need to change the connection string
        /// stored in the app.config by:
        /// 1. double click on the FileDB.mdf file
        /// 2. under the properties find Connection String
        /// 3. Paste this connection string in the App.config file
        /// 4. remove the double quotes " after the AttachDbFilename to prevent error from showing
        /// 
        /// In addition you would also need to go to ConstantAlert Form to add in an 
        /// admin email and password if you want the user to be able to receive an alert everytime
        /// the file is changed
        /// </summary>
    }
}
