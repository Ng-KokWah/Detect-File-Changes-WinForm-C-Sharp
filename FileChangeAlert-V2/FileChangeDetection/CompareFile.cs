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
    public partial class CompareFile : Form
    {
        public CompareFile()
        {
            InitializeComponent();
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private static String filepath = "";
        private static String MD5Hash = "";
        private static String SHA256Hash = "";
        private static String SHA512Hash = "";

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
                    MD5Hash = Hashing.MD5Hash(filename);
                    SHA256Hash = Hashing.SHA256Hash(filename);
                    SHA512Hash = Hashing.SHA512Hash(filename);
                }
            }catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void btnNavAddFile_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddFile af = new AddFile();
            af.Show();
        }

        private void btnNavConstantCheck_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConstantCheck cc = new ConstantCheck();
            cc.Show();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FileModel fm = DBCalls.retrieveSingleFileInfo(filepath);
            
            if(fm.MD5Hash != MD5Hash || fm.SHA256Hash != SHA256Hash || fm.SHA512Hash != SHA512Hash)
            {
                tbModifiedStats.Text = "The File Has Been Modified";
            }
            else
            {
                tbModifiedStats.Text = "The File Is The Same As The Original";
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("Hash Types");
            dt.Columns.Add("Original");
            dt.Columns.Add("Current");

            dt.Rows.Add("MD5 Hash", fm.MD5Hash, MD5Hash);
            dt.Rows.Add("SHA256 Hash", fm.SHA256Hash, SHA256Hash);
            dt.Rows.Add("SHA512 Hash", fm.SHA512Hash, SHA512Hash);

            dataGridView1.DataSource = dt;
        }
    }
}
