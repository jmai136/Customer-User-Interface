namespace GourmetShop.WinForms
{
    partial class MainForm
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
            this.msGourmetShop.SuspendLayout();
            this.SuspendLayout();
            // 
            // msGourmetShop
            // 
            this.msGourmetShop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.productsToolStripMenuItem,
            this.suppliersToolStripMenuItem});
            this.msGourmetShop.Location = new System.Drawing.Point(0, 0);
            this.msGourmetShop.Name = "msGourmetShop";
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.lblInstructions.Location = new System.Drawing.Point(12, 36);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(301, 13);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Navigate to either products or suppliers via the above toolstrip.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.msGourmetShop);
            this.MainMenuStrip = this.msGourmetShop;
            this.Name = "MainForm";
            this.Text = "Gourmet Shop Main Form";
            this.msGourmetShop.ResumeLayout(false);
            this.msGourmetShop.PerformLayout();
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
    }
}

