using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace MapAddress
{
    public partial class frmMapIt : Form
    {

        public frmMapIt()
        {
            InitializeComponent();
        }


        static public string url="";
        /// <summary>
        /// Map by street address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapIt_Click(object sender, EventArgs e)
        {
            if (queryAddress.ToString() == webBrowser1.Url.ToString())
            {
                MessageBox.Show("Please select location or type it in the navigation bar in the Google Maps Form!");
                return;
            }
            try
            {
                string s = "";
                bool ys = false;
                url = webBrowser1.Url.ToString();
                for(int i=0;i<url.Length;i++)
                {
                    if (url[i] == '/' && !ys) s = "";
                    else if (url[i]!='/') s += url[i];
                    else
                        break;
                //    MessageBox.Show(s);
                    if (s == "place")
                    {
                        ys = true;
                        i++;
                        s = "";
                    }
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
                    MessageBox.Show("Please select location or type it in the navigation bar in the Google Maps Form!");
                    return;
                }
                MessageBox.Show(s);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }

        }


        

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        static string hex = "#263238";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        StringBuilder queryAddress = new StringBuilder();
        private void frmMapIt_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(38, 50, 56);
            rectangleShape1.FillColor = _color;
            btnMapIt.BackColor = _color;
            try
            {
                queryAddress.Append("http://maps.google.com/maps");

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}