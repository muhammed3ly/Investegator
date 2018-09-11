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
    public partial class AddCrimeType : Form
    {
        List<Crimetype> ctList = new List<Crimetype>();
        int crimeTypeNum = 1;
        string tempName;
        public AddCrimeType()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
        }
        private void AddCrimeType_Load(object sender, EventArgs e)
        {
            CrimeTypeDeser();
            fillGrid();
            CrimeTypeGrid.Columns[0].Width = 125;
            crimeTypeNum = ctList.Count;
            CrimeTypeEditBtn.Enabled = false;
            CrimeTypeDeleteBtn.Enabled = false;
        }
        private void CrimeTypeSer()
        {
            XmlSerializer xmser = new XmlSerializer(typeof(List<Crimetype>));
            FileStream fs;
            try
            {
                fs = new FileStream("CrimeType.xml", FileMode.Truncate);
            }
            catch
            {
                fs = new FileStream("CrimeType.xml", FileMode.OpenOrCreate);
            }
            xmser.Serialize(fs, ctList);
            fs.Close();
        }
        private void CrimeTypeDeser()
        {
            try
            {
                XmlSerializer xmser = new XmlSerializer(typeof(List<Crimetype>));
                FileStream fs = new FileStream("CrimeType.xml", FileMode.OpenOrCreate);
                ctList = xmser.Deserialize(fs) as List<Crimetype>;
                fs.Close();
            }
            catch { }
        }
        private bool checkType(string s)
        {
            foreach (Crimetype ct in ctList)
                if (ct.typename == s)
                    return true;
            return false;
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            CrimeTypeDeser();
            if (crimeTypeNameTB.Text == "" || CrimeTypeDesTB.Text == "")
            {
                messageBoxOK.Show("Enter the required fields");
                return;
            }
            if (checkType(crimeTypeNameTB.Text))
            {
                messageBoxOK.Show("This type already exists!");
                return;
            }
            for (int i = 0; i < ctList.Count; i++)
                if (ctList[i].typename.ToLower() == crimeTypeNameTB.Text.ToLower())
                {
                    messageBoxOK.Show("Type already exists");
                    return;
                }
            ctList.Add(new Crimetype(++crimeTypeNum, crimeTypeNameTB.Text, CrimeTypeDesTB.Text));
            messageBoxOK.Show("type added successfully");
            CrimeTypeSer();
            fillGrid();
            crimeTypeNameTB.Text = "";
            CrimeTypeDesTB.Text = "";
        }
        private void fillGrid()
        {
            CrimeTypeDeser();
            CrimeTypeGrid.Rows.Clear();
            for (int i = 0; i < ctList.Count; i++)
                CrimeTypeGrid.Rows.Add(ctList[i].typename, ctList[i].description);
        }
        private void CrimeTypeEditBtn_Click(object sender, EventArgs e)
        {
            CrimeTypeDeser();
            int i = CrimeTypeGrid.SelectedCells[0].RowIndex;
            if (checkType(crimeTypeNameTB.Text) && tempName != crimeTypeNameTB.Text)
            {
                messageBoxOK.Show("This type already exists!");
                return;
            }
            ctList[i].typename = crimeTypeNameTB.Text;
            ctList[i].description = CrimeTypeDesTB.Text;
            CrimeTypeSer();
            fillGrid();
            crimeTypeNameTB.Text = CrimeTypeDesTB.Text = "";
            CrimeTypeEditBtn.Enabled = false;
            CrimeTypeDeleteBtn.Enabled = false;
            crimeTypeAddBtn.Enabled = true;
            enableAdd.Visible = false;
            enableAdd.Enabled = false;
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            CrimeTypeDeser();
            int i = CrimeTypeGrid.SelectedCells[0].RowIndex;
            ctList.RemoveAt(i);
            CrimeTypeSer();
            fillGrid();
            crimeTypeNameTB.Text = CrimeTypeDesTB.Text = "";
            CrimeTypeEditBtn.Enabled = false;
            CrimeTypeDeleteBtn.Enabled = false;
            crimeTypeAddBtn.Enabled = true;
            enableAdd.Visible = false;
            enableAdd.Enabled = false;
        }

        private void CrimeTypeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = CrimeTypeGrid.SelectedCells[0].RowIndex;
            CrimeTypeDesTB.Text = CrimeTypeGrid.Rows[i].Cells[1].Value.ToString();
            crimeTypeNameTB.Text = CrimeTypeGrid.Rows[i].Cells[0].Value.ToString();
            tempName = crimeTypeNameTB.Text;
            CrimeTypeEditBtn.Enabled = true;
            CrimeTypeDeleteBtn.Enabled = true;
            crimeTypeAddBtn.Enabled = false;
            enableAdd.Visible = true;
            enableAdd.Enabled = true;
        }

        private void enableAdd_Click(object sender, EventArgs e)
        {
            crimeTypeAddBtn.Enabled = true;
            CrimeTypeDeleteBtn.Enabled = false;
            CrimeTypeEditBtn.Enabled = false;
            enableAdd.Visible = false;
            enableAdd.Enabled = false;
            crimeTypeNameTB.Clear();
            CrimeTypeDesTB.Clear();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
