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
            this.cboCustSuppliers = new System.Windows.Forms.ComboBox();
            this.lblSupplierProducts = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lblAddToCart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShoppingCart
            // 
            this.btnShoppingCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoppingCart.Location = new System.Drawing.Point(737, 467);
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
            this.dgvCustViewProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvCustViewProducts.Name = "dgvCustViewProducts";
            this.dgvCustViewProducts.RowHeadersWidth = 51;
            this.dgvCustViewProducts.RowTemplate.Height = 24;
            this.dgvCustViewProducts.Size = new System.Drawing.Size(497, 487);
            this.dgvCustViewProducts.TabIndex = 1;
            this.dgvCustViewProducts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustViewProducts_DataBindingComplete);
            // 
            // cboCustSuppliers
            // 
            this.cboCustSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustSuppliers.FormattingEnabled = true;
            this.cboCustSuppliers.Location = new System.Drawing.Point(603, 75);
            this.cboCustSuppliers.Name = "cboCustSuppliers";
            this.cboCustSuppliers.Size = new System.Drawing.Size(261, 28);
            this.cboCustSuppliers.Sorted = true;
            this.cboCustSuppliers.TabIndex = 2;
            this.cboCustSuppliers.SelectedIndexChanged += new System.EventHandler(this.cboCustSuppliers_SelectedIndexChanged);
            // 
            // lblSupplierProducts
            // 
            this.lblSupplierProducts.AutoSize = true;
            this.lblSupplierProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierProducts.Location = new System.Drawing.Point(597, 36);
            this.lblSupplierProducts.Name = "lblSupplierProducts";
            this.lblSupplierProducts.Size = new System.Drawing.Size(266, 25);
            this.lblSupplierProducts.TabIndex = 3;
            this.lblSupplierProducts.Text = "Filter Products by Supplier";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(687, 226);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 22);
            this.nudQuantity.TabIndex = 4;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(540, 228);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(123, 20);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Select Quantity";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(687, 296);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(120, 38);
            this.btnAddToCart.TabIndex = 6;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lblAddToCart
            // 
            this.lblAddToCart.AutoSize = true;
            this.lblAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddToCart.Location = new System.Drawing.Point(703, 352);
            this.lblAddToCart.Name = "lblAddToCart";
            this.lblAddToCart.Size = new System.Drawing.Size(0, 20);
            this.lblAddToCart.TabIndex = 7;
            this.lblAddToCart.Visible = false;
            // 
            // frmCustomerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 511);
            this.Controls.Add(this.lblAddToCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblSupplierProducts);
            this.Controls.Add(this.cboCustSuppliers);
            this.Controls.Add(this.dgvCustViewProducts);
            this.Controls.Add(this.btnShoppingCart);
            this.Name = "frmCustomerMain";
            this.Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShoppingCart;
        private System.Windows.Forms.DataGridView dgvCustViewProducts;
        private System.Windows.Forms.ComboBox cboCustSuppliers;
        private System.Windows.Forms.Label lblSupplierProducts;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label lblAddToCart;
    }
}

