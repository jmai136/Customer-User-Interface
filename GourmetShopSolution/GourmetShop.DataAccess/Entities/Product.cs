namespace GourmetShop.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        [StringLength(30)]
        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        // public virtual Supplier Supplier { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                var that = obj as Product;
                return 
                    this.Id == that.Id && 
                    object.Equals(this.ProductName, that.ProductName) &&
                    this.SupplierId == that.SupplierId &&
                    this.UnitPrice == that.UnitPrice &&
                    object.Equals(this.Package, that.Package) &&
                    this.IsDiscontinued == that.IsDiscontinued;
            }

            return false;
        }
    }
}
