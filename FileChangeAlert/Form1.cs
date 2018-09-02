using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChangeAlert
{
    public partial class Form1 : Form
    {
        private string type = "";
        public Form1()
        {
            InitializeComponent();
        }

        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            //this time is in milliseconds 10000 should be fine, i think
            timer1.Interval = 3000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (type == "file")
            {
                if (FileHandling.fileExists(file1.Text))
                {
                    DateTime dt = FileHandling.getModifiedDateForLog(file1.Text);
                    DateTime oldTime = Convert.ToDateTime(FileHandling.ReadFromFile("../../Logs/File1/oldTime.txt"));
                    //Console.WriteLine("New Time: " + dt.ToString());
                    //Console.WriteLine("Old Time: " + oldTime.ToString());

                    if (dt.ToString() != oldTime.ToString())
                    {
                        //send email first
                        //System.Diagnostics.Debug.WriteLine("post load " + sender + " " + password);
                        //"smtp.mail.yahoo.com" for yahoo
                        //"smtp.live.com" for hotmail
                        //all on port 587 & requires ssl
                        string[] temp = Form2.email.Split('@');
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
                        System.Net.NetworkCredential basicAuthenticationInfo = new
                           System.Net.NetworkCredential(Form2.email, Form2.password);
                        smtpClient.Credentials = basicAuthenticationInfo;

                        //add the to and from addresses
                        MailAddress from = new MailAddress(Form2.email);
                        MailAddress to = new MailAddress(email.Text);
                        MailMessage mail = new System.Net.Mail.MailMessage(from, to);

                        /*// add ReplyTo only if needed
                        MailAddress replyTo = new MailAddress(sender);
                        mail.ReplyToList.Add(replyTo);
                        */
                        // set subject and encoding type
                        mail.Subject = "Contents to " + file1.Text.Split('\\')[file1.Text.Split('\\').Length - 1] + " was changed!";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;

                        String shortName = file1.Text.Split('\\')[file1.Text.Split('\\').Length - 1];
                        int indexOfShortName = file1.Text.IndexOf(shortName);
                        String testForAlternateDataStream = RunCommand.RunCmdGetOutputForLog("dir /r " + shortName, file1.Text.Substring(0, indexOfShortName));
                        // set message and encoding type
                        mail.Body = "File Path: " + file1.Text + "\n\n";
                        mail.Body += "The Previous Modified/Created Timing was: " + oldTime.ToString() + "\n\n";
                        mail.Body += "The New Modified Time Detected was: " + dt.ToString() + "\n\n";
                        mail.Body += "Alternate Data Stream (ADS) Testing: \n\n On directory " + file1.Text.Substring(0, indexOfShortName) + " using command (using dir /r " + shortName + ") \n\n";
                        mail.Body += testForAlternateDataStream + "\n\n";
                        mail.Body += "If there is an ADS present it should be in this format <fileName>:<hiddenFileName>:$DATA \n e.g. test.txt:hidden.txt:$DATA";
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        // if pure text set to false if html codes are involved set to true
                        mail.IsBodyHtml = false;

                        smtpClient.Send(mail);

                        //replace the old file
                        if (FileHandling.fileExists("../../Logs/File1/oldTime.txt"))
                        {
                            FileHandling.RemoveFile("../../Logs/File1/oldTime.txt");
                            FileHandling.WriteToFileWithoutLine("../../Logs/File1/oldTime.txt", dt.ToString());
                        }
                        else
                        {
                            FileHandling.WriteToFileWithoutLine("../../Logs/File1/oldTime.txt", dt.ToString());
                        }
                        //Console.WriteLine("Changed!");
                    }
                    else
                    {
                        //Console.WriteLine("Original");
                    }
                }
            }
            //for folder/directory
            else
            {
                DateTime dt = Directory.GetLastWriteTime(file1.Text);

                String[] n = Directory.GetFiles(file1.Text);
                String newFileContent = "";
                foreach(String te in n)
                {
                    newFileContent += te.Split('\\')[te.Split('\\').Length - 1] + ",";
                }
                DateTime oldTime = Convert.ToDateTime(FileHandling.ReadFromFile("../../Logs/Folder1/oldTime.txt"));

                String oldFileContent = "";
                if (FileHandling.fileExists("../../Logs/Folder1/oldFiles.txt"))
                {
                    oldFileContent = FileHandling.ReadFromFile("../../Logs/Folder1/oldFiles.txt");
                }

                if (dt.ToString() != oldTime.ToString())
                {
                    //send email first
                    //System.Diagnostics.Debug.WriteLine("post load " + sender + " " + password);
                    //"smtp.mail.yahoo.com" for yahoo
                    //"smtp.live.com" for hotmail
                    //all on port 587 & requires ssl
                    string[] temp = Form2.email.Split('@');
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
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                      System.Net.NetworkCredential(Form2.email, Form2.password);
                    smtpClient.Credentials = basicAuthenticationInfo;

                    //add the to and from addresses
                    MailAddress from = new MailAddress(Form2.email);
                    MailAddress to = new MailAddress(email.Text);
                    MailMessage mail = new System.Net.Mail.MailMessage(from, to);

                    /*// add ReplyTo only if needed
                    MailAddress replyTo = new MailAddress(sender);
                    mail.ReplyToList.Add(replyTo);
                    */
                    // set subject and encoding type
                    mail.Subject = "Contents to " + file1.Text.Split('\\')[file1.Text.Split('\\').Length - 1] + " folder was changed!";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set message and encoding type
                    mail.Body = "File Path: " + file1.Text + "\n\n";
                    mail.Body += "The Previous Modified/Created Timing was: " + oldTime.ToString() + "\n\n";
                    mail.Body += "The New Modified Time Detected was: " + dt.ToString() + "\n\n";
                    mail.Body += "Old Folder Content: " + oldFileContent + "\n\n";
                    mail.Body += "New Folder Content: " + newFileContent + "\n";
                    mail.Body += "Note: Each File is separated by a comma (,)";
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    // if pure text set to false if html codes are involved set to true
                    mail.IsBodyHtml = false;

                    smtpClient.Send(mail);

                    //replace the old file
                    if (FileHandling.fileExists("../../Logs/Folder1/oldTime.txt"))
                    {
                        FileHandling.RemoveFile("../../Logs/Folder1/oldTime.txt");
                        FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldTime.txt", dt.ToString());
                    }
                    else
                    {
                        FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldTime.txt", dt.ToString());
                    }

                    String[] temporary = Directory.GetFiles(file1.Text);

                    if (FileHandling.fileExists("../../Logs/Folder1/oldFiles.txt"))
                    {
                        FileHandling.RemoveFile("../../Logs/Folder1/oldFiles.txt");
                        foreach (String t in temporary)
                        {
                            FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldFiles.txt", t.Split('\\')[t.Split('\\').Length - 1]  + ",");
                        }
                    }
                    else
                    {
                        foreach (String t in temporary)
                        {
                            FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldFiles.txt", t.Split('\\')[t.Split('\\').Length - 1] + ",");
                        }
                    }
                    //Console.WriteLine("Changed!");
                }
                else
                {
                    //Console.WriteLine("Original");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(file1.Text) || String.IsNullOrWhiteSpace(file1.Text) || String.IsNullOrEmpty(email.Text) || String.IsNullOrWhiteSpace(email.Text))
            {
                if (String.IsNullOrEmpty(file1.Text) || String.IsNullOrWhiteSpace(file1.Text))
                {
                    MessageBox.Show("File cannot be empty!");
                }
                else
                {
                    MessageBox.Show("Email cannot be empty!");
                }
            }
            else
            {
                comboType.Enabled = false;
                file1.Enabled = false;
                btnStop.Enabled = true;
                btnStart.Enabled = false;
                email.Enabled = false;

                if (type == "file")
                {
                    chooseFile.Enabled = false;

                    DateTime dt = FileHandling.getModifiedDateForLog(file1.Text);

                    if (FileHandling.fileExists("../../Logs/File1/oldTime.txt"))
                    {
                        FileHandling.RemoveFile("../../Logs/File1/oldTime.txt");
                        FileHandling.WriteToFileWithoutLine("../../Logs/File1/oldTime.txt", dt.ToString());
                    }
                    else
                    {
                        FileHandling.WriteToFileWithoutLine("../../Logs/File1/oldTime.txt", dt.ToString());
                    }
                }
                else
                {
                    btnFolder.Enabled = false;

                    DateTime dt = Directory.GetLastWriteTime(file1.Text);

                    if (FileHandling.fileExists("../../Logs/Folder1/oldTime.txt"))
                    {
                        FileHandling.RemoveFile("../../Logs/Folder1/oldTime.txt");
                        FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldTime.txt", dt.ToString());
                    }
                    else
                    {
                        FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldTime.txt", dt.ToString());
                    }

                    String[] temporary = Directory.GetFiles(file1.Text);

                    if (FileHandling.fileExists("../../Logs/Folder1/oldFiles.txt"))
                    {
                        FileHandling.RemoveFile("../../Logs/Folder1/oldFiles.txt");
                        foreach (String t in temporary) {
                            FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldFiles.txt", t.Split('\\')[t.Split('\\').Length - 1] + ",");
                        }
                    }
                    else
                    {
                        foreach (String t in temporary)
                        {
                            FileHandling.WriteToFileWithoutLine("../../Logs/Folder1/oldFiles.txt", t.Split('\\')[t.Split('\\').Length - 1] + ",");
                        }
                    }
                }
                InitTimer();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            comboType.Enabled = true;
            file1.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            email.Enabled = true;
            if(type == "file")
            {
                chooseFile.Enabled = true;
            }
            else
            {
                btnFolder.Enabled = true;
            }
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            email.Text = Form2.email;
            btnStop.Enabled = false;
        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                file1.Text = file;
            }
            //Console.WriteLine(result);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                file1.Text = folderDlg.SelectedPath;
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboType.SelectedIndex == 0)
            {
                btnFolder.Enabled = false;
                btnFolder.Visible = false;
                chooseFile.Enabled = true;
                chooseFile.Visible = true;
                label1.Text = "File:";
                type = "file";
            }
            else if (comboType.SelectedIndex == 1)
            {
                btnFolder.Enabled = true;
                btnFolder.Visible = true;
                chooseFile.Enabled = false;
                chooseFile.Visible = false;
                label1.Text = "Folder:";
                type = "folder";
            }
            else
            {
                MessageBox.Show("Please select a valid type!");
            }
        }
    }
}
