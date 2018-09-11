namespace test
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.loguser = new System.Windows.Forms.TextBox();
            this.logpass = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loguser
            // 
            this.loguser.Font = new System.Drawing.Font("Tahoma", 12F);
            this.loguser.Location = new System.Drawing.Point(119, 255);
            this.loguser.Name = "loguser";
            this.loguser.Size = new System.Drawing.Size(300, 27);
            this.loguser.TabIndex = 0;
            this.loguser.Enter += new System.EventHandler(this.loginName_Enter);
            this.loguser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loguser_KeyPress);
            this.loguser.Leave += new System.EventHandler(this.loginName_Leave);
            // 
            // logpass
            // 
            this.logpass.Font = new System.Drawing.Font("Tahoma", 12F);
            this.logpass.Location = new System.Drawing.Point(119, 295);
            this.logpass.Name = "logpass";
            this.logpass.PasswordChar = '*';
            this.logpass.Size = new System.Drawing.Size(300, 27);
            this.logpass.TabIndex = 1;
            this.logpass.Enter += new System.EventHandler(this.loginPassword_Enter);
            this.logpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logpass_KeyDown);
            this.logpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logpass_KeyPress);
            this.logpass.Leave += new System.EventHandler(this.loginPassword_Leave);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(233, 338);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(119, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 258);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 396);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.logpass);
            this.Controls.Add(this.loguser);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logpass;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox loguser;
    }
}