using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChangeDetection
{
    public partial class AddFile : Form
    {
        public AddFile()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private static String filepath = "";
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    String filename = openFileDialog1.FileName;

                    tbFilename.Text = filename;
                    filepath = filename;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void btnNavCompareFile_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompareFile cf = new CompareFile();
            cf.Show();
        }

        private void btnNavConstantCheck_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConstantCheck cc = new ConstantCheck();
            cc.Show();
        }

        private void btnComputeHash_Click(object sender, EventArgs e)
        {
            String Filepath = filepath;
            String MD5Hash = Hashing.MD5Hash(Filepath);
            String SHA256Hash = Hashing.SHA256Hash(Filepath);
            String SHA512Hash = Hashing.SHA512Hash(Filepath);

            tbMD5Hash.Text = MD5Hash;
            tbSHA256Hash.Text = SHA256Hash;
            tbSHA512Hash.Text = SHA512Hash;

            if (DBCalls.checkFileExists(Filepath) == true)
            {
                MessageBox.Show("This File Path Already Has A Record In the Database!");
            }
            else
            {
                int Id = DBCalls.countNoOfFileRecords();
                DBCalls.createFileInfo(Id, Filepath, MD5Hash, SHA256Hash, SHA512Hash);
            }
        }
    }
}
