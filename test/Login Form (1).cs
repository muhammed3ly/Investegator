using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace test
{
    public partial class Login_Form : Form
    {

        Color _color = System.Drawing.ColorTranslator.FromHtml("#263238");
        public Login_Form()
        {
            InitializeComponent();
            loguser.ForeColor = _color;
            logpass.ForeColor = Color.LightGray;
            loginButton.BackColor = _color;
            loginButton.ForeColor = Color.White;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderColor = _color;
            loguser.Text = "User Name";
            logpass.Text = "Password";
        }

        private void loginName_Enter(object sender, EventArgs e)
        {
            if (loguser.Text == "User Name")
            {
                loguser.Clear();
                loguser.ForeColor = Color.Black;
            }
        }

        private void loginName_Leave(object sender, EventArgs e)
        {
            if (loguser.Text == "")
            {
                loguser.Text = "User Name";
                loguser.ForeColor = Color.LightGray;
            }
        }

        private void loginPassword_Enter(object sender, EventArgs e)
        {
            if (logpass.Text == "Password")
            {
                logpass.Clear();
                logpass.ForeColor = Color.Black;
            }
        }

        private void loginPassword_Leave(object sender, EventArgs e)
        {
            if (logpass.Text == "")
            {
                logpass.Text = "Password";
                logpass.ForeColor = Color.LightGray;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loguser.ToString() != "" && logpass.ToString() != "")
            {
                FileStream login = new FileStream("Login.txt", FileMode.Open, FileAccess.Read);
                StreamReader wl = new StreamReader(login);
                bool x = false;
                while (wl.Peek() != -1)
                {
                    if (wl.ReadLine() == "Username:")
                        if (wl.ReadLine() == loguser.Text)
                        {
                            string z = wl.ReadLine();
                            if (wl.ReadLine() == logpass.Text)
                            {
                                x = true;
                                string s = wl.ReadLine();
                                if (wl.ReadLine() == "Admin")
                                {
                                    Form1 a = new Form1();
                                    a.Show();
                                    this.Hide();
                                    a.FormClosing += f_Closing;
                                    break;
                                }
                                else
                                {
                                    Officer a = new Officer();
                                    a.Show();
                                    this.Hide();
                                    a.FormClosing += f_Closing;
                                    break;
                                }
                            }
                        }
                }
                if (!x)
                    MessageBox.Show("This User may be not exist please check the username and password!");
            }
            else
                MessageBox.Show("Please enter username and password!");
        }
        private void f_Closing(object sender, FormClosingEventArgs e)
        {
            logpass.Text = "Password";
            loguser.Text = "User Name";
            loguser.ForeColor = Color.LightGray;
            logpass.ForeColor = Color.LightGray;
            this.Show();
        }

        private void logpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
            }
        }

        private void logpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (logpass.Text == "Password")
            {
                logpass.Text = "";
                logpass.ForeColor = Color.Black;
            }
        }

        private void loguser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (loguser.Text == "User Name")
            {
                loguser.Text = "";
                loguser.ForeColor = Color.Black;
            }
        }
        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
