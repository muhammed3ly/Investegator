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
    public partial class ourMessageBox : Form
    {
        public ourMessageBox()
        {
            InitializeComponent();
        }
        static ourMessageBox msgBox;
        static DialogResult result = DialogResult.No; 
        public static DialogResult Show(string txt)
        {
            msgBox = new ourMessageBox();
            msgBox.message.Text = txt;
            result = DialogResult.No;
            msgBox.ShowDialog();
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            msgBox.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            msgBox.Close();
        }

        private void btnYES_MouseEnter(object sender, EventArgs e)
        {
            btnYES.BackColor = Color.DarkGreen;
        }

        private void btnNo_MouseEnter(object sender, EventArgs e)
        {
            btnNo.BackColor = Color.DarkRed;
        }

        private void btnYES_MouseLeave(object sender, EventArgs e)
        {
            btnYES.BackColor = Form1._color;
        }

        private void btnNo_MouseLeave(object sender, EventArgs e)
        {
            btnNo.BackColor = Form1._color;
        }
    }
}
