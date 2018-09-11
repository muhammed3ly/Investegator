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
using Bunifu.Framework.UI;

namespace test
{
    public partial class Form1 : Form
    {
        XmlSerializer involvedSer = new XmlSerializer(typeof(List<involvedPeople>));
        FileStream involvedFs;
        int x = -1, sz = 0, involvedListIndex = 0, mshhanst3mloabdn = 0, itemindex = 0, invindexgdid, backHeight = 373;
        public static bool checkhover = false;
        bool eshta = true;
        static string hex = "#263238";
        public string inImageH = "nophoto.png";
        string user2 = "nophoto.png", user = "nophoto.png", off_id, ss;
        public static Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        public Image a = Image.FromFile("nophoto.png");
        public Image add = Image.FromFile("save.png");
        public Image trash = Image.FromFile("trash-symbol.jpg");
        List<string> imgname = new List<string>();
        List<string> crimeidd = new List<string>();
        List<string> tempimg = new List<string>();
        List<string> CTType = new List<string>();
        List<string> deltedPeople = new List<string>();
        List<Crime> myCrime = new List<Crime>();
        List<Crime> listc = new List<Crime>();
        List<Crime> c = new List<Crime>();
        List<Crimetype> types = new List<Crimetype>();
        List<Item> items = new List<Item>();
        List<involvedPeople> li = new List<involvedPeople>();
        List<officer_info> oflis = new List<officer_info>();
        List<officer_info> ofliss = new List<officer_info>();
        public List<string> pp = new List<string>();
        public List<string> rolle = new List<string>();
        public List<string> locatcrime = new List<string>();
        public List<bool> eved = new List<bool>();
        public List<bool> motiv = new List<bool>();
        public Form1()
        {
            InitializeComponent();
        }
        //setting colors for tabcontorol1 unused space
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
            background.Y = backHeight;
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
            Left = Top = 0;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            adjTabs();
            involvedDesrialize();
            crimeTypeDeserilizing();
            hatoelid();
            peopledeserilizing();
            crimeids();
            offinf();
            showusers();
            deser();
            pictureBox1.BackColor = _color;
            tableLayoutPanel1.BackColor = _color;
            addcrimes();
            charts();
            getDataForGrid();
            bunifuImageButton6.Enabled = false;
            bunifuImageButton7.Enabled = false;
            this.flowLayoutPanel2.Controls.Clear();
        }
        private void charts()
        {
            barChart.ChartAreas.Clear();
            barChart.Legends.Clear();
            barChart.Series.Clear();
            pieChart.Series.Clear();
            if (DataTypeCB.Text == "Crime Type")
            {
                try
                {
                    barChart.ChartAreas.Add("Crime Type");
                    barChart.ChartAreas["Crime Type"].AxisY.MajorGrid.LineWidth = 0;
                    barChart.Series.Add("Crime Type");
                    pieChart.Series.Add("Crime Type");
                    pieChart.Series["Crime Type"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                }
                catch { }
                Dictionary<string, int> dc = new Dictionary<string, int>();
                foreach (Crime cr in listc)
                    if (dc.Keys.Contains(cr.crimetype))
                        dc[cr.crimetype]++;
                    else
                        dc.Add(cr.crimetype, 1);
                foreach (string s in dc.Keys)
                {
                    barChart.Series["Crime Type"].Points.AddY(dc[s]);
                    barChart.Series["Crime Type"].Points[barChart.Series["Crime Type"].Points.Count - 1].LegendText = s;
                    barChart.Series["Crime Type"].Points[barChart.Series["Crime Type"].Points.Count - 1].AxisLabel = s;
                    pieChart.Series["Crime Type"].Points.AddXY(s, dc[s]);
                    pieChart.Series["Crime Type"].Points[pieChart.Series["Crime Type"].Points.Count - 1].LegendText = s;
                    pieChart.Series["Crime Type"].Points[pieChart.Series["Crime Type"].Points.Count - 1].Label = s;
                    pieChart.Series["Crime Type"].Points[pieChart.Series["Crime Type"].Points.Count - 1].LabelForeColor = Color.FromArgb(38, 50, 56);
                    pieChart.Series["Crime Type"].Points[pieChart.Series["Crime Type"].Points.Count - 1].Font = new Font("Arial",
                    pieChart.Series["Crime Type"].Points[pieChart.Series["Crime Type"].Points.Count - 1].Font.Size + 2);
                }
                barChart.Legends.Add("Crime Type");
                barChart.Series["Crime Type"].Legend = barChart.Legends[0].Name;
                barChart.Series["Crime Type"].Color = Color.FromArgb(38, 50, 56);
            }
            else if (DataTypeCB.Text == "Crime Reigon")
            {
                try
                {
                    barChart.ChartAreas.Add("Crime Reigons");
                    barChart.ChartAreas["Crime Reigons"].AxisY.MajorGrid.LineWidth = 0;
                    barChart.Series.Add("Crime Reigons");
                    pieChart.Series.Add("Crime Reigons");
                    pieChart.Series["Crime Reigons"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                }
                catch { }
                Dictionary<string, int> dc = new Dictionary<string, int>();
                foreach (Crime cr in listc)
                {
                    if (dc.Keys.Contains(adjAddress(cr.crime_location)))
                        dc[adjAddress(cr.crime_location)]++;
                    else
                        dc.Add(adjAddress(cr.crime_location), 1);
                }
                foreach (string s in dc.Keys)
                {
                    barChart.Series["Crime Reigons"].Points.AddY(dc[s]);
                    barChart.Series["Crime Reigons"].Points[barChart.Series["Crime Reigons"].Points.Count - 1].LegendText = adjAddress(s);
                    barChart.Series["Crime Reigons"].Points[barChart.Series["Crime Reigons"].Points.Count - 1].AxisLabel = adjAddress(s);
                    pieChart.Series["Crime Reigons"].Points.AddXY(s, dc[s]);
                    pieChart.Series["Crime Reigons"].Points[pieChart.Series["Crime Reigons"].Points.Count - 1].LegendText = adjAddress(s);
                    pieChart.Series["Crime Reigons"].Points[pieChart.Series["Crime Reigons"].Points.Count - 1].Label = adjAddress(s);
                    pieChart.Series["Crime Reigons"].Points[pieChart.Series["Crime Reigons"].Points.Count - 1].Font = new Font("Arial",
                    pieChart.Series["Crime Reigons"].Points[pieChart.Series["Crime Reigons"].Points.Count - 1].Font.Size + 2);
                    pieChart.Series["Crime Reigons"].Points[pieChart.Series["Crime Reigons"].Points.Count - 1].LabelForeColor = Color.FromArgb(38, 50, 56);
                }
                barChart.Legends.Add("Crime Reigons");
                barChart.Series["Crime Reigons"].Legend = barChart.Legends[0].Name;
                barChart.Series["Crime Reigons"].Color = Color.FromArgb(38, 50, 56);
            }
            else if (DataTypeCB.Text == "Number of people in each crime type")
            {
                try
                {
                    barChart.ChartAreas.Add("Crime's people");
                    barChart.ChartAreas["Crime's people"].AxisY.MajorGrid.LineWidth = 0;

                    barChart.Series.Add("Crime's people");
                    pieChart.Series.Add("Crime's people");
                    pieChart.Series["Crime's people"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                }
                catch { }
                Dictionary<string, int> dc = new Dictionary<string, int>();
                foreach (Crime cr in listc)
                    if (dc.Keys.Contains(cr.crimetype))
                        dc[cr.crimetype] += cr.involved_people.Count;
                    else
                        dc.Add(cr.crimetype, cr.involved_people.Count);
                foreach (string s in dc.Keys)
                {
                    barChart.Series["Crime's people"].Points.AddY(dc[s]);
                    barChart.Series["Crime's people"].Points[barChart.Series["Crime's people"].Points.Count - 1].LegendText = s;
                    barChart.Series["Crime's people"].Points[barChart.Series["Crime's people"].Points.Count - 1].AxisLabel = s;
                    pieChart.Series["Crime's people"].Points.AddXY(s, dc[s]);
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].LegendText = s;
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].Label = s;
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].LabelForeColor = Color.FromArgb(38, 50, 56);
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].Font = new Font("Arial",
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].Font.Size + 2);
                    pieChart.Series["Crime's people"].Points[pieChart.Series["Crime's people"].Points.Count - 1].LabelForeColor = Color.FromArgb(38, 50, 56);
                }
                barChart.Legends.Add("Crime's people");
                barChart.Series["Crime's people"].Legend = barChart.Legends[0].Name;
                barChart.Series["Crime's people"].Color = Color.FromArgb(38, 50, 56);
            }
        }
        private void adjTabs()
        {
            if (Login_Form.rank)
            {
                tabControl1.TabPages.Remove(regForm);
                tabControl1.TabPages.Remove(invPeople);
                backHeight = 213;
                addrdio.Hide();
                delrdio.Hide();
                updrdio.Select();
            }
            else
            {
                backHeight = 353;
                addrdio.Show();
                delrdio.Show();
                addrdio.Select();
            }
            Login_Form.rank = false;
        }
        private void hatoelid()
        {
            itemspeople.Items.Clear();
            peopleid.Items.Clear();
            itemspeople.Items.Add("PersonID");
            itemspeople.Text = "PersonID";
            peopleid.Items.Add("PersonID");
            peopleid.Text = "PersonID";
            foreach (involvedPeople ip in li)
            {
                itemspeople.Items.Add(ip.personalID);
                peopleid.Items.Add(ip.personalID);
            }
        }
        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedfiles)
            {
                x++;
                sz++;
                string filename = placeFileinDebug(getFileName(file));
                crimeimg.Image = Image.FromFile(file);
                imageList1.Images.Add(crimeimg.Image);
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
                x = sz - 1;
            else
                x--;
            try
            {
                crimeimg.Image = imageList1.Images[x];
            }
            catch
            {
                x = 0;
            }
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            imageList1.ImageSize = new Size(256, 256);
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedfiles)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["invPeople"])
                {
                    if (MousePosition.X >= 1000)
                    {
                        if (MousePosition.Y <= 485)
                        {
                            inImage.Image = Image.FromFile(placeFileinDebug(file));
                            inImageH = placeFileinDebug(file);
                        }
                        else
                        {
                            gridPB.Image = Image.FromFile(placeFileinDebug(file));
                            inImageH = placeFileinDebug(file);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["crimeData"])
                {
                    try
                    {
                        if (MousePosition.X <= 370 && MousePosition.X >= 100 && MousePosition.Y <= 405 && MousePosition.Y >= 200)
                        {
                            string filename = getFileName(placeFileinDebug(file));
                            crimeimg.Image = Image.FromFile(placeFileinDebug(file));
                            imageList1.Images.Add(crimeimg.Image);
                            x = sz++;
                            imgname.Add(placeFileinDebug(file));
                            tempimg.Add(placeFileinDebug(file));
                        }
                    }
                    catch
                    {
                        messageBoxOK.Show("You can only add this extension files(.jpg / .jpeg / .png / .bmp)");
                    }
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["regForm"])
                {
                    if (MousePosition.X >= 1000)
                    {
                        if (MousePosition.Y <= 485)
                            userimage.Image = Image.FromFile(placeFileinDebug(file));
                        else
                            userimage2.Image = Image.FromFile(placeFileinDebug(file));
                    }
                    user = user2 = placeFileinDebug(file);
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
                crimeimg.Image = Image.FromFile(placeFileinDebug(openFileDialog1.FileName));
                imageList1.Images.Add(crimeimg.Image);
                x = sz;
                sz++;
                imgname.Add(placeFileinDebug(openFileDialog1.FileName));
                tempimg.Add(placeFileinDebug(openFileDialog1.FileName));
            }
            openFileDialog1.Dispose();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                imageList1.Images.RemoveAt(x);
                tempimg.RemoveAt(x);
                imgname.RemoveAt(x);
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
                    crimeimg.Image = imageList1.Images[x];
                }
                catch
                {
                    crimeimg.Image = a;
                }
            }
            catch
            {
                messageBoxOK.Show("No Images to be Deleted!");
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (addrdio.Checked)
            {
                imageList1.Images.Clear();
                tempimg.Clear();
                crimeimg.Image = a;
                x = -1; sz = 0;
                crimeid.Text = "Crime ID";
                pictureBox11.Enabled = true;
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
                radioButton2.Enabled = false;
                pp.Clear();
                eved.Clear();
                motiv.Clear();
                locatcrime.Clear();
                items.Clear();
            }
        }
        private void updrdio_CheckedChanged(object sender, EventArgs e)
        {
            if (updrdio.Checked)
            {
                peopleinv.Rows.Clear();
                founditems.Rows.Clear();
                crimeimg.Image = a;
                desctxt.Text = "Description";
                desctxt.ForeColor = Color.LightGray;
                officerid.Text = "Officer ID";
                crimetype.Text = "Crime Type";
                location.Text = "Location";
                location.ForeColor = Color.LightGray;
                peopledeserilizing();
                addcrimes();
                crimeid.Text = "Crime ID";
                imageList1.Images.Clear();
                tempimg.Clear();
                x = -1; sz = 0;
                diseabling();

            }
        }
        public void diseabling()
        {
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
            radioButton2.Enabled = true;
            if (crimeid.Text != "Crime ID")
                pictureBox11.Enabled = true;
            else
                pictureBox11.Enabled = false;
            pictureBox11.Image = add;
            pictureBox11.Enabled = false;
        }
        private void delrdio_CheckedChanged(object sender, EventArgs e)
        {
            if (delrdio.Checked)
            {
                peopleinv.Rows.Clear();
                founditems.Rows.Clear();
                crimeimg.Image = a;
                desctxt.Text = "Description";
                desctxt.ForeColor = Color.LightGray;
                officerid.Text = "Officer ID";
                crimetype.Text = "Crime Type";
                location.Text = "Location";
                location.ForeColor = Color.LightGray;
                peopledeserilizing();
                addcrimes();
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
            if (crimeid.Text != "Crime ID" && crimeid.Items.Contains(crimeid.Text))
            {
                if (!delrdio.Checked)
                {
                    desctxt.Enabled = true;
                    imagegroupbox.Enabled = true;
                    groupBoxcrimetype.Enabled = true;
                    groupBoxcrimelocation.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBoxpplinv.Enabled = true;
                    groupBoxadditem.Enabled = true;
                    if (Login_Form.ID == "admin")
                        groupBoxoffid.Enabled = true;
                }
                retrieveData();
            }
            else
            {
                if (!addrdio.Checked)
                {
                    crimeid.Enabled = true;
                    groupBoxoffid.Enabled = false;
                    desctxt.Enabled = false;
                    imagegroupbox.Enabled = false;
                    groupBoxcrimetype.Enabled = false;
                    groupBoxcrimelocation.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBoxpplinv.Enabled = false;
                    groupBoxadditem.Enabled = false;
                    desctxt.ForeColor = Color.LightGray;
                    desctxt.Text = "Description";
                    location.ForeColor = Color.LightGray;
                    location.Text = "Location";
                    itemname.ForeColor = Color.LightGray;
                    itemname.Text = "ITEM NAME";
                    itemdescription.ForeColor = Color.LightGray;
                    itemdescription.Text = "ITEM DESCRIPTION";
                    officerid.Text = "Officer ID";
                    crimetype.Text = "Crime Type";
                    founditems.Rows.Clear();
                    peopleinv.Rows.Clear();
                }

            }
            if (crimeid.Text != "Crime ID" || addrdio.Checked)
                pictureBox11.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "Search here")
            {
                if (comboBox1.Text == "Crime Data ")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["crimeData"];
                    if (crimeid.Items.Contains(searchTextBox.Text))
                    {
                        updrdio.Checked = true;
                        retrieveData();
                        crimeid.Text = searchTextBox.Text;
                    }
                    else
                        messageBoxOK.Show("There is no crime with such ID");
                }
                else if (comboBox1.Text == "Involved People ")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["invPeople"];
                    string tempid = searchTextBox.Text;
                    bool found = false;
                    for (int i = 0; i < involvedGrid1.Rows.Count; i++)
                    {
                        if (tempid == involvedGrid1.Rows[i].Cells[1].Value.ToString())
                        {
                            involvedGrid1.Rows[i].Selected = true;
                            gridPB.Image = Image.FromFile(li[i].imagePath);
                            found = true;
                        }
                        else
                            involvedGrid1.Rows[i].Selected = false;
                    }
                    if (!found)
                        MessageBox.Show("This ID doesn't exist");
                }
                else if (comboBox1.Text == "Regestration Form ")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["regForm"];
                    string tempid = searchTextBox.Text;
                    bool found = false;
                    for (int i = 0; i < usersgrid.Rows.Count; i++)
                    {
                        if (tempid == usersgrid.Rows[i].Cells[0].Value.ToString())
                        {
                            usersgrid.Rows[i].Selected = true;
                            userimage2.Image = Image.FromFile(oflis[check_id_off(tempid)].img);
                            found = true;
                        }
                        else
                            usersgrid.Rows[i].Selected = false;
                    }
                    if (!found)
                        messageBoxOK.Show("This ID doesn't exist");
                }
            }
            else if (searchTextBox.Text == "Search here")
            {
                messageBoxOK.Show("Enter data to search for");
            }
            else
            {
                messageBoxOK.Show("Enter Valid Data!");
            }
            searchTextBox.Text = "Search here";
            searchTextBox.ForeColor = Color.LightGray;
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
        void OfficerCloseCrime(string id, string crimid)
        {
            try
            {
                oflis[check_id_off(id)].crimID.Remove(crimid);
                oflis[check_id_off(id)].closedCrime.Add(crimid);
            }
            catch { }
        }
        public int check_id_off(string chid)
        {
            deser();
            int i = 0;
            foreach (officer_info off in oflis)
            {
               
                if (off.offId == chid)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public void upser()
        {
            List<Type> types = new List<Type>();
            for (int i = 0; i < oflis.Count; i++)
            {
                Type tt = oflis.ElementAt(i).GetType();
                if (!types.Contains(tt))
                {
                    types.Add(tt);
                }
            }
            XmlSerializer se = new XmlSerializer(typeof(List<officer_info>), types.ToArray());
            try
            {
                File.Delete("Offinfo.xml");
            }
            catch
            { }
            using (FileStream fs = new FileStream("Offinfo.xml", FileMode.OpenOrCreate))
            {
                se.Serialize(fs, oflis);
            }
        }
        public List<officer_info> offinf()
        {
            deser();
            officerid.Items.Clear();
            List<officer_info> offi = new List<officer_info>();
            foreach (officer_info of in oflis)
            {
                if (of.crimID.Count() < 10 && of.offId != "admin")
                {
                    offi.Add(of);
                    officerid.Items.Add(of.offId);
                }
            }
            return offi;
        }
        private void showusers()
        {
            usersgrid.Rows.Clear();
            Label temp = new Label();
            usersgrid.ColumnCount = 7;
            usersgrid.Columns[0].Name = "UserID";
            usersgrid.Columns[0].Width = 90;
            usersgrid.Columns[1].Name = "Name";
            usersgrid.Columns[1].Width = 200;
            usersgrid.Columns[2].Name = "Password";
            usersgrid.Columns[3].Name = "BirthDate";
            usersgrid.Columns[3].Width = 200;
            usersgrid.Columns[4].Name = "Gender";
            usersgrid.Columns[4].Width = 90;
            usersgrid.Columns[5].Name = "Marital Status";
            usersgrid.Columns[6].Name = "Address";
            userimage2.Image = Image.FromFile("nophoto.png");
            deser();
            foreach (officer_info of in oflis)
            {

                usersgrid.Rows.Add(of.offId, of.name, of.pss, of.birth, of.gen, of.mar, of.add);
                usersgrid.Rows[usersgrid.Rows.Count - 1].Cells[0].ReadOnly = true;
            }
        }
        private void usersgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = usersgrid.SelectedCells[0].RowIndex;
                int index = check_id_off(usersgrid.Rows[i].Cells[0].Value.ToString());
                userimage2.Image = Image.FromFile(oflis[index].img);
                user2 = oflis[index].img;
            }
            catch { }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || pss.Text == "" || id.Text == "" || address.Text == "" || user == "nophoto.png" || (!mar.Checked && !unmar.Checked) || (!Male.Checked && !Female.Checked))
            {
                messageBoxOK.Show("Please add values to the Required(*) fields!");
                return;
            }
            if (check_id_off(id.Text) != -1)
            {
                messageBoxOK.Show("This ID already exists!");
                return;
            }
            officer_info off = new officer_info(name.Text, id.Text, bd.Text, pss.Text, (Male.Checked) ? "Male" : "Female", (mar.Checked) ? "Married" : "Unmarried", placeFileinDebug(user), address.Text);
            oflis.Add(off);
            upser();
            regClear();
            showusers();
            offinf();
            messageBoxOK.Show("Added!");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (officer_info i in oflis)
            {
                ac.Add(i.offId);
            }
            searchTextBox.AutoCompleteCustomSource = ac;
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void regClear()
        {
            showusers();
            name.Clear();
            pss.Clear();
            id.Clear();
            address.Clear();
            Female.Checked = false;
            Male.Checked = false;
            mar.Checked = false;
            unmar.Checked = false;
            userimage.Image = Image.FromFile("nophoto.png");
            user = "nophoto.png";
        }
        private void deleteofficerfromallassignedcrime(string officer_id)
        {
            foreach (Crime c in listc)
            {
                if (c.officerid == officer_id)
                {
                    c.officerid = "Officer ID"; 
                }
            }
            peopleserelizing();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (usersgrid.Rows.Count == 0)
            {
                messageBoxOK.Show("Nothing to be deleted!");
                return;
            }
                int ii = usersgrid.SelectedCells[0].RowIndex;
                int index = check_id_off(usersgrid.Rows[ii].Cells[0].Value.ToString());
                if (oflis.ElementAt(index).offId != "admin")
                {
                    if (ourMessageBox.Show("Are you sure about Crime status?") == DialogResult.Yes)
                    {
                        string tem = oflis[index].offId;
                        deleteofficerfromallassignedcrime(tem);
                        oflis.RemoveAt(index);
                        upser();
                        showusers();
                        offinf();
                    }
                }
            else if (oflis.ElementAt(index).offId == "admin")
            {
                messageBoxOK.Show("can't delete the admin");
            }
        }
        private void userimage2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userimage2.Image = Image.FromFile(placeFileinDebug(openFileDialog1.FileName));
                userimage2.ImageLocation = placeFileinDebug(openFileDialog1.FileName);
                user2 = placeFileinDebug(openFileDialog1.FileName);
            }
            openFileDialog1.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (usersgrid.Rows.Count == 0)
            {
                messageBoxOK.Show("Nothing to be edited!");
                return;
            }
            try
            {
                int ii = usersgrid.SelectedCells[0].RowIndex;
                int index = check_id_off(usersgrid.Rows[ii].Cells[0].Value.ToString());
                if (usersgrid.Rows[ii].Cells[4].Value.ToString() != "Male" && usersgrid.Rows[ii].Cells[4].Value.ToString() != "Female")
                {
                    messageBoxOK.Show("Can't update like this please Enter a valid gender You should select between (Male or Female)!");
                    return;
                }

                if (usersgrid.Rows[ii].Cells[5].Value.ToString() != "Married" && usersgrid.Rows[ii].Cells[5].Value.ToString() != "Unmarried")
                {
                    messageBoxOK.Show("Can't update like this please Enter a valid Marital status You should select between (Married or Unmarried)!");
                    return;
                }
                try
                {
                    DateTime checkingvalidity = Convert.ToDateTime(usersgrid.Rows[ii].Cells[3].Value.ToString());
                }
                catch
                {
                    messageBoxOK.Show("Can't update like this please Enter a valid Date Value (dd/mm/yyyy)!");
                    return;
                }
                oflis[index].updateInfo(usersgrid.Rows[ii].Cells[1].Value.ToString(),
                                    usersgrid.Rows[ii].Cells[0].Value.ToString(),
                                    usersgrid.Rows[ii].Cells[3].Value.ToString(),
                                    usersgrid.Rows[ii].Cells[2].Value.ToString(),
                                    usersgrid.Rows[ii].Cells[4].Value.ToString(),
                                    usersgrid.Rows[ii].Cells[5].Value.ToString(),
                                    placeFileinDebug(user2),
                                    usersgrid.Rows[ii].Cells[6].Value.ToString());
                upser();
                showusers();
                deser();
                offinf();
                messageBoxOK.Show("User " + usersgrid.Rows[ii].Cells[0].Value.ToString() + " has been edited!");
            }
            catch
            { }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (!delrdio.Checked)
            {
                if (desctxt.Text == "Description" || crimetype.Text == "Crime Type" || location.Text == "Location" || !crimetype.Items.Contains(crimetype.Text) || (!officerid.Items.Contains(officerid.Text) && officerid.Text != "Officer ID")   || !crimeid.Items.Contains(crimeid.Text))
                {
                    messageBoxOK.Show("Enter Valid Data in the Required fields");
                    return;
                }
                if (adjAddress(location.Text) == "")
                {
                    messageBoxOK.Show("address format is not valid");
                    return;
                }
            }
            if (addrdio.Checked)
            {
                if (ofliss.Count != 0)
                {
                    oflis = ofliss;
                    upser();
                }
                imageList1.ImageSize = new Size(256, 256);
                string stat;
                if (radioButton1.Checked)
                    stat = "OPENED";
                else
                    stat = "CLOSED";
                Crime c = new Crime(mshhanst3mloabdn, desctxt.Text.ToString(), stat, location.Text.ToString(), (officerid.Text == "") ? "Unknown" : officerid.Text, crimetype.Text.ToString(), items, pp, motiv, eved, imgname, locatcrime);
                listc.Add(c);
                erasewhatnotmine();
                peopleserelizing();
                peopledeserilizing();
                addcrimes();
                crimeids();
                peopleinv.Rows.Clear();
                pp.Clear();
                eved.Clear();
                motiv.Clear();
                locatcrime.Clear();
                items.Clear();
               
                crimeimg.Image = a;
                messageBoxOK.Show("Added!");
            }
            else
            {
                imageList1.ImageSize = new Size(256, 256);
                if (updrdio.Checked)
                {
                    if (ofliss.Count != 0)
                    {
                        oflis = ofliss;
                        upser();
                    }
                    string stat;
                    if (radioButton1.Checked)
                        stat = "OPENED";
                    else
                        stat = "CLOSED";
                    int x = Int32.Parse(crimeid.Text);
                    foreach (Crime i in myCrime)
                    {
                        if (i.id.ToString() == crimeid.Text.ToString())
                        {

                            i.description = desctxt.Text;
                            i.crime_status = stat;
                            i.crime_location = location.Text;
                            i.crimetype = crimetype.Text;
                            i.officerid = officerid.Text;
                            i.imglocation = tempimg;
                            i.items = items;
                            founditems.Rows.Clear();
                            founditems.ColumnCount = 4;
                            founditems.Columns[0].Name = "Name";
                            founditems.Columns[1].Name = "Description";
                            founditems.Columns[2].Name = "Date";
                            founditems.Columns[3].Name = "Person ID";
                            foreach (Item it in i.items)
                            {
                                founditems.Rows.Add(it.itemname, it.itemdescription, it.date, it.PersonID);
                            }
                            i.involved_people = pp;
                            i.Evidence = eved;
                            i.Motivation = motiv;
                            i.locacrime = locatcrime;
                            break;
                        }
                    }
                    if (ourMessageBox.Show("Are you sure about Crime status?") == DialogResult.Yes)
                    {
                        peopleserelizing();
                        peopledeserilizing();
                        if (stat == "CLOSED")
                        {
                            adjustCriminals(x);
                            foreach (Crime i in listc)
                            {
                                if (i.id.ToString() == crimeid.Text.ToString())
                                {
                                    OfficerCloseCrime(i.officerid, crimeid.Text);
                                }
                            }
                        }
                        for (int i = 0; i < li.Count; i++)
                            for (int j = 0; j < deltedPeople.Count; j++)
                                if (deltedPeople[j] == li[i].personalID && li[i].CrimeIDS.Contains(x))
                                    li[i].CrimeIDS.Remove(x);
                        deltedPeople.Clear();
                        addcrimes();
                        messageBoxOK.Show("Updated!");
                    }
                    else
                    {
                        messageBoxOK.Show("unfortunately your data wasn't updated!");
                    }
                }
                else
                {
                    if (crimeid.Items.Contains(crimeid.Text))
                    {
                        if (ourMessageBox.Show("Are you sure for deleting this crime?") == DialogResult.Yes)
                        {
                            string temps = "";
                            string tempid = crimeid.Text;
                            for (int i = 0; i < listc.Count; i++)
                            {
                                if (listc.ElementAt(i).id.ToString() == crimeid.Text)
                                {
                                    temps = listc.ElementAt(i).officerid;
                                    listc.RemoveAt(i);
                                    break;
                                }
                            }
                            erasewhatnotmine();
                            peopleserelizing();
                            peopledeserilizing();
                            addcrimes();
                            crimeids();
                            if (check_id_off(temps) >= 0)
                            {
                                int i = check_id_off(temps);
                                if (oflis[i].closedCrime.Contains(tempid))
                                    oflis[i].closedCrime.Remove(tempid);
                                if (oflis[i].crimID.Contains(tempid))
                                    oflis[i].crimID.Remove(tempid);
                                upser();
                                deser();
                            }
                            messageBoxOK.Show("Deleted!");
                        }
                    }
                    else
                        messageBoxOK.Show("ID NOt Found ! ");
                }
                erasewhatnotmine();
                peopleinv.Rows.Clear();
                founditems.Rows.Clear();
                crimeimg.Image = a;
                desctxt.Text = "Description";
                desctxt.ForeColor = Color.LightGray;
                officerid.Text = "Officer ID";
                crimetype.Text = "Crime Type";
                location.Text = "Location";
                location.ForeColor = Color.LightGray;
                peopledeserilizing();
                addcrimes();
                crimeid.Text = "Crime ID";
                
            }
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (Crime i in myCrime)
            {
                ac.Add(i.id.ToString());
            }
            searchTextBox.AutoCompleteCustomSource = ac;
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            charts();
            offinf();
        }
        private void peopleserelizing()
        {
            try
            {
                File.Delete("Crime.xml");
            }
            catch
            { }
            Crime temp = new Crime();
            XmlSerializer serial = new XmlSerializer(listc.GetType());
            using (FileStream stream = new FileStream("Crime.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                serial.Serialize(stream, listc);
            }
        }
        private void peopledeserilizing()
        {
            XmlSerializer serial = new XmlSerializer(listc.GetType());
            using (FileStream stream = new FileStream("Crime.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    listc = serial.Deserialize(stream) as List<Crime>;
                }
                catch
                { }
            }
            XmlSerializer seriall = new XmlSerializer(types.GetType());
            using (FileStream stream = new FileStream("Crimetype.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    types = seriall.Deserialize(stream) as List<Crimetype>;
                }
                catch
                { }
            }
            erasewhatnotmine();
        }
        private void erasewhatnotmine()
        {
            myCrime.Clear();
            for (int i = 0; i < listc.Count; i++)
                if (listc[i].officerid == Login_Form.ID || Login_Form.ID == "admin")
                {
                    myCrime.Add(listc[i]);
                }
        }
        public void crimeTypeDeserilizing()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Crimetype>));
            using (FileStream stream = new FileStream("CrimeType.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    crimetype.Items.Clear();
                    List<Crimetype> CTTypes = ser.Deserialize(stream) as List<Crimetype>;
                    for (int i = 0; i < CTTypes.Count; i++)
                        crimetype.Items.Add(CTTypes[i].typename);
                }
                catch
                { }
            }
        }
        private void crimeids()
        {
            crimeidd.Clear();
            crimeid.DataSource = null;
            crimeid.Text = "Crime ID";
            crimeidd.Add("Crime ID");
            mshhanst3mloabdn = 0;
            foreach (Crime i in myCrime)
            {
                mshhanst3mloabdn = Math.Max(i.id, mshhanst3mloabdn);
                crimeidd.Add(i.id.ToString());
            }
            mshhanst3mloabdn++;
            crimeid.DataSource = crimeidd;
        }
        private void retrieveData()
        {
            foreach (Crime i in myCrime)
            {
                if (crimeid.Text.ToString() == i.id.ToString())
                {

                    desctxt.Text = i.description;
                    off_id = i.officerid.ToString();
                    location.Text = i.crime_location;
                    if (i.crime_status == "OPENED")
                    { radioButton1.Checked = true; }
                    else
                    {
                        radioButton2.Checked = true;
                        if (!delrdio.Checked)
                            diseabling();
                    }
                    officerid.Text = i.officerid;
                    crimetype.Text = i.crimetype;
                    items = i.items;
                    imageList1.Images.Clear();
                    sz = 0;
                    x = -1;
                    imageList1.ImageSize = new Size(256, 256);
                    tempimg.Clear();
                    foreach (String loc in i.imglocation)
                    {
                        imageList1.Images.Add(Image.FromFile(loc));
                        tempimg.Add(loc);
                        sz++;
                    }
                    x = sz - 1;
                    try
                    {
                        crimeimg.Image = imageList1.Images[x];
                    }
                    catch
                    {
                        crimeimg.Image = a;
                    }
                    founditems.Rows.Clear();
                    founditems.ColumnCount = 4;
                    founditems.Columns[0].Name = "Name";
                    founditems.Columns[1].Name = "Description";
                    founditems.Columns[2].Name = "Date";
                    founditems.Columns[3].Name = "Person ID";
                    foreach (Item it in i.items)
                    {
                        founditems.Rows.Add(it.itemname, it.itemdescription, it.date, it.PersonID);
                    }
                    peopleinv.Rows.Clear();
                    peopleinv.ColumnCount = 5;
                    peopleinv.Columns[0].Name = "Person ID";
                    peopleinv.Columns[1].Name = "Location_at_crime";
                    peopleinv.Columns[2].Name = "Name";
                    peopleinv.Columns[3].Name = "Evidence";
                    peopleinv.Columns[4].Name = "Motaivation";
                    for (int j = 0; j < i.involved_people.Count; j++)
                    {
                        string temp = "";
                        foreach (involvedPeople k in li)
                        {
                            if (i.involved_people.ElementAt(j) == k.personalID)
                            {
                                temp = k.name;
                                break;
                            }
                        }
                        peopleinv.Rows.Add(i.involved_people.ElementAt(j), i.locacrime.ElementAt(j), temp, i.Evidence.ElementAt(j), i.Motivation.ElementAt(j));
                    }
                    pp = i.involved_people;
                    eved = i.Evidence;
                    motiv = i.Motivation;
                    locatcrime = i.locacrime;
                    if (Login_Form.ID != "admin")
                        CrimeTypeAddBtn.Enabled = false;
                }
            }
        }
        private void crimeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (crimeid.Text == "Crime ID")
            {
                if (!addrdio.Checked)
                {
                    crimeimg.Image = a;
                    x = -1;
                    sz = 0;
                    imageList1.Images.Clear();
                    tempimg.Clear();
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
                }
                desctxt.ForeColor = Color.LightGray;
                desctxt.Text = "Description";
                location.ForeColor = Color.LightGray;
                location.Text = "Location";
                itemname.ForeColor = Color.LightGray;
                itemname.Text = "ITEM NAME";
                itemdescription.ForeColor = Color.LightGray;
                itemdescription.Text = "ITEM DESCRIPTION";
                officerid.Text = "Officer ID";
                crimetype.Text = "Crime Type";
                founditems.Rows.Clear();
                peopleinv.Rows.Clear();
            }
            else
            {
                retrieveData();
            }
        }
        private void desctxt_TextChanged(object sender, EventArgs e)
        {
            if (desctxt.Text != "Description")
            {
                desctxt.ForeColor = Color.Black;
            }
        }
        private void location_TextChanged(object sender, EventArgs e)
        {
            if (location.Text != "Location")
                location.ForeColor = Color.Black;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (!peopleid.Items.Contains(peopleid.Text)|| peopleid.Text == "Person ID" || locationatcrime.Text == "Location" || locationatcrime.Text == "")
            {
                messageBoxOK.Show("Please Enter Valid Data");
            }
            else
            {
                if (!pp.Contains(peopleid.Text.ToString()))
                {
                    foreach (involvedPeople ip in li)
                    {
                        if (ip.personalID == peopleid.Text)
                        {
                            if (adjAddress(locationatcrime.Text) == "")
                            {
                                messageBoxOK.Show("address format is not valid");
                                break;
                            }
                            peopleinv.Rows.Add(ip.personalID, locationatcrime.Text, ip.name, evdcheck.Checked, motvcheck.Checked);
                            pp.Add(ip.personalID);
                            eved.Add(evdcheck.Checked);
                            motiv.Add(motvcheck.Checked);
                            locatcrime.Add(locationatcrime.Text);
                            break;
                        }
                        for (int i = 0; i < peopleinv.Rows.Count; i++)
                        {
                            for (int j = 0; j < peopleinv.Rows[i].Cells.Count; j++)
                                peopleinv.Rows[i].Cells[j].Selected = false; 
                        }
                    }
                    for (int i = 0; i <pp.Count; i++)
                    {
                        for (int j = 0; j < deltedPeople.Count; j++)
                        {
                            if (pp[i] == deltedPeople[j])
                            {
                                deltedPeople.RemoveAt(j);
                                break; 
                            }
                        }
                    }
                }
                else
                {
                    messageBoxOK.Show("This ID Already Exist !");
                }
                peopleid.Text = "Person ID";
                locationatcrime.Text = "Location";
                locationatcrime.ForeColor = Color.LightGray;
                evdcheck.Checked = false;
                motvcheck.Checked = false;
                bunifuImageButton6.Enabled = false;
                bunifuImageButton7.Enabled = false;
            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (itemname.Text == "ITEM NAME" || itemdescription.Text == "ITEM DESCRIPTION" || itemdescription.Text == "" || itemname.Text == "" || itemspeople.Text == "Person ID" || !itemspeople.Items.Contains(itemspeople.Text))
            {
                messageBoxOK.Show("Please Enter Valid Data");
            }
            else
            {
                Item i = new Item(itemname.Text.ToString(), itemdescription.Text.ToString(), dateTimePicker1.Value.ToString(), itemspeople.Text);
                items.Add(i);
                founditems.Rows.Add(itemname.Text.ToString(), itemdescription.Text.ToString(), dateTimePicker1.Value.ToString(), itemspeople.Text);
                string name = "";
                foreach (involvedPeople a in li)
                {
                    if (itemspeople.Text == a.personalID)
                    {
                        name = a.name;
                        break;
                    }

                }
                if (itemspeople.Text != "unknow" && !pp.Contains(itemspeople.Text.ToString()))
                {
                    peopleinv.Rows.Add(itemspeople.Text, "unknow", name, false, false);
                    pp.Add(itemspeople.Text);
                    eved.Add(false);
                    motiv.Add(false);
                    locatcrime.Add("unknow");
                }
                itemname.Text = "ITEM NAME";
                itemname.ForeColor = Color.LightGray;
                itemdescription.Text = "ITEM DESCRIPTION";
                itemdescription.ForeColor = Color.LightGray;
                itemspeople.Text = "Person ID";
                bunifuImageButton2.Enabled = false;
                bunifuImageButton3.Enabled = false; 
            }
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (itemname.Text == "ITEM NAME" || itemdescription.Text == "ITEM DESCRIPTION" || itemdescription.Text == "" || itemname.Text == "" || itemspeople.Text == "Person ID" || !itemspeople.Items.Contains(itemspeople.Text))
            {
                messageBoxOK.Show("Please Enter Valid Data");
            }
            else
            {
                if (itemindex < items.Count)
                {
                    items[itemindex].itemname = itemname.Text;
                    items[itemindex].itemdescription = itemdescription.Text;
                    items[itemindex].date = dateTimePicker1.Text;
                    founditems.Rows[itemindex].Cells[0].Value = itemname.Text;
                    founditems.Rows[itemindex].Cells[1].Value = itemdescription.Text;
                    founditems.Rows[itemindex].Cells[2].Value = dateTimePicker1.Text;
                    founditems.Rows[itemindex].Cells[3].Value = itemspeople.Text;
                    if (itemspeople.Text != "unknow" && !pp.Contains(itemspeople.Text.ToString()))
                    {
                        string temp = "";
                        foreach (involvedPeople s in li)
                        {
                            if (s.personalID == itemspeople.Text)
                            {
                                temp = s.name;
                            }
                        }
                        peopleinv.Rows.Add(itemspeople.Text, "unknow", temp, false, false);
                        pp.Add(itemspeople.Text);
                        eved.Add(false);
                        motiv.Add(false);
                        locatcrime.Add("unknow");
                    }
                    itemname.Text = "ITEM NAME";
                    itemname.ForeColor = Color.LightGray;
                    itemdescription.Text = "ITEM DESCRIPTION";
                    itemdescription.ForeColor = Color.LightGray;
                    itemspeople.Text = "Person ID";
                }
                else
                {
                    messageBoxOK.Show("There's no data to update it ");
                }
            }
            bunifuImageButton2.Enabled = false;
            bunifuImageButton3.Enabled = false;
            bunifuImageButton1.Enabled = true; 
        }
        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            if (itemindex >= 0)
            {
                bool found = false;
                int innd = 0;
                for (int i=0;i < peopleinv.Rows.Count;i++)
                {
                    if (peopleinv.Rows[i].Cells[0].Value.ToString() == founditems.Rows[itemindex].Cells[3].Value.ToString())
                    {
                       if  (Convert.ToBoolean(peopleinv.Rows[i].Cells[3].Value)|| Convert.ToBoolean(peopleinv.Rows[i].Cells[4].Value))
                        {
                            found = true;
                            innd = i; 
                            break; 
                        }
                    }
                }
                if (!found)
                {
                    messageBoxOK.Show("This person doesn't have motivation and we didn't find any evidence that he/she may commit this crime check if you want to delete him!"); 
                    
                }
                items.RemoveAt(itemindex);
                founditems.Rows.RemoveAt(itemindex);
                itemindex--;
                itemname.Text = "ITEM NAME";
                itemname.ForeColor = Color.LightGray;
                itemdescription.Text = "ITEM DESCRIPTION";
                itemdescription.ForeColor = Color.LightGray;
                itemspeople.Text = "Person ID";
            }
            else
                messageBoxOK.Show("There's no Data to Delete it ");
            bunifuImageButton2.Enabled = false;
            bunifuImageButton3.Enabled = false;
            bunifuImageButton1.Enabled = true;
        }
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            AddCrimeType f = new AddCrimeType();
            f.Show();
            f.FormClosing += F_FormClosing;
        }
        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            crimeTypeDeserilizing();
        }
        private void founditems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = founditems.SelectedCells[0].RowIndex;
            itemindex = i;
            itemname.ForeColor = Color.Black;
            itemdescription.ForeColor = Color.Black;
            itemname.Text = founditems.Rows[i].Cells[0].Value.ToString();
            itemdescription.Text = founditems.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text = founditems.Rows[i].Cells[2].Value.ToString();
            itemspeople.Text = founditems.Rows[i].Cells[3].Value.ToString();
            bunifuImageButton2.Enabled = true;
            bunifuImageButton3.Enabled =true;
            bunifuImageButton1.Enabled = false;
        }
        public void involvedSerialize()
        {
            List<Type> types = new List<Type>();
            for (int i = 0; i < li.Count; i++)
            {
                Type tt = li.ElementAt(i).GetType();
                if (!types.Contains(tt))
                    types.Add(tt);
            }
            involvedSer = new XmlSerializer(typeof(List<involvedPeople>), types.ToArray());
            involvedFs = new FileStream("involvedPeople.xml", FileMode.Truncate);
            involvedSer.Serialize(involvedFs, li);
            involvedFs.Close();
        }
        public void involvedDesrialize()
        {
            involvedFs = new FileStream("involvedPeople.xml", FileMode.OpenOrCreate);
            try
            {
                li = involvedSer.Deserialize(involvedFs) as List<involvedPeople>;
            }
            catch
            { }
            involvedFs.Close();
        }
        private void involvedDelete_Click(object sender, EventArgs e)
        {
            if (involvedGrid1.Rows.Count == 0)
                return;
            if (ourMessageBox.Show("Are you sure about want to delete this person?") == DialogResult.No)
                return;
            try
            {
                int i = involvedGrid1.SelectedCells[0].RowIndex;
                foreach (Crime c in listc)
                {
                    if (c.involved_people.Contains(involvedGrid1.Rows[i].Cells[1].Value.ToString()))
                        c.involved_people.Remove(involvedGrid1.Rows[i].Cells[1].Value.ToString());
                }

                foreach (Crime c in listc)
                {
                    for (int j = 0; j < c.items.Count; j++)
                    {
                        if (c.items.ElementAt(j).PersonID == involvedGrid1.Rows[i].Cells[1].Value.ToString())
                        {
                            c.items.RemoveAt(j); 
                        }
                    }
                }
                string idpeoplemohm = "";
                for (int j = 0; j < involvedGrid1.Rows.Count; j++)
                {
                    if (j == i)
                    {
                        idpeoplemohm = involvedGrid1.Rows[j].Cells[1].Value.ToString();
                        break; 
                    }
                }
                for (int poin = 0; poin < peopleinv.Rows.Count; poin++)
                {
                    if (peopleinv.Rows[poin].Cells[0].Value.ToString() == idpeoplemohm)
                    {
                        peopleinv.Rows.RemoveAt(poin);
                        break;
                    }
                }
                for (int poin = 0; poin < founditems.Rows.Count; poin++)
                {
                    if (founditems.Rows[poin].Cells[3].Value.ToString() == idpeoplemohm)
                    {
                        founditems.Rows.RemoveAt(poin);
                        break; 
                    }
                }
                li.RemoveAt(involvedListIndex);
                peopleserelizing();
                erasewhatnotmine();
                hatoelid();
                
            }
            catch
            { }
            involvedSerialize();
            getDataForGrid();
        }
        private void gridPB_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gridPB.Image = Image.FromFile(openFileDialog1.FileName);
                inImageH = openFileDialog1.FileName;
            }
            openFileDialog1.Dispose();
        }
        private void f_ClosingInvolved(object sender, FormClosingEventArgs e)
        {
            inAddressBox.Text = MapAddress.frmMapIt.s;
            this.Show();
        }
        private void f_ClosingCriminalLocation(object sender, FormClosingEventArgs e)
        {
            locationatcrime.Text = MapAddress.frmMapIt.s;
            this.Show();
        }
        bool checkNationality (string s)
        {
            if (inNatCBox.Items.Contains(s))
                return false;
            return true;
        }
        bool checkPersonID(string ide)
        {
            foreach (involvedPeople i in li)
                if (i.personalID == ide)
                {
                    return true;
                }
            return false;
        }
        private void clearInvolv()
        {
            inImageH = "nophoto.png";
            inNameBox.Text = inIDBox.Text = inAddressBox.Text = "";
            inNatCBox.Text = "Nationality";
            inMSRB1.Checked = inMSRB2.Checked = inMSRB3.Checked = inMSRB4.Checked = inMrSRB1.Checked = inMrSRB2.Checked = inGenderRB1.Checked = inGenderRB2.Checked = false;
            inImage.Image = Image.FromFile("nophoto.png");
            inMSRB1.Enabled = false;
            inMSRB2.Enabled = false;
            inMSRB3.Enabled = false;
            inMSRB4.Enabled = false;
        }
        private void addInvolvedBtn_Click(object sender, EventArgs e)
        {
            if (inNameBox.Text == "" || inIDBox.Text == "" || inNatCBox.Text == "Nationality" || inAddressBox.Text == "" || (!inMSRB1.Checked && !inMSRB2.Checked && !inMSRB3.Checked && !inMSRB4.Checked) || (!inMrSRB1.Checked && !inMrSRB2.Checked) || (!inGenderRB1.Checked && !inGenderRB2.Checked) || inImageH == "nophoto.png")
            {
                messageBoxOK.Show("Please add values to the Required(*) fields!");
                return;
            }
            if (checkPersonID(inIDBox.Text))
            {
                messageBoxOK.Show("This ID already exists");
                return;
            }
            if (checkNationality(inNatCBox.Text))
            {
                messageBoxOK.Show("This Nationality doesn't exist");
                return;
            }
            if (adjAddress(inAddressBox.Text) == "")
            {
                messageBoxOK.Show("Please Enter a valid address");
                return;
            }
            involvedPeople ip = new involvedPeople();
            ip.address = inAddressBox.Text;
            ip.birthDate = inDate.Text;
            if (inGenderRB1.Checked)
                ip.gender = inGenderRB1.Text;
            else
                ip.gender = inGenderRB2.Text;
            ip.imagePath = placeFileinDebug(inImageH);
            if (inMrSRB1.Checked)
                ip.martialStatus = inMrSRB1.Text;
            else
                ip.martialStatus = inMrSRB2.Text;
            if (inMSRB1.Checked)
                ip.militaryStatus = inMSRB1.Text;
            else if (inMSRB2.Checked)
                ip.militaryStatus = inMSRB2.Text;
            else if (inMSRB3.Checked)
                ip.militaryStatus = inMSRB3.Text;
            else
                ip.militaryStatus = inMSRB4.Text;
            ip.name = inNameBox.Text;
            ip.nationality = inNatCBox.Text;
            ip.personalID = inIDBox.Text;
            ip.CrimeIDS = new List<int>();
            involvedDesrialize();
            li.Add(ip);
            involvedSerialize();
            clearInvolv();
            getDataForGrid();
            hatoelid();
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (involvedPeople i in li)
            {
                ac.Add(i.personalID);
            }
            searchTextBox.AutoCompleteCustomSource = ac;
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void inImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inImage.Image = Image.FromFile(openFileDialog1.FileName);
                inImageH = openFileDialog1.FileName;
            }
            openFileDialog1.Dispose();
        }
        private void involvedGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            involvedListIndex = 0;
            int i = involvedGrid1.SelectedCells[0].RowIndex;
            foreach (involvedPeople ip in li)
            {
                if (ip.personalID == involvedGrid1.Rows[i].Cells[1].Value.ToString())
                    break;
                involvedListIndex++;
            }
            try
            {
            gridPB.Image = Image.FromFile(li[involvedListIndex].imagePath);
            }
            catch
            {
                gridPB.Image = Image.FromFile("nophoto.png");

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                involvedDesrialize();
                int i = involvedGrid1.SelectedCells[0].RowIndex;
                if (checkNationality(involvedGrid1.Rows[i].Cells[5].Value.ToString()))
                {
                    messageBoxOK.Show("This Nationality doesn't exist");
                    return;
                }
                if (adjAddress(involvedGrid1.Rows[i].Cells[2].Value.ToString()) == "")
                {
                    messageBoxOK.Show("Enter Valid address .. eg.(region, city)");
                    return;
                }
                if (involvedGrid1.Rows[i].Cells[3].Value.ToString() != "Male" && involvedGrid1.Rows[i].Cells[3].Value.ToString() != "Female")
                {
                    messageBoxOK.Show("Enter Valid gender .. (Male, Female)");
                    return;
                }
                if (involvedGrid1.Rows[i].Cells[6].Value.ToString() != inMSRB1.Text && involvedGrid1.Rows[i].Cells[6].Value.ToString() != inMSRB2.Text && involvedGrid1.Rows[i].Cells[6].Value.ToString() != inMSRB3.Text && involvedGrid1.Rows[i].Cells[6].Value.ToString() != inMSRB4.Text)
                {
                    messageBoxOK.Show("please enter a valid entity in military status as showed above");
                    return;
                }
                if (involvedGrid1.Rows[i].Cells[7].Value.ToString() != "Married" && involvedGrid1.Rows[i].Cells[7].Value.ToString() != "Unmarried")
                {
                    messageBoxOK.Show("Enter Valid martial status (Married, Unamrried)");
                    return;
                }
                try
                {
                    DateTime checkingvalidity = Convert.ToDateTime(involvedGrid1.Rows[i].Cells[4].Value.ToString());
                }
                catch
                {
                    messageBoxOK.Show("Can't update like this please Enter a valid Date Value (dd/mm/yyyy)!");
                    return;
                }
                li[involvedListIndex].name = involvedGrid1.Rows[i].Cells[0].Value.ToString();
                li[involvedListIndex].personalID = involvedGrid1.Rows[i].Cells[1].Value.ToString();
                li[involvedListIndex].address = involvedGrid1.Rows[i].Cells[2].Value.ToString();
                li[involvedListIndex].gender = involvedGrid1.Rows[i].Cells[3].Value.ToString();
                li[involvedListIndex].birthDate = involvedGrid1.Rows[i].Cells[4].Value.ToString();
                li[involvedListIndex].nationality = involvedGrid1.Rows[i].Cells[5].Value.ToString();
                li[involvedListIndex].militaryStatus = involvedGrid1.Rows[i].Cells[6].Value.ToString();
                li[involvedListIndex].martialStatus = involvedGrid1.Rows[i].Cells[7].Value.ToString();
                li[involvedListIndex].imagePath = placeFileinDebug(inImageH);
                involvedSerialize();
                messageBoxOK.Show("Edited");
            }
            catch
            { }
        }
        public void getDataForGrid()
        {
            involvedDesrialize();
            involvedGrid1.Rows.Clear();
            involvedGrid1.Refresh();
            gridPB.Image = Image.FromFile("nophoto.png");
            foreach (involvedPeople ip in li)
            {
                involvedGrid1.Rows.Add(ip.name, ip.personalID, ip.address, ip.gender, ip.birthDate, ip.nationality, ip.militaryStatus, ip.martialStatus);
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
                a.FormClosing += f_ClosingCriminalLocation;
            }
            else
                messageBoxOK.Show("OOPS! You're offline please add the address manually!");
        }
        private void itemname_Enter(object sender, EventArgs e)
        {
            if (itemname.Text == "ITEM NAME")
            {
                itemname.Text = "";
                itemname.ForeColor = Color.Black;
            }
        }
        private void itemname_Leave(object sender, EventArgs e)
        {
            if (itemname.Text == "")
            {
                itemname.Text = "ITEM NAME";
                itemname.ForeColor = Color.LightGray;
            }
        }
        private void peopleinv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bunifuImageButton5.Enabled = false;
                bunifuImageButton6.Enabled = true;
                bunifuImageButton7.Enabled = true; 
                int i = peopleinv.SelectedCells[0].RowIndex;
                invindexgdid = i;
                peopleid.Text = peopleinv.Rows[i].Cells[0].Value.ToString();
                locationatcrime.Text = peopleinv.Rows[i].Cells[1].Value.ToString();
                locationatcrime.ForeColor = Color.Black;
                if (peopleinv.Rows[i].Cells[3].Value.ToString() == "False")
                    evdcheck.Checked = false;
                else
                    evdcheck.Checked = true;
                if (peopleinv.Rows[i].Cells[4].Value.ToString() == "False")
                    motvcheck.Checked = false;
                else
                    motvcheck.Checked = true;
            }
            catch { }
        }
        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (peopleid.Text == "Person ID" || locationatcrime.Text == "Location" || locationatcrime.Text == "")
            {
                messageBoxOK.Show("Please Enter Valid Data");
            }
            else
            {
                if (invindexgdid < pp.Count)
                {
                    if (adjAddress(locationatcrime.Text) == "")
                    {
                        messageBoxOK.Show("Enter valid format address");
                        return;
                    }
                    peopleinv.Rows[invindexgdid].Cells[0].Value = peopleid.Text;
                    string temp = "";
                    foreach (involvedPeople ip in li)
                    {
                        if (ip.personalID == peopleid.Text.ToString())
                        {
                            peopleinv.Rows[invindexgdid].Cells[2].Value = ip.name;
                            temp = ip.name;
                            break;
                        }
                    }
                    peopleinv.Rows[invindexgdid].Cells[1].Value = locationatcrime.Text;
                    peopleinv.Rows[invindexgdid].Cells[3].Value = evdcheck.Checked;
                    peopleinv.Rows[invindexgdid].Cells[4].Value = motvcheck.Checked;
                    pp[invindexgdid] = peopleid.Text;
                    eved[invindexgdid] = evdcheck.Checked;
                    motiv[invindexgdid] = motvcheck.Checked;
                    locatcrime[invindexgdid] = locationatcrime.Text;
                    peopleid.Text = "Person ID";
                    locationatcrime.Text = "Location";
                    evdcheck.Checked = false;
                    motvcheck.Checked = false;
                }
                else
                    messageBoxOK.Show("There's no data to update it ");
                bunifuImageButton5.Enabled = true;
                bunifuImageButton6.Enabled = false;
                bunifuImageButton7.Enabled = false; 
                for (int i = 0; i < peopleinv.Rows.Count; i++)
                {
                    for (int j = 0; j < peopleinv.Rows[i].Cells.Count; j++)
                        peopleinv.Rows[i].Cells[j].Selected = false;
                }
            }
        }
        private void locationatcrime_Enter(object sender, EventArgs e)
        {
            if (locationatcrime.Text == "Location")
            {
                locationatcrime.Text = "";
                locationatcrime.ForeColor = Color.Black;
            }
        }
        private void f_ClosingCrime(object sender, FormClosingEventArgs e)
        {
            location.Text = MapAddress.frmMapIt.s;
            this.Show();
        }
        private void userimage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            imageList1.ImageSize = new Size(256, 256);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userimage.Image = Image.FromFile(placeFileinDebug(openFileDialog1.FileName));
                user = placeFileinDebug(openFileDialog1.FileName);
                imageList1.Images.Add(userimage.Image);
                x = sz;
                sz++;
            }
            openFileDialog1.Dispose();
        }
        private void officerid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eshta)
            {
                ss = officerid.Text;
                if (updrdio.Checked)
                {
                    try
                    {
                        deser();
                        ofliss = oflis;
                        ofliss[check_id_off(off_id)].crimID.Remove(crimeid.Text);
                        ofliss[check_id_off(officerid.Text)].crimID.Add(crimeid.Text);
                        offinf();
                    
                    }
                    catch {


                          }
                }
                else if (addrdio.Checked)
                {
                    deser();
                    ofliss = oflis;
                  //  messageBoxOK.Show(ofliss[check_id_off(officerid.Text)].crimID.Count.ToString());
                    ofliss[check_id_off(officerid.Text)].crimID.Add(mshhanst3mloabdn.ToString());
                   
                    offinf();
                }
                eshta = false;
                officerid.Text = ss;
                eshta = true;
            }
        }
        private void locationatcrime_Leave(object sender, EventArgs e)
        {
            if (locationatcrime.Text == "")
            {
                locationatcrime.Text = "Location";
                locationatcrime.ForeColor = Color.LightGray;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Crime Data ")
            {
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (Crime i in myCrime)
                {
                    ac.Add(i.id.ToString());
                }
                searchTextBox.AutoCompleteCustomSource = ac;
                searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            else if (comboBox1.Text == "Involved People ")
            {
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (involvedPeople i in li)
                {
                    ac.Add(i.personalID);
                }
                searchTextBox.AutoCompleteCustomSource = ac;
                searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            else if (comboBox1.Text == "Regestration Form ")
            {
                AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                foreach (officer_info i in oflis)
                {
                    ac.Add(i.offId);
                }
                searchTextBox.AutoCompleteCustomSource = ac;
                searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search here")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Search here";
                searchTextBox.ForeColor = Color.LightGray;
            }
        }
        private void DataTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == "Graph")
            {
                tabControl1.TabPages["crimeStat"].BackgroundImage = Image.FromFile("E:\\Files Project\\test\\bin\\Debug\\statWallpaper.jpg");
                barChart.Visible = false;
                pieChart.Visible = false;
            }
            else
            {
                tabControl1.TabPages["crimeStat"].BackgroundImage = null;
                barChart.Visible = true;
                pieChart.Visible = true;
                charts();
            }
        }
        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            if (invindexgdid >= 0)
            {
                deltedPeople.Add(peopleinv.Rows[invindexgdid].Cells[0].Value.ToString());
                peopleinv.Rows.RemoveAt(invindexgdid);
                pp.RemoveAt(invindexgdid);
                eved.RemoveAt(invindexgdid);
                motiv.RemoveAt(invindexgdid);
                locatcrime.RemoveAt(invindexgdid);
                invindexgdid--;
                peopleid.Text = "Person ID";
                locationatcrime.Text = "Location";
                locationatcrime.ForeColor = Color.LightGray;
                evdcheck.Checked = false;
                motvcheck.Checked = false;
            }
            else
                messageBoxOK.Show("There's no Data to delete it ");
            for (int i = 0; i < peopleinv.Rows.Count; i++)
            {
                for (int j = 0; j < peopleinv.Rows[i].Cells.Count; j++)
                    peopleinv.Rows[i].Cells[j].Selected = false;
            }
            bunifuImageButton5.Enabled = true;
            bunifuImageButton6.Enabled = false;
            bunifuImageButton7.Enabled = false;
        }
        public string adjAddress(string s)
        {
            string address = "";
            List<string> l = new List<string>();
            if ((s[0] >= 'a' && s[0] <= 'z') || (s[0] >= 'A' && s[0] <= 'Z') || (s[0] >= '0' && s[0] <= '9'))
            { }
            else
            {
                return "";
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    l.Add(address);
                    address = "";
                    if (i == s.Length - 1 || s[i + 1] != ' ')
                        return "";
                    i++;
                }
                else
                    address += s[i];
            }
            if (address.Length == 0)
                return "";
            l.Add(address);
            if (l.Count < 2)
                return "";
            return l[l.Count - 2];
        }
        public void adjustCriminals(int crimeID)
        {
            foreach (Crime c in listc)
            {
                if (c.id == crimeID)
                {
                    for (int i = 0; i < c.involved_people.Count; i++)
                        for (int j = 0; j < li.Count; j++)
                            if (li[j].personalID == c.involved_people[i] && !li[j].CrimeIDS.Contains(crimeID))
                            {
                                li[j].CrimeIDS.Add(crimeID);
                                break;
                            }
                    break;
                }
            }
            involvedSerialize();
        }
        // Muhammed Aly
        struct Suggestionparameters
        {
            public bool item { get; set; }
            public bool area { get; set; }
            public bool address { get; set; }
            public bool motivation { get; set; }
            public bool evidence { get; set; }
        };
        List<Tuple<involvedPeople, int, Suggestionparameters>> suggestedcriminal = new List<Tuple<involvedPeople, int, Suggestionparameters>>();
        BunifuCards bunifuCards11 = new BunifuCards();
        int lastindex = 0, indexx = 0;
        SortedDictionary<string, bool> added = new SortedDictionary<string, bool>();
        private void bunifuCards6_Click(object sender, EventArgs e)
        {
            added.Clear();
            suggestedcriminal.Clear();
            suggestedcriminal = new List<Tuple<involvedPeople, int, Suggestionparameters>>();
            added = new SortedDictionary<string, bool>();
            indexx = flowLayoutPanel1.Controls.IndexOf(sender as BunifuCards);
            flowLayoutPanel1.Controls[lastindex].BackColor = Color.Transparent;
            flowLayoutPanel1.Controls[indexx].BackColor = Color.AliceBlue;
            lastindex = indexx;
            this.flowLayoutPanel2.Controls.Clear();
            String CType = myCrime[indexx].crimetype;
            if (myCrime[indexx].crime_status != "CLOSED")
                foreach (involvedPeople inv in li)
                {
                    bool ys = false;
                    int val = 0;
                    Suggestionparameters suggppl = new Suggestionparameters
                    {
                        area = false,
                        item = false,
                        address = false,
                        evidence = false,
                        motivation = false
                    };
                    for (int i = 0; i < inv.CrimeIDS.Count; i++)
                    {
                        int k = 0;
                        for (k = 0; k < myCrime.Count; k++)
                        {
                            if (myCrime[k].id == inv.CrimeIDS[i])
                            {
                                break;
                            }
                        }
                        if (k == myCrime.Count)
                            continue;
                        if (myCrime[k].crimetype == CType)
                        {
                            ys = true;
                            bool narea = false, nitem = false, naddress = false, nmotiv = false, nevid = false;
                            narea = (adjAddress(myCrime[k].crime_location) == adjAddress(myCrime[indexx].crime_location)) ? true : false;
                            naddress = (adjAddress(inv.address) == adjAddress(myCrime[indexx].crime_location)) ? true : false;
                            foreach (Item it in myCrime[indexx].items)
                            {
                                if (it.PersonID == inv.personalID)
                                {
                                    nitem = true;
                                    break;
                                }
                            }
                            for (int j = 0; j < myCrime[indexx].involved_people.Count; j++)
                            {
                                if (myCrime[indexx].involved_people[j] == inv.personalID && myCrime[indexx].Motivation[j])
                                {
                                    nmotiv = true;
                                    if (myCrime[indexx].Evidence[j]) nevid = true;
                                    narea = (adjAddress(myCrime[indexx].locacrime[j]) == adjAddress(myCrime[indexx].crime_location)) ? true : narea;
                                    break;
                                }
                                else if (myCrime[indexx].involved_people[j] == inv.personalID)
                                {
                                    if (myCrime[indexx].Evidence[j]) nevid = true;
                                    narea = (adjAddress(myCrime[indexx].locacrime[j]) == adjAddress(myCrime[indexx].crime_location)) ? true : narea;
                                    break;
                                }
                            }
                            suggppl.area |= narea;
                            suggppl.item |= nitem;
                            suggppl.address |= naddress;
                            suggppl.evidence |= nevid;
                            suggppl.motivation |= nmotiv;
                        }
                    }
                    if (ys)
                    {
                        added[inv.personalID] = true;
                        val = (suggppl.area) ? val + 1 : val;
                        val = (suggppl.address) ? val + 1 : val;
                        val = (suggppl.item) ? val + 3 : val;
                        val = (suggppl.motivation) ? val + 2 : val;
                        val = (suggppl.evidence) ? val + 2 : val;
                        suggestedcriminal.Add(new Tuple<involvedPeople, int, Suggestionparameters>(inv, val, suggppl));
                    }
                }
            for (int i = 0; i < myCrime[indexx].involved_people.Count; i++)
            {
                if (added.ContainsKey(myCrime[indexx].involved_people[i])) continue;
                int val = 0;
                Suggestionparameters suggppl = new Suggestionparameters
                {
                    area = false,
                    item = false,
                    address = false,
                    evidence = false,
                    motivation = false
                };
                //item
                for (int j = 0; j < myCrime[indexx].items.Count; j++)
                {
                    if (myCrime[indexx].involved_people[i] == myCrime[indexx].items[j].PersonID)
                    {
                        suggppl.item = true;
                        break;
                    }
                }
                //motiv
                if (myCrime[indexx].Motivation[i] == true) suggppl.motivation = true;
                //evid
                if (myCrime[indexx].Evidence[i] == true) suggppl.evidence = true;
                //loc
                if (adjAddress(myCrime[indexx].locacrime[i]) == adjAddress(myCrime[indexx].crime_location)) suggppl.area = true;
                //address
                int ind = 0;
                foreach (involvedPeople k in li)
                {
                    if (k.personalID == myCrime[indexx].involved_people[i])
                    {

                        if (k.address == myCrime[indexx].crime_location) suggppl.address = true;
                        break;
                    }
                    ind++;
                }
                //adding
                val = (suggppl.area) ? val + 1 : val;
                val = (suggppl.address) ? val + 1 : val;
                val = (suggppl.item) ? val + 3 : val;
                val = (suggppl.motivation) ? val + 2 : val;
                val = (suggppl.evidence) ? val + 2 : val;
                suggestedcriminal.Add(new Tuple<involvedPeople, int, Suggestionparameters>(li[ind], val, suggppl));
            }
            suggestedcriminal.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            for (int i = 0; i < suggestedcriminal.Count; i++)
            {
                bunifuCards11 = new BunifuCards();
                bunifuCards11 = new BunifuCards();
                BunifuCustomLabel bunifuCustomLabel131;
                BunifuRating bunifuRating11;
                PictureBox pictureBox51;
                BunifuCustomLabel bunifuCustomLabel71;
                BunifuCustomLabel bunifuCustomLabel81;
                BunifuCustomLabel bunifuCustomLabel91;
                BunifuCustomLabel bunifuCustomLabel101;
                BunifuCustomLabel bunifuCustomLabel111;
                BunifuCustomLabel bunifuCustomLabel121;
                BunifuCustomLabel bunifuCustomLabel151;
                BunifuCustomLabel bunifuCustomLabel161;
                Panel panel11;
                panel11 = new System.Windows.Forms.Panel();
                TextBox label41;
                BunifuCustomLabel bunifuCustomLabel141;
                flowLayoutPanel2.Visible = false;
                bunifuCustomLabel71 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel81 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel91 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel101 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel111 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel121 = new Bunifu.Framework.UI.BunifuCustomLabel();
                pictureBox51 = new System.Windows.Forms.PictureBox();
                bunifuRating11 = new Bunifu.Framework.UI.BunifuRating();
                bunifuCustomLabel131 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel141 = new Bunifu.Framework.UI.BunifuCustomLabel();
                label41 = new TextBox();
                bunifuCustomLabel151 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel161 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCards11.BackColor = System.Drawing.Color.White;
                bunifuCards11.BorderRadius = 5;
                bunifuCards11.BottomSahddow = true;
                bunifuCards11.color = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCards11.Controls.Add(bunifuCustomLabel151);
                bunifuCards11.Controls.Add(bunifuCustomLabel161);
                bunifuCards11.Controls.Add(label41);
                bunifuCards11.Controls.Add(bunifuCustomLabel141);
                bunifuCards11.Controls.Add(bunifuCustomLabel131);
                bunifuCards11.Controls.Add(pictureBox51);
                bunifuCards11.Controls.Add(bunifuCustomLabel71);
                bunifuCards11.Controls.Add(bunifuCustomLabel81);
                bunifuCards11.Controls.Add(bunifuCustomLabel91);
                bunifuCards11.Controls.Add(bunifuCustomLabel101);
                bunifuCards11.Controls.Add(bunifuCustomLabel111);
                bunifuCards11.Controls.Add(bunifuCustomLabel121);
                bunifuCards11.LeftSahddow = true;
                bunifuCards11.Location = new System.Drawing.Point(7, 10);
                bunifuCards11.Margin = new System.Windows.Forms.Padding(2, 5, 10, 5);
                bunifuCards11.Name = "bunifuCards11" + i.ToString();
                bunifuCards11.RightSahddow = true;
                bunifuCards11.ShadowDepth = 50;
                bunifuCards11.Size = new System.Drawing.Size(345, 440);
                bunifuCards11.TabIndex = 1;
                // 345,440
                // bunifuCustomLabel7

                bunifuCustomLabel71.AutoSize = true;
                bunifuCustomLabel71.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel71.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                  | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel71.Location = new System.Drawing.Point(170, 269);
                bunifuCustomLabel71.Name = "bunifuCustomLabel71" + i.ToString();
                bunifuCustomLabel71.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel71.TabIndex = 6;
                bunifuCustomLabel71.Text = adjAddress(suggestedcriminal[i].Item1.address);
                // 
                // bunifuCustomLabel8

                bunifuCustomLabel81.AutoSize = true;
                bunifuCustomLabel81.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel81.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel81.Location = new System.Drawing.Point(40, 269);
                bunifuCustomLabel81.Name = "bunifuCustomLabel81" + i.ToString();
                bunifuCustomLabel81.Size = new System.Drawing.Size(74, 19);
                bunifuCustomLabel81.TabIndex = 5;
                bunifuCustomLabel81.Text = "Living Area:";
                // 
                // bunifuCustomLabel9

                bunifuCustomLabel91.AutoSize = true;
                bunifuCustomLabel91.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel91.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                  | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel91.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel91.Location = new System.Drawing.Point(170, 241);
                bunifuCustomLabel91.Name = "bunifuCustomLabel91" + i.ToString();
                bunifuCustomLabel91.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel91.TabIndex = 4;
                bunifuCustomLabel91.Text = suggestedcriminal[i].Item1.name;
                // 
                // bunifuCustomLabel10
                // 
                bunifuCustomLabel101.AutoSize = true;
                bunifuCustomLabel101.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel101.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel101.Location = new System.Drawing.Point(40, 241);
                bunifuCustomLabel101.Name = "bunifuCustomLabel101" + i.ToString();
                bunifuCustomLabel101.Size = new System.Drawing.Size(62, 19);
                bunifuCustomLabel101.TabIndex = 3;
                bunifuCustomLabel101.Text = "Name:";
                // 
                // bunifuCustomLabel11

                bunifuCustomLabel111.AutoSize = true;
                bunifuCustomLabel111.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel111.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel111.Location = new System.Drawing.Point(170, 212);
                bunifuCustomLabel111.Name = "bunifuCustomLabel111" + i.ToString();
                bunifuCustomLabel111.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel111.TabIndex = 2;
                bunifuCustomLabel111.Text = suggestedcriminal[i].Item1.personalID;
                // 
                // bunifuCustomLabel12

                bunifuCustomLabel121.AutoSize = true;
                bunifuCustomLabel121.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel121.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel121.Location = new System.Drawing.Point(38, 212);
                bunifuCustomLabel121.Name = "bunifuCustomLabel121" + i.ToString();
                bunifuCustomLabel121.Size = new System.Drawing.Size(93, 19);
                bunifuCustomLabel121.TabIndex = 1;
                bunifuCustomLabel121.Text = "PersonalID:";
                // 
                // pictureBox5
                // 
                pictureBox51.BackColor = Color.Transparent;
                pictureBox51.Location = new System.Drawing.Point(75, 18);
                pictureBox51.Name = "pictureBox51" + i.ToString();
                pictureBox51.Size = new System.Drawing.Size(172, 122);
                pictureBox51.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox51.TabIndex = 7;
                pictureBox51.TabStop = false;
                try
                {
                    pictureBox51.Image = Image.FromFile(suggestedcriminal[i].Item1.imagePath);
                }
                catch
                {
                    pictureBox5.Image = Image.FromFile("nophoto.png");
                }
                // 
                // bunifuCustomLabel13
                // 
                bunifuCustomLabel131.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel131.Font = new System.Drawing.Font("Century Gothic", 20F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                 | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel131.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel131.Location = new System.Drawing.Point(75, 159);
                bunifuCustomLabel131.Name = "bunifuCustomLabel131" + i.ToString();
                bunifuCustomLabel131.Size = new System.Drawing.Size(172, 40);
                bunifuCustomLabel131.TabIndex = 9;
                bunifuCustomLabel131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                if (myCrime[indexx].crime_status == "CLOSED")
                    bunifuCustomLabel131.Text = "Criminal";
                else
                    bunifuCustomLabel131.Text = (suggestedcriminal[i].Item2 <= 3) ? "LOW" : (suggestedcriminal[i].Item2 <= 6) ? "Moderate" : "High";
                // 
                // bunifuCustomLabel14
                // 
                bunifuCustomLabel141.AutoSize = true;
                bunifuCustomLabel141.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel141.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel141.Location = new System.Drawing.Point(120, 334);
                bunifuCustomLabel141.Name = "bunifuCustomLabel141" + i.ToString();
                bunifuCustomLabel141.Size = new System.Drawing.Size(71, 19);
                bunifuCustomLabel141.TabIndex = 10;
                bunifuCustomLabel141.Text = "Reasons";
                // 
                // label4
                // 
                label41.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                bunifuTransition1.SetDecoration(label41, BunifuAnimatorNS.DecorationType.None);
                label41.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label41.Location = new System.Drawing.Point(11, 353);
                label41.Multiline = true;
                label41.Name = "label41" + i.ToString();
                label41.ReadOnly = true;
                label41.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                label41.Size = new System.Drawing.Size(323, 70);
                label41.TabIndex = 14;
                label41.Text = writereason(i);
                // 
                // bunifuCustomLabel15
                // 
                bunifuCustomLabel151.AutoSize = true;
                bunifuCustomLabel151.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel151.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                    | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel151.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel151.Location = new System.Drawing.Point(170, 299);
                bunifuCustomLabel151.Name = "bunifuCustomLabel151" + i.ToString();
                bunifuCustomLabel151.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel151.TabIndex = 13;
                bunifuCustomLabel151.Text = suggestedcriminal[i].Item1.nationality;
                // 
                // bunifuCustomLabel16
                // 
                bunifuCustomLabel161.AutoSize = true;
                bunifuCustomLabel161.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel161.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel161.Location = new System.Drawing.Point(40, 299);
                bunifuCustomLabel161.Name = "bunifuCustomLabel161" + i.ToString();
                bunifuCustomLabel161.Size = new System.Drawing.Size(92, 19);
                bunifuCustomLabel161.TabIndex = 12;
                bunifuCustomLabel161.Text = "Country:";
                // 
                flowLayoutPanel2.Controls.Add(bunifuCards11);
                //timer1.Enabled = true;
            }
            //  bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition();
            //
            bunifuTransition1.ShowSync(flowLayoutPanel2);
            // bunifuTransition1.
        }
        private string writereason(int idx)
        {
            var obj = suggestedcriminal[idx];
            string use = (obj.Item1.gender == "Male") ? "he" : "she", use2 = (obj.Item1.gender == "Male") ? "him" : "her", use3 = (obj.Item1.gender == "Male") ? "his" : "her";
            string items = (obj.Item3.item) ? "found item(s)" : "didn't find any item",
                   motive = (obj.Item3.motivation) ? "motive(s) to commit this crime" : "not any motive to commit this crime",
                   addss = (obj.Item3.address) ? "in the same area of the crime which is suspicious note" : "far away from the crime's area",
                   location = (obj.Item3.area) ? "this area is familier as may " + use + " been caught in this area before or " + use + " was in the crime area at this time" : "this area isn't familiar for " + use2 + " so far",
                   ev = (obj.Item3.evidence) ? "evidence(s) points to " + use2 : "not any evidence points to " + use2;
            string res = "Sir, This Suspect has been involved in crime(s) with the same type as Crime (" + myCrime[indexx].id.ToString() + "), " +
                "and as we searched in the crime location we " + items + " related to this suspect, " +
                "and there was/were " + ev + ", " +
                "and by checking " + use3 + " personal info we found that " + use + " is living " + addss + ", " +
                "however when we enquired " + use2 + " it has been revealed that " + use + " has " + motive + ", " +
                 use + " admitted that " + location + ".";
            return res;
        }
        private void addcrimes()
        {
            flowLayoutPanel1.Controls.Clear();
            int i = 0;
            foreach (Crime c in myCrime)
            {
                BunifuCards gd = new BunifuCards();
                BunifuCustomLabel bunifuCustomLabel61;
                BunifuCustomLabel bunifuCustomLabel51;
                BunifuCustomLabel bunifuCustomLabel41;
                BunifuCustomLabel bunifuCustomLabel31;
                BunifuCustomLabel bunifuCustomLabel21;
                BunifuCustomLabel bunifuCustomLabel11;
                BunifuCustomLabel bunifuCustomLabel171;
                BunifuCustomLabel bunifuCustomLabel181;
                bunifuCustomLabel171 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel181 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel21 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel31 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel41 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel51 = new Bunifu.Framework.UI.BunifuCustomLabel();
                bunifuCustomLabel61 = new Bunifu.Framework.UI.BunifuCustomLabel();
                // bunifuCustomLabel17
                // 
                bunifuCustomLabel171.AutoSize = true;
                bunifuCustomLabel171.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel171.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                    | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel171.ForeColor = (c.crime_status == "OPENED") ? Color.DarkGreen : Color.DarkRed;
                bunifuCustomLabel171.Location = new System.Drawing.Point(128, 109);
                bunifuCustomLabel171.Name = "bunifuCustomLabel171" + i.ToString();
                bunifuCustomLabel171.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel171.TabIndex = 8;
                bunifuCustomLabel171.Text = (c.crime_status == "OPENED") ? "Open" : "Closed";
                // 
                // bunifuCustomLabel18
                // 
                bunifuCustomLabel181.AutoSize = true;
                bunifuCustomLabel181.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel181.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel181.Location = new System.Drawing.Point(4, 109);
                bunifuCustomLabel181.Name = "bunifuCustomLabel181" + i.ToString();
                bunifuCustomLabel181.Size = new System.Drawing.Size(79, 19);
                bunifuCustomLabel181.TabIndex = 7;
                bunifuCustomLabel181.Text = "Crime Status:";
                // bunifuCustomLabel11
                // 
                bunifuCustomLabel11.AutoSize = true;
                bunifuCustomLabel11.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel11.Location = new System.Drawing.Point(4, 17);
                bunifuCustomLabel11.Name = "bunifuCustomLabel11" + i.ToString();
                bunifuCustomLabel11.Size = new System.Drawing.Size(79, 19);
                bunifuCustomLabel11.TabIndex = 1;
                bunifuCustomLabel11.Text = "Crime ID:";
                // 
                // bunifuCustomLabel21
                // 
                bunifuCustomLabel21.AutoSize = true;
                bunifuCustomLabel21.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel21.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                    | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel21.Location = new System.Drawing.Point(128, 17);
                bunifuCustomLabel21.Name = "bunifuCustomLabel21" + i.ToString();
                bunifuCustomLabel21.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel21.TabIndex = 2;
                bunifuCustomLabel21.Text = c.id.ToString();
                // 
                // bunifuCustomLabel31
                // 
                bunifuCustomLabel31.AutoSize = true;
                bunifuCustomLabel31.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel31.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel31.Location = new System.Drawing.Point(4, 50);
                bunifuCustomLabel31.Name = "bunifuCustomLabel31" + i.ToString();
                bunifuCustomLabel31.Size = new System.Drawing.Size(79, 19);
                bunifuCustomLabel31.TabIndex = 3;
                bunifuCustomLabel31.Text = "Crime Type:";
                // 
                // bunifuCustomLabel41
                // 
                bunifuCustomLabel41.AutoSize = true;
                bunifuCustomLabel41.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel41.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                   | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel41.Location = new System.Drawing.Point(128, 50);
                bunifuCustomLabel41.Name = "bunifuCustomLabel41" + i.ToString();
                bunifuCustomLabel41.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel41.TabIndex = 4;
                bunifuCustomLabel41.Text = c.crimetype;
                // 
                // bunifuCustomLabel51
                // 
                bunifuCustomLabel51.AutoSize = true;
                bunifuCustomLabel51.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel51.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel51.Location = new System.Drawing.Point(4, 80);
                bunifuCustomLabel51.Name = "bunifuCustomLabel51" + i.ToString();
                bunifuCustomLabel51.Size = new System.Drawing.Size(79, 19);
                bunifuCustomLabel51.TabIndex = 5;
                bunifuCustomLabel51.Text = "Crime Area:";
                // 
                // bunifuCustomLabel61
                // 
                bunifuCustomLabel61.AutoSize = true;
                bunifuCustomLabel61.BackColor = System.Drawing.Color.Transparent;
                bunifuCustomLabel61.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                 | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuCustomLabel61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                bunifuCustomLabel61.Location = new System.Drawing.Point(128, 80);
                bunifuCustomLabel61.Name = "bunifuCustomLabel61" + i.ToString();
                bunifuCustomLabel61.Size = new System.Drawing.Size(79, 21);
                bunifuCustomLabel61.TabIndex = 6;
                bunifuCustomLabel61.Text = adjAddress(c.crime_location);
                gd.BackColor = System.Drawing.Color.White;
                gd.BorderRadius = 5;
                gd.BottomSahddow = true;
                gd.color = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                gd.Controls.Add(bunifuCustomLabel61);
                gd.Controls.Add(bunifuCustomLabel51);
                gd.Controls.Add(bunifuCustomLabel41);
                gd.Controls.Add(bunifuCustomLabel31);
                gd.Controls.Add(bunifuCustomLabel21);
                gd.Controls.Add(bunifuCustomLabel11);
                gd.Controls.Add(bunifuCustomLabel171);
                gd.Controls.Add(bunifuCustomLabel181);
                gd.LeftSahddow = true;
                gd.Location = new System.Drawing.Point(7, 10);
                gd.Margin = new System.Windows.Forms.Padding(2, 5, 10, 5);
                gd.Name = "visiblecard" + i.ToString();
                gd.RightSahddow = true;
                gd.ShadowDepth = 50;
                gd.Size = new System.Drawing.Size(294, 138);
                gd.TabIndex = 1;
                gd.Cursor = System.Windows.Forms.Cursors.Hand;
                toolTip1.SetToolTip(gd, "Select to see suggested suspects for this Crime ID.");
                gd.Click += new System.EventHandler(this.bunifuCards6_Click);
                flowLayoutPanel1.Controls.Add(gd);
                i++;
            }
        }
        private void inNatCBox_TextChanged(object sender, EventArgs e)
        {
            if (inNatCBox.Text == "Egypt")
            {
                inMSRB1.Enabled = true;
                inMSRB2.Enabled = true;
                inMSRB3.Enabled = true;
                inMSRB4.Enabled = false;
                inMSRB4.Checked = false;
            }
            else
            {
                inMSRB1.Enabled = false;
                inMSRB2.Enabled = false;
                inMSRB3.Enabled = false;
                inMSRB4.Enabled = true;
                inMSRB4.Checked = true;
            }
        }
        private void inNatCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (inNatCBox.Text == "Egypt")
            {
                inMSRB1.Enabled = true;
                inMSRB2.Enabled = true;
                inMSRB3.Enabled = true;
                inMSRB4.Enabled = false;
                inMSRB4.Checked = false;
            }
            else
            {
                inMSRB1.Enabled = false;
                inMSRB2.Enabled = false;
                inMSRB3.Enabled = false;
                inMSRB4.Enabled = true;
                inMSRB4.Checked = true;
            }
        }
        private void inAddressBtn_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
                a.FormClosing += f_ClosingInvolved;
            }
            else
                messageBoxOK.Show("OOPS! You're offline please add the address manually!");
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
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (itemdescription.Text == "")
            {
                itemdescription.Text = "ITEM DESCRIPTION";
                itemdescription.ForeColor = Color.LightGray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (itemdescription.Text == "ITEM DESCRIPTION")
            {
                itemdescription.Clear();
                itemdescription.ForeColor = Color.Black;
            }
        }
        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (location.Text == "Location")
            {
                location.Clear();
                location.ForeColor = Color.Black;
            }
        }
        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (location.Text == "")
            {
                location.Text = "Location";
                location.ForeColor = Color.LightGray;
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["logOut"])
                this.Close();
            if (tabControl1.SelectedTab == tabControl1.TabPages["invPeople"])
                clearInvolv();
            if (tabControl1.SelectedTab == tabControl1.TabPages["regForm"])
                regClear();
            if (tabControl1.SelectedTab == tabControl1.TabPages["systemSuggestion"])
            {
                addcrimes();
                flowLayoutPanel2.Controls.Clear();
                indexx = 0;
                lastindex = 0;
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
                a.FormClosing += f_ClosingCrime;
            }
            else
                messageBoxOK.Show("OOPS! You're offline please add the address manually!");
        }
        private void f_Closing(object sender, FormClosingEventArgs e)
        {
            address.Text = MapAddress.frmMapIt.s;
            this.Show();
        }
        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clear_MouseEnter(object sender, EventArgs e)
        {
            clear.BackColor = Color.DarkRed;
        }
        private void clear_MouseLeave(object sender, EventArgs e)
        {
            clear.BackColor = _color;
        }
        private void clear_Click(object sender, EventArgs e)
        {
            if (ourMessageBox.Show("Are you sure about want to Clear new entered data?") == DialogResult.No)
                return;
            clearInvolv();
        }
        private void addInvolvedBtn_MouseEnter(object sender, EventArgs e)
        {
            addInvolvedBtn.BackColor = Color.DarkGreen;
        }
        private void addInvolvedBtn_MouseLeave(object sender, EventArgs e)
        {
            addInvolvedBtn.BackColor = _color;
        }
        private void clear2_MouseEnter(object sender, EventArgs e)
        {
            clear2.BackColor = Color.DarkRed;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = _color;
        }
        private void clear2_MouseLeave(object sender, EventArgs e)
        {
            clear2.BackColor = _color;
        }
        private void clear2_Click(object sender, EventArgs e)
        {
            if (ourMessageBox.Show("Are you sure about want to Clear new entered data?") == DialogResult.No)
                return;
            regClear();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkGreen;
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                MapAddress.frmMapIt a = new MapAddress.frmMapIt();
                a.Show();
                a.FormClosing += f_Closing;
            }
            else
                messageBoxOK.Show("OOPS! You're offline please add the address manually!");
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search here")
            {
                searchTextBox.Clear();
                searchTextBox.ForeColor = Color.Black;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (x == sz - 1)
                x = 0;
            else
                x++;
            try
            {
                crimeimg.Image = imageList1.Images[x];
            }
            catch
            {
                x = 0;
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkRed;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(38, 50, 56);
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(38, 50, 56);
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.Green;
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(38, 50, 56);
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            involvedDelete.BackColor = Color.DarkRed;
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            involvedDelete.BackColor = Color.FromArgb(38, 50, 56);
        }
        private string placeFileinDebug(string fileToCopy)
        {
            string newCopy = "";
            for (int i = 0; i < fileToCopy.Length; i++)
            {
                newCopy += fileToCopy[i];
                if (fileToCopy[i] == '\\')
                    newCopy = "";
            }
            if (System.IO.File.Exists(fileToCopy) && !System.IO.File.Exists(newCopy))
            {
                System.IO.File.Copy(fileToCopy, newCopy);
                messageBoxOK.Show(newCopy);
            }
            return newCopy;
        }

        private void peopleinv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void officerid_TextChanged(object sender, EventArgs e)
        {
            if (eshta && check_id_off(officerid.Text)>=0)
            {
                ss = officerid.Text;
                if (updrdio.Checked)
                {
                    try
                    {
                        deser();
                        ofliss = oflis;
                        ofliss[check_id_off(off_id)].crimID.Remove(crimeid.Text);
                        ofliss[check_id_off(officerid.Text)].crimID.Add(crimeid.Text);
                        offinf();

                    }
                    catch
                    {


                    }
                }
                else if (addrdio.Checked)
                {
                    deser();
                    ofliss = oflis;
                    messageBoxOK.Show(ofliss[check_id_off(officerid.Text)].crimID.Count.ToString());
                    ofliss[check_id_off(officerid.Text)].crimID.Add(mshhanst3mloabdn.ToString());

                    offinf();
                }
                eshta = false;
                officerid.Text = ss;
                eshta = true;
            }
        }
    }
}
