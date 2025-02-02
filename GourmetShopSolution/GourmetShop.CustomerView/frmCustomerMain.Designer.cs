namespace GourmetShop.CustomerView
{
    partial class frmCustomerMain
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
            this.btnShoppingCart = new System.Windows.Forms.Button();
            this.dgvCustViewProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShoppingCart
            // 
            this.btnShoppingCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoppingCart.Location = new System.Drawing.Point(1316, 467);
            this.btnShoppingCart.Name = "btnShoppingCart";
            this.btnShoppingCart.Size = new System.Drawing.Size(191, 32);
            this.btnShoppingCart.TabIndex = 0;
            this.btnShoppingCart.Text = "View/Edit Shopping Cart";
            this.btnShoppingCart.UseVisualStyleBackColor = true;
            this.btnShoppingCart.Click += new System.EventHandler(this.btnShoppingCart_Click);
            // 
            // dgvCustViewProducts
            // 
            this.dgvCustViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustViewProducts.Location = new System.Drawing.Point(77, 63);
            this.dgvCustViewProducts.Name = "dgvCustViewProducts";
            this.dgvCustViewProducts.RowHeadersWidth = 51;
            this.dgvCustViewProducts.RowTemplate.Height = 24;
            this.dgvCustViewProducts.Size = new System.Drawing.Size(1246, 337);
            this.dgvCustViewProducts.TabIndex = 1;
            // 
            // frmCustomerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 511);
            this.Controls.Add(this.dgvCustViewProducts);
            this.Controls.Add(this.btnShoppingCart);
            this.Name = "frmCustomerMain";
            this.Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShoppingCart;
        private System.Windows.Forms.DataGridView dgvCustViewProducts;
    }
}

