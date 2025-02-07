namespace GourmetShop.LoginForm
{
    partial class frmLogin
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
            this.lblCustUserName = new System.Windows.Forms.Label();
            this.lblCustPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblReturningCustomers = new System.Windows.Forms.Label();
            this.lblNewCustomer = new System.Windows.Forms.Label();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustUserName
            // 
            this.lblCustUserName.AutoSize = true;
            this.lblCustUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustUserName.Location = new System.Drawing.Point(105, 50);
            this.lblCustUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustUserName.Name = "lblCustUserName";
            this.lblCustUserName.Size = new System.Drawing.Size(87, 20);
            this.lblCustUserName.TabIndex = 0;
            this.lblCustUserName.Text = "Username:";
            // 
            // lblCustPassword
            // 
            this.lblCustPassword.AutoSize = true;
            this.lblCustPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPassword.Location = new System.Drawing.Point(105, 106);
            this.lblCustPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustPassword.Name = "lblCustPassword";
            this.lblCustPassword.Size = new System.Drawing.Size(82, 20);
            this.lblCustPassword.TabIndex = 1;
            this.lblCustPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(209, 53);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(212, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtCustUserName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(209, 106);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(212, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtCustPassword_TextChanged);
            // 
            // lblReturningCustomers
            // 
            this.lblReturningCustomers.AutoSize = true;
            this.lblReturningCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturningCustomers.Location = new System.Drawing.Point(243, 18);
            this.lblReturningCustomers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturningCustomers.Name = "lblReturningCustomers";
            this.lblReturningCustomers.Size = new System.Drawing.Size(125, 20);
            this.lblReturningCustomers.TabIndex = 5;
            this.lblReturningCustomers.Text = "Returning Users";
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.Location = new System.Drawing.Point(9, 212);
            this.lblNewCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(262, 20);
            this.lblNewCustomer.TabIndex = 6;
            this.lblNewCustomer.Text = "Need an account? Create one here:";
            // 
            // btnNewUser
            // 
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(269, 207);
            this.btnNewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(152, 30);
            this.btnNewUser.TabIndex = 7;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // picPassword
            // 
            this.picPassword.Image = global::GourmetShop.LoginForm.Properties.Resources.eyeClosed;
            this.picPassword.Location = new System.Drawing.Point(434, 106);
            this.picPassword.Margin = new System.Windows.Forms.Padding(2);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(25, 24);
            this.picPassword.TabIndex = 14;
            this.picPassword.TabStop = false;
            this.picPassword.Click += new System.EventHandler(this.picPassword_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(269, 152);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 263);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.picPassword);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.lblNewCustomer);
            this.Controls.Add(this.lblReturningCustomers);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblCustPassword);
            this.Controls.Add(this.lblCustUserName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustUserName;
        private System.Windows.Forms.Label lblCustPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblReturningCustomers;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}

