﻿namespace GourmetShop.LoginForm
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
            this.picCustPassword = new System.Windows.Forms.PictureBox();
            this.lblAdminUserName = new System.Windows.Forms.Label();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.picAdminPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCustPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdminPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustUserName
            // 
            this.lblCustUserName.AutoSize = true;
            this.lblCustUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustUserName.Location = new System.Drawing.Point(140, 62);
            this.lblCustUserName.Name = "lblCustUserName";
            this.lblCustUserName.Size = new System.Drawing.Size(108, 25);
            this.lblCustUserName.TabIndex = 0;
            this.lblCustUserName.Text = "Username:";
            // 
            // lblCustPassword
            // 
            this.lblCustPassword.AutoSize = true;
            this.lblCustPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPassword.Location = new System.Drawing.Point(140, 130);
            this.lblCustPassword.Name = "lblCustPassword";
            this.lblCustPassword.Size = new System.Drawing.Size(104, 25);
            this.lblCustPassword.TabIndex = 1;
            this.lblCustPassword.Text = "Password:";
            // 
            // txtCustUserName
            // 
            this.txtCustUserName.Location = new System.Drawing.Point(279, 65);
            this.txtCustUserName.Name = "txtCustUserName";
            this.txtCustUserName.Size = new System.Drawing.Size(282, 22);
            this.txtCustUserName.TabIndex = 2;
            this.txtCustUserName.TextChanged += new System.EventHandler(this.txtCustUserName_TextChanged);
            // 
            // txtCustPassword
            // 
            this.txtCustPassword.Location = new System.Drawing.Point(279, 130);
            this.txtCustPassword.Name = "txtCustPassword";
            this.txtCustPassword.PasswordChar = '*';
            this.txtCustPassword.Size = new System.Drawing.Size(282, 22);
            this.txtCustPassword.TabIndex = 3;
            this.txtCustPassword.TextChanged += new System.EventHandler(this.txtCustPassword_TextChanged);
            // 
            // btnCustLogin
            // 
            this.btnCustLogin.Enabled = false;
            this.btnCustLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustLogin.Location = new System.Drawing.Point(341, 179);
            this.btnCustLogin.Name = "btnCustLogin";
            this.btnCustLogin.Size = new System.Drawing.Size(117, 42);
            this.btnCustLogin.TabIndex = 4;
            this.btnCustLogin.Text = "Login";
            this.btnCustLogin.UseVisualStyleBackColor = true;
            this.btnCustLogin.Click += new System.EventHandler(this.btnCustLogin_Click);
            // 
            // lblReturningCustomers
            // 
            this.lblReturningCustomers.AutoSize = true;
            this.lblReturningCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturningCustomers.Location = new System.Drawing.Point(324, 22);
            this.lblReturningCustomers.Name = "lblReturningCustomers";
            this.lblReturningCustomers.Size = new System.Drawing.Size(195, 25);
            this.lblReturningCustomers.TabIndex = 5;
            this.lblReturningCustomers.Text = "Returning Customers";
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCustomer.Location = new System.Drawing.Point(12, 261);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(323, 25);
            this.lblNewCustomer.TabIndex = 6;
            this.lblNewCustomer.Text = "Need an account? Create one here:";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.Location = new System.Drawing.Point(359, 255);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(202, 37);
            this.btnNewCustomer.TabIndex = 7;
            this.btnNewCustomer.Text = "New User";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // picCustPassword
            // 
            this.picCustPassword.Image = global::GourmetShop.LoginForm.Properties.Resources.eyeClosed;
            this.picCustPassword.Location = new System.Drawing.Point(579, 130);
            this.picCustPassword.Name = "picCustPassword";
            this.picCustPassword.Size = new System.Drawing.Size(33, 29);
            this.picCustPassword.TabIndex = 14;
            this.picCustPassword.TabStop = false;
            this.picCustPassword.Click += new System.EventHandler(this.picCustPassword_Click);
            // 
            // lblAdminUserName
            // 
            this.lblAdminUserName.AutoSize = true;
            this.lblAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUserName.Location = new System.Drawing.Point(153, 350);
            this.lblAdminUserName.Name = "lblAdminUserName";
            this.lblAdminUserName.Size = new System.Drawing.Size(108, 25);
            this.lblAdminUserName.TabIndex = 9;
            this.lblAdminUserName.Text = "Username:";
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.Location = new System.Drawing.Point(267, 354);
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(282, 22);
            this.txtAdminUsername.TabIndex = 10;
            this.txtAdminUsername.TextChanged += new System.EventHandler(this.txtAdminUsername_TextChanged);
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPassword.Location = new System.Drawing.Point(153, 402);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(104, 25);
            this.lblAdminPassword.TabIndex = 11;
            this.lblAdminPassword.Text = "Password:";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(267, 405);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.PasswordChar = '*';
            this.txtAdminPassword.Size = new System.Drawing.Size(282, 22);
            this.txtAdminPassword.TabIndex = 12;
            this.txtAdminPassword.TextChanged += new System.EventHandler(this.txtAdminPassword_TextChanged);
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Enabled = false;
            this.btnAdminLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminLogin.Location = new System.Drawing.Point(341, 440);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(178, 42);
            this.btnAdminLogin.TabIndex = 13;
            this.btnAdminLogin.Text = "Admin Login";
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // picAdminPassword
            // 
            this.picAdminPassword.Image = global::GourmetShop.LoginForm.Properties.Resources.eyeClosed;
            this.picAdminPassword.Location = new System.Drawing.Point(579, 405);
            this.picAdminPassword.Name = "picAdminPassword";
            this.picAdminPassword.Size = new System.Drawing.Size(33, 29);
            this.picAdminPassword.TabIndex = 15;
            this.picAdminPassword.TabStop = false;
            this.picAdminPassword.Click += new System.EventHandler(this.picAdminPassword_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.picAdminPassword);
            this.Controls.Add(this.picCustPassword);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.txtAdminPassword);
            this.Controls.Add(this.lblAdminPassword);
            this.Controls.Add(this.txtAdminUsername);
            this.Controls.Add(this.lblAdminUserName);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.lblNewCustomer);
            this.Controls.Add(this.lblReturningCustomers);
            this.Controls.Add(this.btnCustLogin);
            this.Controls.Add(this.txtCustPassword);
            this.Controls.Add(this.txtCustUserName);
            this.Controls.Add(this.lblCustPassword);
            this.Controls.Add(this.lblCustUserName);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
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
        private System.Windows.Forms.PictureBox picCustPassword;
        private System.Windows.Forms.Label lblAdminUserName;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.PictureBox picAdminPassword;
    }
}

