namespace GourmetShop.CustomerView
{
    partial class frmShoppingCart
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
            this.dgvShoppingCartView = new System.Windows.Forms.DataGridView();
            this.lblShoppingCart = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnReturnHome = new System.Windows.Forms.Button();
            this.lblTotalAmountDue = new System.Windows.Forms.Label();
            this.lbleditinstructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingCartView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShoppingCartView
            // 
            this.dgvShoppingCartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShoppingCartView.Location = new System.Drawing.Point(12, 65);
            this.dgvShoppingCartView.Name = "dgvShoppingCartView";
            this.dgvShoppingCartView.RowHeadersWidth = 51;
            this.dgvShoppingCartView.RowTemplate.Height = 24;
            this.dgvShoppingCartView.Size = new System.Drawing.Size(343, 362);
            this.dgvShoppingCartView.TabIndex = 0;
            this.dgvShoppingCartView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShoppingCartView_CellEndEdit);
            // 
            // lblShoppingCart
            // 
            this.lblShoppingCart.AutoSize = true;
            this.lblShoppingCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingCart.Location = new System.Drawing.Point(310, 13);
            this.lblShoppingCart.Name = "lblShoppingCart";
            this.lblShoppingCart.Size = new System.Drawing.Size(167, 29);
            this.lblShoppingCart.TabIndex = 1;
            this.lblShoppingCart.Text = "Shopping Cart";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(401, 187);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(156, 23);
            this.btnRemoveProduct.TabIndex = 2;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(505, 375);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(152, 34);
            this.btnPlaceOrder.TabIndex = 3;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.lblPlaceOrder_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.Location = new System.Drawing.Point(583, 187);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(157, 23);
            this.btnReturnHome.TabIndex = 4;
            this.btnReturnHome.Text = "Return to Home";
            this.btnReturnHome.UseVisualStyleBackColor = true;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // lblTotalAmountDue
            // 
            this.lblTotalAmountDue.AutoSize = true;
            this.lblTotalAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountDue.Location = new System.Drawing.Point(408, 315);
            this.lblTotalAmountDue.Name = "lblTotalAmountDue";
            this.lblTotalAmountDue.Size = new System.Drawing.Size(0, 25);
            this.lblTotalAmountDue.TabIndex = 5;
            // 
            // lbleditinstructions
            // 
            this.lbleditinstructions.AutoSize = true;
            this.lbleditinstructions.Location = new System.Drawing.Point(459, 232);
            this.lbleditinstructions.Name = "lbleditinstructions";
            this.lbleditinstructions.Size = new System.Drawing.Size(222, 16);
            this.lbleditinstructions.TabIndex = 6;
            this.lbleditinstructions.Text = "If needed click on quantity to change";
            // 
            // frmShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbleditinstructions);
            this.Controls.Add(this.lblTotalAmountDue);
            this.Controls.Add(this.btnReturnHome);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.lblShoppingCart);
            this.Controls.Add(this.dgvShoppingCartView);
            this.Name = "frmShoppingCart";
            this.Text = "Shopping Cart";
            this.Load += new System.EventHandler(this.frmShoppingCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingCartView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShoppingCartView;
        private System.Windows.Forms.Label lblShoppingCart;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnReturnHome;
        private System.Windows.Forms.Label lblTotalAmountDue;
        private System.Windows.Forms.Label lbleditinstructions;
    }
}