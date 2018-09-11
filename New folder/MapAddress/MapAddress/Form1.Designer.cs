namespace MapAddress
{
    partial class frmMapIt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapIt));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnMapIt = new System.Windows.Forms.Button();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMapLatLong = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer1.Panel1.Controls.Add(this.btnMapLatLong);
            this.splitContainer1.Panel1.Controls.Add(this.txtLong);
            this.splitContainer1.Panel1.Controls.Add(this.txtLat);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnMapIt);
            this.splitContainer1.Panel1.Controls.Add(this.txtZipCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtState);
            this.splitContainer1.Panel1.Controls.Add(this.txtCity);
            this.splitContainer1.Panel1.Controls.Add(this.txtStreet);
            this.splitContainer1.Panel1.Controls.Add(this.lblZip);
            this.splitContainer1.Panel1.Controls.Add(this.lblState);
            this.splitContainer1.Panel1.Controls.Add(this.lblCity);
            this.splitContainer1.Panel1.Controls.Add(this.lblStreet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(746, 534);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnMapIt
            // 
            this.btnMapIt.Location = new System.Drawing.Point(216, 87);
            this.btnMapIt.Name = "btnMapIt";
            this.btnMapIt.Size = new System.Drawing.Size(100, 23);
            this.btnMapIt.TabIndex = 8;
            this.btnMapIt.Text = "Map Address";
            this.btnMapIt.UseVisualStyleBackColor = true;
            this.btnMapIt.Click += new System.EventHandler(this.btnMapIt_Click);
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(81, 89);
            this.txtZipCode.MaxLength = 5;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(87, 20);
            this.txtZipCode.TabIndex = 7;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(80, 63);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(39, 20);
            this.txtState.TabIndex = 6;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(81, 37);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(235, 20);
            this.txtCity.TabIndex = 5;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(81, 11);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(235, 20);
            this.txtStreet.TabIndex = 4;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(29, 92);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(50, 13);
            this.lblZip.TabIndex = 3;
            this.lblZip.Text = "Zip Code";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(46, 66);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "State";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(55, 40);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 1;
            this.lblCity.Text = "City";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(44, 14);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(35, 13);
            this.lblStreet.TabIndex = 0;
            this.lblStreet.Text = "Street";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(746, 408);
            this.webBrowser1.TabIndex = 1;
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(417, 37);
            this.txtLong.MaxLength = 50;
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(235, 20);
            this.txtLong.TabIndex = 12;
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(417, 11);
            this.txtLat.MaxLength = 100;
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(235, 20);
            this.txtLat.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Long";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lat";
            // 
            // btnMapLatLong
            // 
            this.btnMapLatLong.Location = new System.Drawing.Point(552, 86);
            this.btnMapLatLong.Name = "btnMapLatLong";
            this.btnMapLatLong.Size = new System.Drawing.Size(100, 23);
            this.btnMapLatLong.TabIndex = 13;
            this.btnMapLatLong.Text = "Map Lat/Long";
            this.btnMapLatLong.UseVisualStyleBackColor = true;
            this.btnMapLatLong.Click += new System.EventHandler(this.btnMapLatLong_Click);
            // 
            // frmMapIt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 534);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapIt";
            this.Text = "Map a Quick Address";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Button btnMapIt;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnMapLatLong;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

