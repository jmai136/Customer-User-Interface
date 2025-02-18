﻿namespace GourmetShop.WinForms
{
    partial class frmAdminMain
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
            this.msGourmetShop = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vts_mi_ViewProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vts_mi_ViewSuppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.dgvAvailableProducts = new System.Windows.Forms.DataGridView();
            this.lblSalesInstructions = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTotalUnitsSold = new System.Windows.Forms.Label();
            this.lblTotalSalesAmount = new System.Windows.Forms.Label();
            this.msGourmetShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // msGourmetShop
            // 
            this.msGourmetShop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msGourmetShop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.productsToolStripMenuItem,
            this.suppliersToolStripMenuItem});
            this.msGourmetShop.Location = new System.Drawing.Point(0, 0);
            this.msGourmetShop.Name = "msGourmetShop";
            this.msGourmetShop.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msGourmetShop.Size = new System.Drawing.Size(800, 24);
            this.msGourmetShop.TabIndex = 0;
            this.msGourmetShop.Text = "Gourmet Shop Menu Strip";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vts_mi_ViewProducts});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // vts_mi_ViewProducts
            // 
            this.vts_mi_ViewProducts.Name = "vts_mi_ViewProducts";
            this.vts_mi_ViewProducts.Size = new System.Drawing.Size(99, 22);
            this.vts_mi_ViewProducts.Text = "View";
            this.vts_mi_ViewProducts.Click += new System.EventHandler(this.vts_mi_ViewProducts_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vts_mi_ViewSuppliers});
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // vts_mi_ViewSuppliers
            // 
            this.vts_mi_ViewSuppliers.Name = "vts_mi_ViewSuppliers";
            this.vts_mi_ViewSuppliers.Size = new System.Drawing.Size(99, 22);
            this.vts_mi_ViewSuppliers.Text = "View";
            this.vts_mi_ViewSuppliers.Click += new System.EventHandler(this.vts_mi_ViewSuppliers_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(184, 7);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(301, 13);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Navigate to either products or suppliers via the above toolstrip.";
            // 
            // dgvAvailableProducts
            // 
            this.dgvAvailableProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableProducts.Location = new System.Drawing.Point(29, 86);
            this.dgvAvailableProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAvailableProducts.Name = "dgvAvailableProducts";
            this.dgvAvailableProducts.RowHeadersWidth = 51;
            this.dgvAvailableProducts.RowTemplate.Height = 24;
            this.dgvAvailableProducts.Size = new System.Drawing.Size(296, 313);
            this.dgvAvailableProducts.TabIndex = 2;
            this.dgvAvailableProducts.SelectionChanged += new System.EventHandler(this.dgvAvailableProducts_SelectionChanged);
            // 
            // lblSalesInstructions
            // 
            this.lblSalesInstructions.AutoSize = true;
            this.lblSalesInstructions.Location = new System.Drawing.Point(56, 419);
            this.lblSalesInstructions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalesInstructions.Name = "lblSalesInstructions";
            this.lblSalesInstructions.Size = new System.Drawing.Size(211, 13);
            this.lblSalesInstructions.TabIndex = 3;
            this.lblSalesInstructions.Text = "Click on a product to view sales information";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(224, 40);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(403, 26);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Sales Information of Continued Products";
            // 
            // lblTotalUnitsSold
            // 
            this.lblTotalUnitsSold.AutoSize = true;
            this.lblTotalUnitsSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUnitsSold.Location = new System.Drawing.Point(370, 144);
            this.lblTotalUnitsSold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalUnitsSold.Name = "lblTotalUnitsSold";
            this.lblTotalUnitsSold.Size = new System.Drawing.Size(192, 20);
            this.lblTotalUnitsSold.TabIndex = 5;
            this.lblTotalUnitsSold.Text = "Products Total Units Sold:";
            // 
            // lblTotalSalesAmount
            // 
            this.lblTotalSalesAmount.AutoSize = true;
            this.lblTotalSalesAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesAmount.Location = new System.Drawing.Point(370, 223);
            this.lblTotalSalesAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSalesAmount.Name = "lblTotalSalesAmount";
            this.lblTotalSalesAmount.Size = new System.Drawing.Size(219, 20);
            this.lblTotalSalesAmount.TabIndex = 6;
            this.lblTotalSalesAmount.Text = "Products Total Sales Amount:";
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotalSalesAmount);
            this.Controls.Add(this.lblTotalUnitsSold);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblSalesInstructions);
            this.Controls.Add(this.dgvAvailableProducts);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.msGourmetShop);
            this.MainMenuStrip = this.msGourmetShop;
            this.Name = "frmAdminMain";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msGourmetShop.ResumeLayout(false);
            this.msGourmetShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msGourmetShop;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vts_mi_ViewProducts;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vts_mi_ViewSuppliers;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.DataGridView dgvAvailableProducts;
        private System.Windows.Forms.Label lblSalesInstructions;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTotalUnitsSold;
        private System.Windows.Forms.Label lblTotalSalesAmount;
    }
}

