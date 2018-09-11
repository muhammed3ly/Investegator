using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class messageBoxOK : Form
    {
        public messageBoxOK()
        {
            InitializeComponent();
        }
        static messageBoxOK msgBox;
        public static void Show(string txt)
        {
            msgBox = new messageBoxOK();
            msgBox.message.Text = txt;
            msgBox.ShowDialog();
        }
        public static void Show(string txt1, string txt)
        {
            msgBox = new messageBoxOK();
            msgBox.message.Text = txt;
            msgBox.ShowDialog();
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            msgBox.Close();
        }
    }
}
