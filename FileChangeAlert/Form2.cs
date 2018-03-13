using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileChangeAlert
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static string email = "";
        public static string password = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please Type in a valid email!");
                }
                else if(String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please Type in a password!");
                }
                else
                {
                    MessageBox.Show("Both fields cannot be empty!");
                }
            }
            else
            {
                email = textBox1.Text;
                password = textBox2.Text;

                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}
