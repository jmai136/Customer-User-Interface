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
            this.txtCustUserName = new System.Windows.Forms.TextBox();
            this.txtCustPassword = new System.Windows.Forms.TextBox();
            this.btnCustLogin = new System.Windows.Forms.Button();
            this.lblReturningCustomers = new System.Windows.Forms.Label();
            this.lblNewCustomer = new System.Windows.Forms.Label();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.lblAdminUserName = new System.Windows.Forms.Label();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.picCustPassword = new System.Windows.Forms.PictureBox();
            this.picAdminPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCustPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminPassword)).BeginInit();
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
            // txtCustUserName
            // 
            this.txtCustUserName.Location = new System.Drawing.Point(209, 53);
            this.txtCustUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustUserName.Name = "txtCustUserName";
            this.txtCustUserName.Size = new System.Drawing.Size(212, 20);
            this.txtCustUserName.TabIndex = 2;
            this.txtCustUserName.TextChanged += new System.EventHandler(this.txtCustUserName_TextChanged);
            // 
            // txtCustPassword
            // 
            this.txtCustPassword.Location = new System.Drawing.Point(209, 106);
            this.txtCustPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustPassword.Name = "txtCustPassword";
            this.txtCustPassword.PasswordChar = '*';
            this.txtCustPassword.Size = new System.Drawing.Size(212, 20);
            this.txtCustPassword.TabIndex = 3;
            this.txtCustPassword.TextChanged += new System.EventHandler(this.txtCustPassword_TextChanged);
            // 
            // btnCustLogin
            // 
            this.btnCustLogin.Enabled = false;
            this.btnCustLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustLogin.Location = new System.Drawing.Point(268, 145);
            this.btnCustLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCustLogin.Name = "btnCustLogin";
            this.btnCustLogin.Size = new System.Drawing.Size(88, 34);
            this.btnCustLogin.TabIndex = 4;
            this.btnCustLogin.Text = "Login";
            this.btnCustLogin.UseVisualStyleBackColor = true;
            this.btnCustLogin.Click += new System.EventHandler(this.btnCustLogin_Click);
            // 
            // lblReturningCustomers
            // 
            this.lblReturningCustomers.AutoSize = true;
            this.lblReturningCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturningCustomers.Location = new System.Drawing.Point(243, 18);
            this.lblReturningCustomers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReturningCustomers.Name = "lblReturningCustomers";
            this.lblReturningCustomers.Size = new System.Drawing.Size(160, 20);
            this.lblReturningCustomers.TabIndex = 5;
            this.lblReturningCustomers.Text = "Returning Customers";
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
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.Location = new System.Drawing.Point(269, 207);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(152, 30);
            this.btnNewCustomer.TabIndex = 7;
            this.btnNewCustomer.Text = "New Customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(9, 375);
            this.chkAdmin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(93, 17);
            this.chkAdmin.TabIndex = 8;
            this.chkAdmin.Text = "I am an Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // lblAdminUserName
            // 
            this.lblAdminUserName.AutoSize = true;
            this.lblAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUserName.Location = new System.Drawing.Point(115, 284);
            this.lblAdminUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdminUserName.Name = "lblAdminUserName";
            this.lblAdminUserName.Size = new System.Drawing.Size(87, 20);
            this.lblAdminUserName.TabIndex = 9;
            this.lblAdminUserName.Text = "Username:";
            this.lblAdminUserName.Visible = false;
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.Location = new System.Drawing.Point(200, 288);
            this.txtAdminUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(212, 20);
            this.txtAdminUsername.TabIndex = 10;
            this.txtAdminUsername.Visible = false;
            this.txtAdminUsername.TextChanged += new System.EventHandler(this.txtAdminUsername_TextChanged);
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPassword.Location = new System.Drawing.Point(115, 327);
            this.lblAdminPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(82, 20);
            this.lblAdminPassword.TabIndex = 11;
            this.lblAdminPassword.Text = "Password:";
            this.lblAdminPassword.Visible = false;
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(200, 329);
            this.txtAdminPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.PasswordChar = '*';
            this.txtAdminPassword.Size = new System.Drawing.Size(212, 20);
            this.txtAdminPassword.TabIndex = 12;
            this.txtAdminPassword.Visible = false;
            this.txtAdminPassword.TextChanged += new System.EventHandler(this.txtAdminPassword_TextChanged);
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Enabled = false;
            this.btnAdminLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminLogin.Location = new System.Drawing.Point(268, 358);
            this.btnAdminLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(88, 34);
            this.btnAdminLogin.TabIndex = 13;
            this.btnAdminLogin.Text = "Login";
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Visible = false;
            // 
            // picCustPassword
            // 
            this.picCustPassword.Location = new System.Drawing.Point(434, 106);
            this.picCustPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picCustPassword.Name = "picCustPassword";
            this.picCustPassword.Size = new System.Drawing.Size(25, 24);
            this.picCustPassword.TabIndex = 14;
            this.picCustPassword.TabStop = false;
            this.picCustPassword.Click += new System.EventHandler(this.picCustPassword_Click);
            // 
            // picAdminPassword
            // 
            this.picAdminPassword.Location = new System.Drawing.Point(434, 329);
            this.picAdminPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picAdminPassword.Name = "picAdminPassword";
            this.picAdminPassword.Size = new System.Drawing.Size(25, 24);
            this.picAdminPassword.TabIndex = 15;
            this.picAdminPassword.TabStop = false;
            this.picAdminPassword.Visible = false;
            this.picAdminPassword.Click += new System.EventHandler(this.picAdminPassword_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 401);
            this.Controls.Add(this.picAdminPassword);
            this.Controls.Add(this.picCustPassword);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.txtAdminPassword);
            this.Controls.Add(this.lblAdminPassword);
            this.Controls.Add(this.txtAdminUsername);
            this.Controls.Add(this.lblAdminUserName);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.lblNewCustomer);
            this.Controls.Add(this.lblReturningCustomers);
            this.Controls.Add(this.btnCustLogin);
            this.Controls.Add(this.txtCustPassword);
            this.Controls.Add(this.txtCustUserName);
            this.Controls.Add(this.lblCustPassword);
            this.Controls.Add(this.lblCustUserName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLogin";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.picCustPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustUserName;
        private System.Windows.Forms.Label lblCustPassword;
        private System.Windows.Forms.TextBox txtCustUserName;
        private System.Windows.Forms.TextBox txtCustPassword;
        private System.Windows.Forms.Button btnCustLogin;
        private System.Windows.Forms.Label lblReturningCustomers;
        private System.Windows.Forms.Label lblNewCustomer;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Label lblAdminUserName;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.PictureBox picCustPassword;
        private System.Windows.Forms.PictureBox picAdminPassword;
    }
}

