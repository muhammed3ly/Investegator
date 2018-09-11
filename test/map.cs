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
using test;

namespace MapAddress
{
    public partial class frmMapIt : Form
    {
        static string hex = "#263238";
        static public string url="", s = "";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        StringBuilder queryAddress = new StringBuilder();

        public frmMapIt()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Map by street address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapIt_Click(object sender, EventArgs e)
        {
            try { 
            if (queryAddress.ToString() == webBrowser1.Url.ToString())
            {
                messageBoxOK.Show("Please select location or type it in the navigation bar in the Google Maps Form!");
                return;
            }
                try
                {
                    s = "";
                    bool ys = false;
                    url = webBrowser1.Url.ToString();
                    for (int i = 0; i < url.Length; i++)
                    {
                        if (url[i] == '/' && !ys)
                            s = "";
                        else if (url[i] != '/')
                            s += url[i];
                        else
                            break;
                        if (s == "place")
                        {
                            ys = true;
                            i++;
                            s = "";
                        }
                    }
                }
                catch {
                    messageBoxOK.Show("please wait for loading");
                    return;

                }
                string ss="";
                for (int i=0; i<s.Length; i++)
                {
                    if (s[i] == '+') ss += " ";
                    else ss += s[i];

                }
                s = ss;
                if (s[0] == '@')
                {
                    s = "No Route Selected!";
                    messageBoxOK.Show("Please select location or type it in the navigation bar in the Google Maps Form!");
                    return;
                }
                if (ourMessageBox.Show("Are you sure about this address: " + s) == DialogResult.Yes)
                    this.Close();
                else
                    return;
                    
            }
            catch (Exception ex)
            {
                messageBoxOK.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maxmizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState.Equals(FormWindowState.Maximized))
            {
                this.WindowState = FormWindowState.Normal;
                maxmizeBtn.Image = Image.FromFile("icons8_Maximize_Window_52px.png");
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                maxmizeBtn.Image = Image.FromFile("Restore.png");
            }
        }

        private void frmMapIt_Load(object sender, EventArgs e)
        {
            btnMapIt.BackColor = _color;
            try
            {
                queryAddress.Append("http://maps.google.com/maps");

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                messageBoxOK.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }
        }
    }
}