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


        /// <summary>
        /// Map by street address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapIt_Click(object sender, EventArgs e)
        {
            try
            {
                string street = string.Empty;
                string city = string.Empty;
                string state = string.Empty;
                string zip = string.Empty;

                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");

                if (txtStreet.Text != string.Empty)
                {
                    street = txtStreet.Text.Replace(' ', '+');
                    queryAddress.Append(street + ',' + '+');
                }

                if (txtCity.Text != string.Empty)
                {
                    city = txtCity.Text.Replace(' ', '+');
                    queryAddress.Append(city + ',' + '+');
                }

                if (txtState.Text != string.Empty)
                {
                    state = txtState.Text.Replace(' ', '+');
                    queryAddress.Append(state + ',' + '+');
                }

                if (txtZipCode.Text != string.Empty)
                {
                    zip = txtZipCode.Text.ToString();
                    queryAddress.Append(zip);
                }

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }

        }


        /// <summary>
        /// Map by latitude and longitude
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMapLatLong_Click(object sender, EventArgs e)
        {
            if (txtLat.Text == string.Empty || txtLong.Text == string.Empty)
            {
                MessageBox.Show("Supply a latitude and longitude value", "Missing Data");
                return;
            }

            try
            {
                string lat = string.Empty;
                string lon = string.Empty;

                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");

                if (txtLat.Text != string.Empty)
                {
                    lat = txtLat.Text;
                    queryAddress.Append(lat + "%2C");
                }

                if (txtLong.Text != string.Empty)
                {
                    lon = txtLong.Text;
                    queryAddress.Append(lon);
                }

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }
    }
}