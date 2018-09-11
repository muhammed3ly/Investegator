namespace test
{
    partial class ourMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ourMessageBox));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel19 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnYES = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.bunifuCustomLabel19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 37);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(6, 8);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 19);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // bunifuCustomLabel19
            // 
            this.bunifuCustomLabel19.AutoSize = true;
            this.bunifuCustomLabel19.Font = new System.Drawing.Font("Century Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel19.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel19.Location = new System.Drawing.Point(41, 9);
            this.bunifuCustomLabel19.Name = "bunifuCustomLabel19";
            this.bunifuCustomLabel19.Size = new System.Drawing.Size(105, 17);
            this.bunifuCustomLabel19.TabIndex = 6;
            this.bunifuCustomLabel19.Text = "INVESTIGATOR";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.556675F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.44332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.message, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.94118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.05882F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 170);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.9661F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.0339F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Controls.Add(this.btnYES, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNo, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(33, 117);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(361, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnYES
            // 
            this.btnYES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnYES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYES.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnYES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYES.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnYES.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnYES.Location = new System.Drawing.Point(45, 0);
            this.btnYES.Margin = new System.Windows.Forms.Padding(0);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(117, 43);
            this.btnYES.TabIndex = 1;
            this.btnYES.Text = "YES";
            this.btnYES.UseVisualStyleBackColor = false;
            this.btnYES.Click += new System.EventHandler(this.button1_Click);
            this.btnYES.MouseEnter += new System.EventHandler(this.btnYES_MouseEnter);
            this.btnYES.MouseLeave += new System.EventHandler(this.btnYES_MouseLeave);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnNo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNo.Location = new System.Drawing.Point(203, 0);
            this.btnNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(125, 43);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.button2_Click);
            this.btnNo.MouseEnter += new System.EventHandler(this.btnNo_MouseEnter);
            this.btnNo.MouseLeave += new System.EventHandler(this.btnNo_MouseLeave);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.message.Location = new System.Drawing.Point(55, 25);
            this.message.Margin = new System.Windows.Forms.Padding(25);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(317, 57);
            this.message.TabIndex = 1;
            this.message.Text = "label1";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ourMessageBox
            // 
            this.AcceptButton = this.btnYES;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(427, 207);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ourMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ourMessageBox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel19;
        private System.Windows.Forms.Button btnYES;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label message;
    }
}