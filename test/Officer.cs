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
using System.Net;

namespace test
{
    public partial class Officer : Form
    {
        public Officer()
        {
            InitializeComponent();
        }

        public Image a = Image.FromFile("nophoto.png");
        public Image b = Image.FromFile("Delete-file-icon.png");
        static string hex = "#263238";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        int ind = -1, sz = 0;
        
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush mySolidColorBrush = new SolidBrush(Color.FromArgb(38, 50, 56));
            Brush fillbrush = mySolidColorBrush;
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);
            background.X = 0;
            background.Y = 153;
            background.Height = tabControl1.Height;
            background.Size = new Size(tabControl1.Width, tabControl1.Height);
            e.Graphics.FillRectangle(fillbrush, background);
            SolidBrush mySolidColorBrush1 = new SolidBrush(Color.FromArgb(38, 50, 56));
            Brush fillbrush1 = mySolidColorBrush1;
            Rectangle lasttabrect1 = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background1 = new Rectangle();
            background1.Location = new Point(lasttabrect1.Right, 0);
            background1.X = 150;
            background1.Y = 0;
            background1.Height = tabControl1.Height;
            background1.Size = new Size(tabControl1.Width - 100, tabControl1.Height);
            e.Graphics.FillRectangle(fillbrush1, background1);
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = tabControl1.TabPages[e.Index];
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);
            SolidBrush coo = new SolidBrush(Color.FromArgb(255, 255, 255));
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.FromArgb(38, 50, 12));
                g.FillRectangle(coo, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(Color.White);
                g.FillRectangle(fillbrush, e.Bounds);
            }
            Font _tabFont = new Font("Arial", (float)20.0, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Search Here!";
            textBox1.ForeColor = Color.LightGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = _color;
            tableLayoutPanel1.BackColor = _color;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                to.Value = DateTime.Today;
                to.Enabled = false;
            }
            else
                to.Enabled = true;
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            crimeNafsha.Text = "Crime";
            crimePic.Image = a;
            imageList1.Images.Clear();
            ind = 0;
            sz = 0;
            crimeType.Text = "Crime Type";
            crimeDes.Clear();
            crimeAddres.Text = "Address";
            crimeAddres.ForeColor = Color.LightGray;
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (crimeNafsha.Text == "Crime")
            {
                reqstat.Text = "Select Crime!";
                reqstat.ForeColor = Color.DarkRed;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            crime1.Text = "Crime";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search Here!";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Here!" || textBox1.Text == "")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "Search Here!")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void Officer_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            imageList1.ImageSize = new Size(200, 200);
            foreach (string file in droppedfiles)
            {
                ind = sz;
                sz++;
                string filename = getFileName(file);
                crimePic.Image = Image.FromFile(file);
                imageList1.Images.Add(crimePic.Image);
            }
        }
        
        private void Officer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private string getFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (ind >= sz-1)
            {
                ind = 0;
            }
            else
                ind++;
            crimePic.Image = imageList1.Images[ind];
            crimePic.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (ind <= 0)
            {
                ind = sz-1;
            }
            else
                ind--;
            crimePic.Image = imageList1.Images[ind];
            crimePic.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox5.Text == "Item found")
            {
                textBox5.Text = "";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Item found")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
            
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Item found";
                textBox5.ForeColor = Color.LightGray;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text == "Description")
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Description")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Description";
                textBox4.ForeColor = Color.LightGray;
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (open.Enabled)
            {
                open.Enabled = false;
                closed.Enabled = true;
            }
            else
            {
                closed.Enabled = false;
                open.Enabled = true;
            }
        }

        private void closed_Click_1(object sender, EventArgs e)
        {
            if (closed.Enabled)
            {
                open.Enabled = true;
                closed.Enabled = false;
            }
            else
            {
                open.Enabled = false;
                closed.Enabled = true;
            }
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ind >= sz - 1)
                {
                    ind = 0;
                }
                else
                    ind++;
                crimePic.Image = imageList1.Images[ind];
            }
            catch
            {
                ind = 0;
                sz = 0;
            }
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ind <= 0)
                {
                    ind = sz - 1;
                }
                else
                    ind--;
                crimePic.Image = imageList1.Images[ind];
            }
            catch
            {
                ind = 0;
                sz = 0;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
            }
            else
                MessageBox.Show("OOPS! You're offline please add the address manually!");
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (crimeAddres.Text == "Address")
            {
                crimeAddres.Clear();
                crimeAddres.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (crimeAddres.Text == "")
            {
                crimeAddres.Text = "Address";
                crimeAddres.ForeColor = Color.LightGray;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            imageList1.ImageSize = new Size(256, 256);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                crimePic.Image = Image.FromFile(openFileDialog1.FileName);
                imageList1.Images.Add(crimePic.Image);
                ind = sz;
                sz++;
            }
            openFileDialog1.Dispose();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                imageList1.Images.RemoveAt(ind);


                if (sz > 0) sz--;
                else sz = 0; 
                if (ind == 0)
                {
                    ind = sz - 1;
                }
                else ind--;
                try
                {

                    crimePic.Image = imageList1.Images[ind];
                }
                catch
                {
                    crimePic.Image = a;
                }
            }
            catch
            {
                MessageBox.Show("No Image to be Deleted!!");
            }
        }

        private void textBox5_Enter_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "Item found")
            {
                textBox5.Text ="";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Item found";
                textBox5.ForeColor = Color.LightGray;
            }
            
        }

        private void textBox4_Enter_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "Description")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Description";
                textBox4.ForeColor = Color.LightGray;
            }
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox5.Text == "Item found")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text == "Description")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //main code above
            textBox5.ForeColor = Color.LightGray;
            textBox4.ForeColor = Color.LightGray;
            textBox5.Text = "Item found";
            textBox4.Text = "Description";
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush mySolidColorBrush = new SolidBrush(Color.FromArgb(38, 50, 56));
            Brush fillbrush = mySolidColorBrush;
            SolidBrush mySolidColorBrush1 = new SolidBrush(Color.FromArgb(255, 255, 255));
            Brush fillbrush1 = mySolidColorBrush1;
            Rectangle lasttabrect1 = tabControl2.GetTabRect(tabControl2.TabPages.Count - 1);
            Rectangle background1 = new Rectangle();
            background1.Location = new Point(lasttabrect1.Right, 0);
            background1.X = 474;
            background1.Y = 3;
            background1.Height = tabControl1.Height;
            background1.Size = new Size(tabControl2.Width - 100, 17);
            e.Graphics.FillRectangle(fillbrush1, background1);
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = tabControl2.TabPages[e.Index];
            Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);
            SolidBrush coo = new SolidBrush(Color.FromArgb(255, 255, 255));
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.FromArgb(38, 50, 56));
                g.FillRectangle(coo, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(Color.White);
                g.FillRectangle(fillbrush, e.Bounds);
            }
            Font _tabFont = new Font("Arial", (float)13.5, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            partCom.Text = "";
            partCrime.Text = "Crime";
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                to.Value = DateTime.Today;
                to.Enabled = false;
            }
            else 
                to.Enabled = true;
        }
    }
}
