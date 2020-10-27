using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChangeDetection
{
    public partial class ConstantCheck : Form
    {
        public ConstantCheck()
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

        private void btnNavAddFile_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddFile af = new AddFile();
            af.Show();
        }

        private void btnNavCompareFile_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompareFile cf = new CompareFile();
            cf.Show();
        }

        private static String filepath = "";
        private static String MD5Hash = "";
        private static String SHA256Hash = "";
        private static String SHA512Hash = "";

        private static String Email = "";
        private static String Password = "";

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    if (DBCalls.checkConstantAlertExists(filepath) == true)
                    {
                        tbFilename.Text = filepath;

                        ConstantAlertModel ca = DBCalls.retrieveSingleConstantAlertInfo(filepath);

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Hash Types");
                        dt.Columns.Add("Hash Values");

                        dt.Rows.Add("MD5", ca.MD5Hash);
                        dt.Rows.Add("SHA256", ca.SHA256Hash);
                        dt.Rows.Add("SHA512", ca.SHA512Hash);

                        tbEmail.Text = ca.Email;
                        tbPassword.Text = ca.Password;

                        Email = ca.Email;
                        Password = ca.Password;

                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        String filename = openFileDialog1.FileName;
                        tbFilename.Text = filename;

                        filepath = filename;
                        MD5Hash = Hashing.MD5Hash(filename);
                        SHA256Hash = Hashing.SHA256Hash(filename);
                        SHA512Hash = Hashing.SHA512Hash(filename);

                        

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Hash Types");
                        dt.Columns.Add("Hash Values");

                        dt.Rows.Add("MD5", MD5Hash);
                        dt.Rows.Add("SHA256", SHA256Hash);
                        dt.Rows.Add("SHA512", SHA512Hash);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //retrieve original file stuff
            ConstantAlertModel ca = DBCalls.retrieveSingleConstantAlertInfo(filepath);

            MD5Hash = Hashing.MD5Hash(filepath);
            SHA256Hash = Hashing.SHA256Hash(filepath);
            SHA512Hash = Hashing.SHA512Hash(filepath);

            DataTable dt = new DataTable();
            dt.Columns.Add("Hash Types");
            dt.Columns.Add("Hash Values");

            dt.Rows.Add("MD5", MD5Hash);
            dt.Rows.Add("SHA256", SHA256Hash);
            dt.Rows.Add("SHA512", SHA512Hash);

            dataGridView2.DataSource = dt;

            btnStart.Text = "Start";
            hasStarted = false;

            if (MD5Hash != ca.MD5Hash || SHA256Hash != ca.SHA256Hash || SHA512Hash != ca.SHA512Hash)
            {
                //never set email alert
                if (String.IsNullOrEmpty(Email) || String.IsNullOrWhiteSpace(Email) || String.IsNullOrEmpty(Password) || String.IsNullOrWhiteSpace(Password))
                {
                    timer1.Stop();
                    tbModifiedStats.Text = "File Has Been Modified!";
                    MessageBox.Show("File Has Been Modified!");
                }
                //got set email alert
                else
                {
                    timer1.Stop();
                    MessageBox.Show("File Has Been Modified!");
                    tbModifiedStats.Text = "File Has Been Modified!";

                    string[] temp = Email.Split('@');
                    SmtpClient smtpClient = new SmtpClient();
                    if (temp[1].Contains("gmail"))
                    {
                        smtpClient = new SmtpClient("smtp.gmail.com");
                    }
                    else if (temp[1].Contains("yahoo"))
                    {
                        smtpClient = new SmtpClient("smtp.mail.yahoo.com");
                    }
                    else
                    {
                        smtpClient = new SmtpClient("smtp.live.com");
                    }

                    //most mail like gmail requires ssl to be enabled to send emails else it would fail
                    smtpClient.EnableSsl = true;
                    // set smtp-client with basicAuthentication
                    smtpClient.UseDefaultCredentials = false;
                    //set the credentials to login to the email, like the username and password
                    //put in the email and password of your admin email
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                       System.Net.NetworkCredential("", "");
                    smtpClient.Credentials = basicAuthenticationInfo;

                    //add the to and from addresses
                    //set in the admin email again
                    MailAddress from = new MailAddress("");
                    MailAddress to = new MailAddress(Email);
                    MailMessage mail = new System.Net.Mail.MailMessage(from, to);

                    /*// add ReplyTo only if needed
                    MailAddress replyTo = new MailAddress(sender);
                    mail.ReplyToList.Add(replyTo);
                    */
                    // set subject and encoding type
                    mail.Subject = "Contents to " + filepath + " was changed!";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    String shortName = filepath.Split('\\')[filepath.Split('\\').Length - 1];
                    int indexOfShortName = filepath.IndexOf(shortName);

                    // set message and encoding type
                    mail.Body = "The hash value for this file differs from the original hash value recorded Info are as follows";
                    mail.Body += "File Path: " + filepath + "\n\n";
                    mail.Body += "The Previous MD5 Hash was: " + ca.MD5Hash + "\n\n";
                    mail.Body += "The New MD5 Hash is: " + MD5Hash + "\n\n";
                    mail.Body += "The Previous SHA256 Hash was: " + ca.SHA256Hash + "\n\n";
                    mail.Body += "The New SHA256 Hash is: " + SHA256Hash + "\n\n";
                    mail.Body += "The Previous SHA512 Hash was: " + ca.SHA512Hash + "\n\n";
                    mail.Body += "The New SHA512 Hash is: " + SHA512Hash + "\n\n";

                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    // if pure text set to false if html codes are involved set to true
                    mail.IsBodyHtml = false;

                    smtpClient.Send(mail);
                }
            }
        }

        private static Boolean hasStarted = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (hasStarted == true)
            {
                timer1.Stop();
                btnStart.Text = "Start";
                hasStarted = false;
            }
            else
            {
                timer1.Start();
                btnStart.Text = "Stop";
                hasStarted = true;

                int Id = DBCalls.countNoOfConstantAlertRecords();
                DBCalls.createConstantAlertInfo(Id, tbEmail.Text, tbPassword.Text, filepath, MD5Hash, SHA256Hash, SHA512Hash);
            }
        }
    }
}
