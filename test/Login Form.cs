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
using System.Xml.Serialization;

namespace test
{
    [Serializable]
    public partial class Login_Form : Form
    {
        public static bool rank = false;
        public static String typee,ID;
        Color _color = System.Drawing.ColorTranslator.FromHtml("#263238");
        List<officer_info> oflis = new List<officer_info>();
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
        private void loguser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, new EventArgs());
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
        public void deser()
        {
            try
            {
                XmlSerializer sery = new XmlSerializer(typeof(List<officer_info>));
                using (FileStream fs = new FileStream("Offinfo.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    oflis = sery.Deserialize(fs) as List<officer_info>;
                }
            }
            catch
            { }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loguser.ToString() != "" && logpass.ToString() != "")
            {
                bool x = false;
                deser();
                foreach (officer_info off in oflis)
                {
                    if (off.offId == loguser.Text && off.pss == logpass.Text)
                    {
                        x = true;
                        Form1 f = new Form1();
                        if (off.offId != "admin")
                            rank = true;
                        ID = loguser.Text;
                        f.Show();
                        this.Hide();
                        f.FormClosing += f_Closing;
                    }
                }
                if (!x)
                    messageBoxOK.Show("This User may be not exist please check the username and password!");
            }
            else
                messageBoxOK.Show("Please enter username and password!");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void f_Closing(object sender, FormClosingEventArgs e)
        {
            logpass.Text = "Password";
            loguser.Text = "User Name";
            loguser.ForeColor = Color.LightGray;
            logpass.ForeColor = Color.LightGray;
            this.Show();
        }
    }
}
