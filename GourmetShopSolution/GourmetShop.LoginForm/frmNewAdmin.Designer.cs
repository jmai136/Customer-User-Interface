namespace GourmetShop.LoginForm
{
    partial class frmNewAdmin
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
            this.lblAdminAccountCreated = new System.Windows.Forms.Label();
            this.btnAdminReturn = new System.Windows.Forms.Button();
            this.lblAdminPassMisMatch = new System.Windows.Forms.Label();
            this.lblAdminInvalidEmail = new System.Windows.Forms.Label();
            this.picNewAdminConfirmPassword = new System.Windows.Forms.PictureBox();
            this.picNewAdminPassword = new System.Windows.Forms.PictureBox();
            this.btnNewAdminCreateAccount = new System.Windows.Forms.Button();
            this.txtNewAdminPhone = new System.Windows.Forms.TextBox();
            this.txtNewAdminCountry = new System.Windows.Forms.TextBox();
            this.txtNewAdminCity = new System.Windows.Forms.TextBox();
            this.txtNewAdminLastName = new System.Windows.Forms.TextBox();
            this.txtNewAdminFirstName = new System.Windows.Forms.TextBox();
            this.txtNewAdminConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewAdminPassword = new System.Windows.Forms.TextBox();
            this.lblNewAdminPhone = new System.Windows.Forms.Label();
            this.lblNewAdminCountry = new System.Windows.Forms.Label();
            this.lblNewAdminCity = new System.Windows.Forms.Label();
            this.lblNewAdminLastName = new System.Windows.Forms.Label();
            this.lblNewAdminFirstName = new System.Windows.Forms.Label();
            this.lblNewAdminPassword = new System.Windows.Forms.Label();
            this.lblNewAdminConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewAdminUserName = new System.Windows.Forms.TextBox();
            this.lblNewAdminUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picNewAdminConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewAdminPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdminAccountCreated
            // 
            this.lblAdminAccountCreated.AutoSize = true;
            this.lblAdminAccountCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminAccountCreated.Location = new System.Drawing.Point(233, 413);
            this.lblAdminAccountCreated.Name = "lblAdminAccountCreated";
            this.lblAdminAccountCreated.Size = new System.Drawing.Size(311, 20);
            this.lblAdminAccountCreated.TabIndex = 45;
            this.lblAdminAccountCreated.Text = "Admin Account Created! Return to Login";
            this.lblAdminAccountCreated.Visible = false;
            // 
            // btnAdminReturn
            // 
            this.btnAdminReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminReturn.Location = new System.Drawing.Point(600, 377);
            this.btnAdminReturn.Name = "btnAdminReturn";
            this.btnAdminReturn.Size = new System.Drawing.Size(180, 31);
            this.btnAdminReturn.TabIndex = 44;
            this.btnAdminReturn.Text = "Return to Login";
            this.btnAdminReturn.UseVisualStyleBackColor = true;
            this.btnAdminReturn.Click += new System.EventHandler(this.btnAdminReturn_Click);
            // 
            // lblAdminPassMisMatch
            // 
            this.lblAdminPassMisMatch.AutoSize = true;
            this.lblAdminPassMisMatch.Location = new System.Drawing.Point(291, 132);
            this.lblAdminPassMisMatch.Name = "lblAdminPassMisMatch";
            this.lblAdminPassMisMatch.Size = new System.Drawing.Size(191, 16);
            this.lblAdminPassMisMatch.TabIndex = 43;
            this.lblAdminPassMisMatch.Text = "Your password does not match";
            this.lblAdminPassMisMatch.Visible = false;
            // 
            // lblAdminInvalidEmail
            // 
            this.lblAdminInvalidEmail.AutoSize = true;
            this.lblAdminInvalidEmail.Location = new System.Drawing.Point(597, 25);
            this.lblAdminInvalidEmail.Name = "lblAdminInvalidEmail";
            this.lblAdminInvalidEmail.Size = new System.Drawing.Size(83, 16);
            this.lblAdminInvalidEmail.TabIndex = 42;
            this.lblAdminInvalidEmail.Text = "Invalid Email";
            this.lblAdminInvalidEmail.Visible = false;
            // 
            // picNewAdminConfirmPassword
            // 
            this.picNewAdminConfirmPassword.Image = global::GourmetShop.LoginForm.Properties.Resources.eyeClosed;
            this.picNewAdminConfirmPassword.Location = new System.Drawing.Point(600, 102);
            this.picNewAdminConfirmPassword.Name = "picNewAdminConfirmPassword";
            this.picNewAdminConfirmPassword.Size = new System.Drawing.Size(33, 29);
            this.picNewAdminConfirmPassword.TabIndex = 41;
            this.picNewAdminConfirmPassword.TabStop = false;
            this.picNewAdminConfirmPassword.Click += new System.EventHandler(this.picNewAdminConfirmPassword_Click);
            // 
            // picNewAdminPassword
            // 
            this.picNewAdminPassword.Image = global::GourmetShop.LoginForm.Properties.Resources.eyeClosed;
            this.picNewAdminPassword.Location = new System.Drawing.Point(600, 63);
            this.picNewAdminPassword.Name = "picNewAdminPassword";
            this.picNewAdminPassword.Size = new System.Drawing.Size(33, 29);
            this.picNewAdminPassword.TabIndex = 40;
            this.picNewAdminPassword.TabStop = false;
            this.picNewAdminPassword.Click += new System.EventHandler(this.picNewAdminPassword_Click);
            // 
            // btnNewAdminCreateAccount
            // 
            this.btnNewAdminCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAdminCreateAccount.Location = new System.Drawing.Point(294, 377);
            this.btnNewAdminCreateAccount.Name = "btnNewAdminCreateAccount";
            this.btnNewAdminCreateAccount.Size = new System.Drawing.Size(215, 33);
            this.btnNewAdminCreateAccount.TabIndex = 39;
            this.btnNewAdminCreateAccount.Text = "Create Admin Account";
            this.btnNewAdminCreateAccount.UseVisualStyleBackColor = true;
            this.btnNewAdminCreateAccount.Click += new System.EventHandler(this.btnNewAdminCreateAccount_Click);
            // 
            // txtNewAdminPhone
            // 
            this.txtNewAdminPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminPhone.Location = new System.Drawing.Point(215, 325);
            this.txtNewAdminPhone.Name = "txtNewAdminPhone";
            this.txtNewAdminPhone.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminPhone.TabIndex = 38;
            // 
            // txtNewAdminCountry
            // 
            this.txtNewAdminCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminCountry.Location = new System.Drawing.Point(215, 290);
            this.txtNewAdminCountry.Name = "txtNewAdminCountry";
            this.txtNewAdminCountry.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminCountry.TabIndex = 37;
            // 
            // txtNewAdminCity
            // 
            this.txtNewAdminCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminCity.Location = new System.Drawing.Point(215, 255);
            this.txtNewAdminCity.Name = "txtNewAdminCity";
            this.txtNewAdminCity.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminCity.TabIndex = 36;
            // 
            // txtNewAdminLastName
            // 
            this.txtNewAdminLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminLastName.Location = new System.Drawing.Point(215, 220);
            this.txtNewAdminLastName.Name = "txtNewAdminLastName";
            this.txtNewAdminLastName.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminLastName.TabIndex = 35;
            // 
            // txtNewAdminFirstName
            // 
            this.txtNewAdminFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminFirstName.Location = new System.Drawing.Point(215, 185);
            this.txtNewAdminFirstName.Name = "txtNewAdminFirstName";
            this.txtNewAdminFirstName.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminFirstName.TabIndex = 34;
            // 
            // txtNewAdminConfirmPassword
            // 
            this.txtNewAdminConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminConfirmPassword.Location = new System.Drawing.Point(215, 101);
            this.txtNewAdminConfirmPassword.Name = "txtNewAdminConfirmPassword";
            this.txtNewAdminConfirmPassword.PasswordChar = '*';
            this.txtNewAdminConfirmPassword.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminConfirmPassword.TabIndex = 33;
            // 
            // txtNewAdminPassword
            // 
            this.txtNewAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminPassword.Location = new System.Drawing.Point(215, 60);
            this.txtNewAdminPassword.Name = "txtNewAdminPassword";
            this.txtNewAdminPassword.PasswordChar = '*';
            this.txtNewAdminPassword.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminPassword.TabIndex = 32;
            // 
            // lblNewAdminPhone
            // 
            this.lblNewAdminPhone.AutoSize = true;
            this.lblNewAdminPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminPhone.Location = new System.Drawing.Point(21, 327);
            this.lblNewAdminPhone.Name = "lblNewAdminPhone";
            this.lblNewAdminPhone.Size = new System.Drawing.Size(75, 25);
            this.lblNewAdminPhone.TabIndex = 31;
            this.lblNewAdminPhone.Text = "Phone:";
            // 
            // lblNewAdminCountry
            // 
            this.lblNewAdminCountry.AutoSize = true;
            this.lblNewAdminCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminCountry.Location = new System.Drawing.Point(21, 292);
            this.lblNewAdminCountry.Name = "lblNewAdminCountry";
            this.lblNewAdminCountry.Size = new System.Drawing.Size(87, 25);
            this.lblNewAdminCountry.TabIndex = 30;
            this.lblNewAdminCountry.Text = "Country:";
            // 
            // lblNewAdminCity
            // 
            this.lblNewAdminCity.AutoSize = true;
            this.lblNewAdminCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminCity.Location = new System.Drawing.Point(21, 257);
            this.lblNewAdminCity.Name = "lblNewAdminCity";
            this.lblNewAdminCity.Size = new System.Drawing.Size(52, 25);
            this.lblNewAdminCity.TabIndex = 29;
            this.lblNewAdminCity.Text = "City:";
            // 
            // lblNewAdminLastName
            // 
            this.lblNewAdminLastName.AutoSize = true;
            this.lblNewAdminLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminLastName.Location = new System.Drawing.Point(21, 222);
            this.lblNewAdminLastName.Name = "lblNewAdminLastName";
            this.lblNewAdminLastName.Size = new System.Drawing.Size(112, 25);
            this.lblNewAdminLastName.TabIndex = 28;
            this.lblNewAdminLastName.Text = "Last Name:";
            // 
            // lblNewAdminFirstName
            // 
            this.lblNewAdminFirstName.AutoSize = true;
            this.lblNewAdminFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminFirstName.Location = new System.Drawing.Point(21, 187);
            this.lblNewAdminFirstName.Name = "lblNewAdminFirstName";
            this.lblNewAdminFirstName.Size = new System.Drawing.Size(112, 25);
            this.lblNewAdminFirstName.TabIndex = 27;
            this.lblNewAdminFirstName.Text = "First Name:";
            // 
            // lblNewAdminPassword
            // 
            this.lblNewAdminPassword.AutoSize = true;
            this.lblNewAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminPassword.Location = new System.Drawing.Point(21, 60);
            this.lblNewAdminPassword.Name = "lblNewAdminPassword";
            this.lblNewAdminPassword.Size = new System.Drawing.Size(104, 25);
            this.lblNewAdminPassword.TabIndex = 26;
            this.lblNewAdminPassword.Text = "Password:";
            // 
            // lblNewAdminConfirmPassword
            // 
            this.lblNewAdminConfirmPassword.AutoSize = true;
            this.lblNewAdminConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminConfirmPassword.Location = new System.Drawing.Point(21, 102);
            this.lblNewAdminConfirmPassword.Name = "lblNewAdminConfirmPassword";
            this.lblNewAdminConfirmPassword.Size = new System.Drawing.Size(177, 25);
            this.lblNewAdminConfirmPassword.TabIndex = 25;
            this.lblNewAdminConfirmPassword.Text = "Confirm Password:";
            // 
            // txtNewAdminUserName
            // 
            this.txtNewAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAdminUserName.Location = new System.Drawing.Point(215, 19);
            this.txtNewAdminUserName.Name = "txtNewAdminUserName";
            this.txtNewAdminUserName.Size = new System.Drawing.Size(376, 27);
            this.txtNewAdminUserName.TabIndex = 24;
            // 
            // lblNewAdminUserName
            // 
            this.lblNewAdminUserName.AutoSize = true;
            this.lblNewAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAdminUserName.Location = new System.Drawing.Point(21, 18);
            this.lblNewAdminUserName.Name = "lblNewAdminUserName";
            this.lblNewAdminUserName.Size = new System.Drawing.Size(162, 25);
            this.lblNewAdminUserName.TabIndex = 23;
            this.lblNewAdminUserName.Text = "Username/Email:";
            // 
            // frmNewAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAdminAccountCreated);
            this.Controls.Add(this.btnAdminReturn);
            this.Controls.Add(this.lblAdminPassMisMatch);
            this.Controls.Add(this.lblAdminInvalidEmail);
            this.Controls.Add(this.picNewAdminConfirmPassword);
            this.Controls.Add(this.picNewAdminPassword);
            this.Controls.Add(this.btnNewAdminCreateAccount);
            this.Controls.Add(this.txtNewAdminPhone);
            this.Controls.Add(this.txtNewAdminCountry);
            this.Controls.Add(this.txtNewAdminCity);
            this.Controls.Add(this.txtNewAdminLastName);
            this.Controls.Add(this.txtNewAdminFirstName);
            this.Controls.Add(this.txtNewAdminConfirmPassword);
            this.Controls.Add(this.txtNewAdminPassword);
            this.Controls.Add(this.lblNewAdminPhone);
            this.Controls.Add(this.lblNewAdminCountry);
            this.Controls.Add(this.lblNewAdminCity);
            this.Controls.Add(this.lblNewAdminLastName);
            this.Controls.Add(this.lblNewAdminFirstName);
            this.Controls.Add(this.lblNewAdminPassword);
            this.Controls.Add(this.lblNewAdminConfirmPassword);
            this.Controls.Add(this.txtNewAdminUserName);
            this.Controls.Add(this.lblNewAdminUserName);
            this.Name = "frmNewAdmin";
            this.Text = "New Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picNewAdminConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewAdminPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdminAccountCreated;
        private System.Windows.Forms.Button btnAdminReturn;
        private System.Windows.Forms.Label lblAdminPassMisMatch;
        private System.Windows.Forms.Label lblAdminInvalidEmail;
        private System.Windows.Forms.PictureBox picNewAdminConfirmPassword;
        private System.Windows.Forms.PictureBox picNewAdminPassword;
        private System.Windows.Forms.Button btnNewAdminCreateAccount;
        private System.Windows.Forms.TextBox txtNewAdminPhone;
        private System.Windows.Forms.TextBox txtNewAdminCountry;
        private System.Windows.Forms.TextBox txtNewAdminCity;
        private System.Windows.Forms.TextBox txtNewAdminLastName;
        private System.Windows.Forms.TextBox txtNewAdminFirstName;
        private System.Windows.Forms.TextBox txtNewAdminConfirmPassword;
        private System.Windows.Forms.TextBox txtNewAdminPassword;
        private System.Windows.Forms.Label lblNewAdminPhone;
        private System.Windows.Forms.Label lblNewAdminCountry;
        private System.Windows.Forms.Label lblNewAdminCity;
        private System.Windows.Forms.Label lblNewAdminLastName;
        private System.Windows.Forms.Label lblNewAdminFirstName;
        private System.Windows.Forms.Label lblNewAdminPassword;
        private System.Windows.Forms.Label lblNewAdminConfirmPassword;
        private System.Windows.Forms.TextBox txtNewAdminUserName;
        private System.Windows.Forms.Label lblNewAdminUserName;
    }
}