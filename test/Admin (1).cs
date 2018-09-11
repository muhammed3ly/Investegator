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
using System.Xml.Serialization;
namespace test
{
    public partial class Form1 : Form
    {
        int x = -1, sz = 0;
        static string hex = "#263238";
        Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        public Image a = Image.FromFile("nophoto.png");
        public Image add = Image.FromFile("save.png"); 
        public Image trash = Image.FromFile("trash-symbol.jpg");
        public static bool checkhover = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush mySolidColorBrush = new SolidBrush(Color.FromArgb(38, 50, 56));
            Brush fillbrush = mySolidColorBrush, _textBrush, fillbrush2 = new SolidBrush(Color.FromArgb(255, 255, 255));
            SolidBrush mySolidColorBrush1 = new SolidBrush(Color.FromArgb(38, 50, 56));
            Brush fillbrush1 = mySolidColorBrush1;
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            Rectangle lasttabrect1 = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background1 = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);
            background.X = 0;
            background.Y = 353;
            background.Height = tabControl1.Height;
            background.Size = new Size(tabControl1.Width, tabControl1.Height);
            e.Graphics.FillRectangle(fillbrush, background);
            background1.Location = new Point(lasttabrect1.Right, 0);
            background1.X = 150;
            background1.Y = 0;
            background1.Height = tabControl1.Height;
            background1.Size = new Size(tabControl1.Width - 100, tabControl1.Height);
            e.Graphics.FillRectangle(fillbrush1, background1);
            Graphics g = e.Graphics;
            TabPage _tabPage = tabControl1.TabPages[e.Index];
            
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);
            
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new System.Drawing.SolidBrush(Color.FromArgb(38, 50, 56));   
                g.FillRectangle(fillbrush2, e.Bounds);
            }

            else
            {
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(fillbrush, e.Bounds);
            }
            Font _tabFont = new Font("Arial", (float)20.0, FontStyle.Bold, GraphicsUnit.Pixel);
            
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MuhammedAly:
            deserelizing();
            ///////////////
            pictureBox1.BackColor = _color;
            tableLayoutPanel1.BackColor = _color;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (desctxt.Text == "Description")
            {
                desctxt.Clear();
                desctxt.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (desctxt.Text == "")
            {
                desctxt.Text = "Description";
                desctxt.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (desctxt.Text == "Description")
            {
                desctxt.Clear();
                desctxt.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Iteam Name")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black; 
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Iteam Name";
                textBox3.ForeColor = Color.LightGray; 
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "ITEM DESCRIPTION";
                textBox4.ForeColor = Color.LightGray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "ITEM DESCRIPTION")
            {
                textBox4.Clear();
                textBox4.ForeColor = Color.Black;
            }
        }
        
        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedfiles)
            {
                x++;
                sz++;
                string filename = getFileName(file);
                pictureBox5.Image = Image.FromFile(file);
                imageList1.Images.Add(pictureBox5.Image);
            }
        }

        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }
        private string getFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (x == 0)
                x = sz-1;
            else
                x--;
            try
            {
                pictureBox5.Image = imageList1.Images[x];
            }
            catch
            {
                x = 0; 
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            imageList1.ImageSize = new Size(200, 200);
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedfiles)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage2"])
                    pictureBox7.Image = Image.FromFile(file);
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage1"])
                {
                    try
                    {
                        string filename = getFileName(file);
                        pictureBox5.Image = Image.FromFile(file);
                        imageList1.Images.Add(pictureBox5.Image);
                        x = sz++;
                    }
                    catch
                    {
                        MessageBox.Show("You can only add this extension files(.jpg / .jpeg / .png / .bmp)");
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage3"])
                {
                    userimage.Image = Image.FromFile(file);
                    user = file ;
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            imageList1.ImageSize = new Size(256, 256);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image=Image.FromFile(openFileDialog1.FileName);
                imageList1.Images.Add(pictureBox5.Image);
                x = sz;
                sz++;
            }
            openFileDialog1.Dispose();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip t1 = new ToolTip();
            t1.Show("Press Here To Select an Image!",pictureBox5);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                imageList1.Images.RemoveAt(x);
                if (sz > 0)
                    sz--;
                else
                    sz = 0;
                if (x == 0)
                    x = sz - 1;
                else
                    x--;
                try
                {
                    pictureBox5.Image = imageList1.Images[x];
                }
                catch
                {
                        pictureBox5.Image = a;
                }
            }
            catch
            {
                MessageBox.Show(x.ToString() + " " + sz.ToString());
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == "Location")
            {
                textBox12.Clear();
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "Location";
                textBox12.ForeColor = Color.LightGray;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(addrdio.Checked)
            {
                crimeid.Text = "Crime ID";
                delrdio.Checked = false;
                updrdio.Checked = false;
                crimeid.Enabled = false;
                desctxt.Enabled = true;
                imagegroupbox.Enabled = true;
                groupBoxcrimetype.Enabled = true;
                groupBoxcrimelocation.Enabled = true;
                groupBox2.Enabled = true;
                groupBoxpplinv.Enabled = true;
                groupBoxadditem.Enabled = true;
                groupBoxoffid.Enabled = true;
                pictureBox11.Image = add; 
            }
        }

        private void updrdio_CheckedChanged(object sender, EventArgs e)
        {
            if(updrdio.Checked)
            {
                crimeid.Text = "Crime ID";
                addrdio.Checked = false;
                delrdio.Checked = false;
                crimeid.Enabled = true;
                groupBoxoffid.Enabled = false;
                desctxt.Enabled = false;
                imagegroupbox.Enabled = false;
                groupBoxcrimetype.Enabled = false;
                groupBoxcrimelocation.Enabled = false;
                groupBox2.Enabled = false;
                groupBoxpplinv.Enabled = false;
                groupBoxadditem.Enabled = false;
                if (crimeid.Text != "Crime ID")
                    pictureBox11.Enabled = true;
                else
                    pictureBox11.Enabled = false;
                pictureBox11.Image = add; 
            }
        }

        private void delrdio_CheckedChanged(object sender, EventArgs e)
        {
            if (delrdio.Checked)
            {
                crimeid.Text = "Crime ID";
                addrdio.Checked = false;
                updrdio.Checked = false;
                crimeid.Enabled = true;
                groupBoxoffid.Enabled = false;
                desctxt.Enabled = false;
                imagegroupbox.Enabled = false;
                groupBoxcrimetype.Enabled = false;
                groupBoxcrimelocation.Enabled = false;
                groupBox2.Enabled = false;
                groupBoxpplinv.Enabled = false;
                groupBoxadditem.Enabled = false;
                if (crimeid.Text != "Crime ID")
                    pictureBox11.Enabled = true;
                else
                    pictureBox11.Enabled = false;
                pictureBox11.Image = trash; 
            }
        }

        private void crimeid_TextChanged(object sender, EventArgs e)
        {
            if (crimeid.Text != "Crime ID" && !delrdio.Checked)
            {
                desctxt.Enabled = true;
                imagegroupbox.Enabled = true;
                groupBoxcrimetype.Enabled = true;
                groupBoxcrimelocation.Enabled = true;
                groupBox2.Enabled = true;
                groupBoxpplinv.Enabled = true;
                groupBoxadditem.Enabled = true;
                groupBoxoffid.Enabled = true; 
            }
            if (crimeid.Text != "Crime ID" || addrdio.Checked)
                pictureBox11.Enabled = true; 
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPage5"])
                this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Here!")
            {
                textBox1.Clear();
                textBox1.ForeColor = _color;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search Here!";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Search Here!";
            textBox1.ForeColor = Color.LightGray;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "Search Here!")
            {
                textBox1.Clear();
                textBox1.ForeColor = _color;
            }
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
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
            }
            else
                MessageBox.Show("OOPS! You're offline please add the address manually!");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
            }
            else
                MessageBox.Show("OOPS! You're offline please add the address manually!");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (x == sz-1)
                x = 0;
            else
                x++;
            try
            {
                pictureBox5.Image = imageList1.Images[x];
            }
            catch
            {
                x = 0; 
            }
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Male.Checked)
            {
                Female.Checked = false;
            }
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Female.Checked)
            {
                Male.Checked = false;
            }
        }

        private void unmar_CheckedChanged(object sender, EventArgs e)
        {
            if (unmar.Checked)
            {
                mar.Checked = false;
            }
        }

        private void mar_CheckedChanged(object sender, EventArgs e)
        {
            if (mar.Checked)
            {
                unmar.Checked = false;
            }
        }

        //MuhammedAly:
        List<Adminclass> admnlst = new List<Adminclass>();
        string user = "nophoto.png";
        private void serelizing()
        {
           /* try
            {
                File.Delete("Admininfo.xml");
            }
            catch
            {
            }*/
            XmlSerializer ser = new XmlSerializer(typeof(List<Adminclass>));
            using (FileStream fs = new FileStream("Admininfo.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                ser.Serialize(fs, admnlst);
            }
        }
        private void deserelizing()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Adminclass>));
            using (FileStream fs = new FileStream("Admininfo.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                admnlst = ser.Deserialize(fs) as List<Adminclass>;
            }
            //MessageBox.Show(admnlst.ElementAt(0).Name);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (rnk.Text == "Admin")
            {
                if (name.Text == "" || pss.Text == "" || rnk.Text == "Rank" || id.Text == "")
                {
                    MessageBox.Show("Please add values to the Required(*) fields!");
                    return;
                }
                admnlst.Add(new Adminclass() { Name = name.Text, ID = id.Text, Birthdate = bd.Text, Rank = rnk.Text, Password = pss.Text, Gender = (Male.Checked) ? "Male" : "Female", MaritalStatus = (mar.Checked) ? "Married" : "Unmarried", image = user });
                serelizing();
                name.Clear();
                pss.Clear();
                rnk.Text = "Rank";
                id.Clear();
                userimage.Image = Image.FromFile("nophoto.png");
                user = "nophoto.png";
                MessageBox.Show("Added!");
            }
            else if (rnk.Text == "Officer")
            {
                //Alaa
            }
            else
            {
                MessageBox.Show("Please enter valid Rank to this user to be added!");
            }
        }
        ///////////////////////////////////////
    }
}
