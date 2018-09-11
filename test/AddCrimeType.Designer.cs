namespace test
{
    partial class AddCrimeType
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCrimeType));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crimeTypeNameTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CrimeTypeDesTB = new System.Windows.Forms.TextBox();
            this.CrimeTypeGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.crimeTypeAddBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.CrimeTypeEditBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.CrimeTypeDeleteBtn = new Bunifu.Framework.UI.BunifuImageButton();
            this.enableAdd = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton9 = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel19 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crimeTypeAddBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeEditBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeDeleteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crimeTypeNameTB);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crime Type Name";
            // 
            // crimeTypeNameTB
            // 
            this.crimeTypeNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crimeTypeNameTB.Location = new System.Drawing.Point(6, 45);
            this.crimeTypeNameTB.Name = "crimeTypeNameTB";
            this.crimeTypeNameTB.Size = new System.Drawing.Size(221, 31);
            this.crimeTypeNameTB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CrimeTypeDesTB);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(254, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // CrimeTypeDesTB
            // 
            this.CrimeTypeDesTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrimeTypeDesTB.Location = new System.Drawing.Point(3, 27);
            this.CrimeTypeDesTB.Multiline = true;
            this.CrimeTypeDesTB.Name = "CrimeTypeDesTB";
            this.CrimeTypeDesTB.Size = new System.Drawing.Size(247, 70);
            this.CrimeTypeDesTB.TabIndex = 1;
            this.CrimeTypeDesTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CrimeTypeGrid
            // 
            this.CrimeTypeGrid.AllowUserToAddRows = false;
            this.CrimeTypeGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CrimeTypeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CrimeTypeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrimeTypeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CrimeTypeGrid.BackgroundColor = System.Drawing.Color.White;
            this.CrimeTypeGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CrimeTypeGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CrimeTypeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CrimeTypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CrimeTypeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.CrimeTypeGrid.DoubleBuffered = true;
            this.CrimeTypeGrid.EnableHeadersVisualStyles = false;
            this.CrimeTypeGrid.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.CrimeTypeGrid.HeaderForeColor = System.Drawing.Color.White;
            this.CrimeTypeGrid.Location = new System.Drawing.Point(12, 157);
            this.CrimeTypeGrid.Name = "CrimeTypeGrid";
            this.CrimeTypeGrid.ReadOnly = true;
            this.CrimeTypeGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.CrimeTypeGrid.Size = new System.Drawing.Size(564, 226);
            this.CrimeTypeGrid.TabIndex = 2;
            this.CrimeTypeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CrimeTypeGrid_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Crime Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Crime Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.CrimeTypeGrid;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.bunifuCustomLabel19);
            this.panel1.Controls.Add(this.bunifuImageButton9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 35);
            this.panel1.TabIndex = 3;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // crimeTypeAddBtn
            // 
            this.crimeTypeAddBtn.BackColor = System.Drawing.Color.Transparent;
            this.crimeTypeAddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crimeTypeAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("crimeTypeAddBtn.Image")));
            this.crimeTypeAddBtn.ImageActive = null;
            this.crimeTypeAddBtn.Location = new System.Drawing.Point(513, 51);
            this.crimeTypeAddBtn.Name = "crimeTypeAddBtn";
            this.crimeTypeAddBtn.Size = new System.Drawing.Size(71, 29);
            this.crimeTypeAddBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.crimeTypeAddBtn.TabIndex = 4;
            this.crimeTypeAddBtn.TabStop = false;
            this.crimeTypeAddBtn.Zoom = 10;
            this.crimeTypeAddBtn.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // CrimeTypeEditBtn
            // 
            this.CrimeTypeEditBtn.BackColor = System.Drawing.Color.Transparent;
            this.CrimeTypeEditBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrimeTypeEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("CrimeTypeEditBtn.Image")));
            this.CrimeTypeEditBtn.ImageActive = null;
            this.CrimeTypeEditBtn.Location = new System.Drawing.Point(513, 81);
            this.CrimeTypeEditBtn.Name = "CrimeTypeEditBtn";
            this.CrimeTypeEditBtn.Size = new System.Drawing.Size(71, 29);
            this.CrimeTypeEditBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CrimeTypeEditBtn.TabIndex = 5;
            this.CrimeTypeEditBtn.TabStop = false;
            this.CrimeTypeEditBtn.Zoom = 10;
            this.CrimeTypeEditBtn.Click += new System.EventHandler(this.CrimeTypeEditBtn_Click);
            // 
            // CrimeTypeDeleteBtn
            // 
            this.CrimeTypeDeleteBtn.BackColor = System.Drawing.Color.Transparent;
            this.CrimeTypeDeleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrimeTypeDeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("CrimeTypeDeleteBtn.Image")));
            this.CrimeTypeDeleteBtn.ImageActive = null;
            this.CrimeTypeDeleteBtn.Location = new System.Drawing.Point(513, 112);
            this.CrimeTypeDeleteBtn.Name = "CrimeTypeDeleteBtn";
            this.CrimeTypeDeleteBtn.Size = new System.Drawing.Size(71, 29);
            this.CrimeTypeDeleteBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CrimeTypeDeleteBtn.TabIndex = 6;
            this.CrimeTypeDeleteBtn.TabStop = false;
            this.CrimeTypeDeleteBtn.Zoom = 10;
            this.CrimeTypeDeleteBtn.Click += new System.EventHandler(this.bunifuImageButton3_Click);
            // 
            // enableAdd
            // 
            this.enableAdd.BackColor = System.Drawing.Color.Transparent;
            this.enableAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableAdd.Enabled = false;
            this.enableAdd.Image = ((System.Drawing.Image)(resources.GetObject("enableAdd.Image")));
            this.enableAdd.ImageActive = null;
            this.enableAdd.Location = new System.Drawing.Point(564, 136);
            this.enableAdd.Name = "enableAdd";
            this.enableAdd.Size = new System.Drawing.Size(20, 22);
            this.enableAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enableAdd.TabIndex = 7;
            this.enableAdd.TabStop = false;
            this.enableAdd.Visible = false;
            this.enableAdd.Zoom = 10;
            this.enableAdd.Click += new System.EventHandler(this.enableAdd_Click);
            // 
            // bunifuImageButton9
            // 
            this.bunifuImageButton9.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton9.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton9.Image")));
            this.bunifuImageButton9.ImageActive = null;
            this.bunifuImageButton9.Location = new System.Drawing.Point(539, 3);
            this.bunifuImageButton9.Name = "bunifuImageButton9";
            this.bunifuImageButton9.Size = new System.Drawing.Size(37, 29);
            this.bunifuImageButton9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton9.TabIndex = 7;
            this.bunifuImageButton9.TabStop = false;
            this.bunifuImageButton9.Zoom = 15;
            this.bunifuImageButton9.Click += new System.EventHandler(this.bunifuImageButton9_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(10, 8);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 19);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 9;
            this.pictureBox8.TabStop = false;
            // 
            // bunifuCustomLabel19
            // 
            this.bunifuCustomLabel19.AutoSize = true;
            this.bunifuCustomLabel19.Font = new System.Drawing.Font("Century Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel19.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel19.Location = new System.Drawing.Point(45, 9);
            this.bunifuCustomLabel19.Name = "bunifuCustomLabel19";
            this.bunifuCustomLabel19.Size = new System.Drawing.Size(105, 17);
            this.bunifuCustomLabel19.TabIndex = 8;
            this.bunifuCustomLabel19.Text = "INVESTIGATOR";
            // 
            // AddCrimeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CrimeTypeEditBtn);
            this.Controls.Add(this.crimeTypeAddBtn);
            this.Controls.Add(this.CrimeTypeGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.enableAdd);
            this.Controls.Add(this.CrimeTypeDeleteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCrimeType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCrimeType";
            this.Load += new System.EventHandler(this.AddCrimeType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crimeTypeAddBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeEditBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrimeTypeDeleteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox crimeTypeNameTB;
        private System.Windows.Forms.TextBox CrimeTypeDesTB;
        private Bunifu.Framework.UI.BunifuCustomDataGrid CrimeTypeGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuImageButton crimeTypeAddBtn;
        private Bunifu.Framework.UI.BunifuImageButton CrimeTypeDeleteBtn;
        private Bunifu.Framework.UI.BunifuImageButton CrimeTypeEditBtn;
        private Bunifu.Framework.UI.BunifuImageButton enableAdd;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel19;
    }
}