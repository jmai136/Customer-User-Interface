namespace GourmetShop.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            // Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string? ContactName { get; set; }

        [StringLength(40)]
        public string? ContactTitle { get; set; }

        [StringLength(40)]
        public string? City { get; set; }

        [StringLength(40)]
        public string? Country { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }

        [StringLength(30)]
        public string? Fax { get; set; }

        /*
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        */

        public override bool Equals(object obj)
        {
            if (obj is Supplier)
            {
                var that = obj as Supplier;
                return
                    this.Id == that.Id &&
                    object.Equals(this.CompanyName, that.CompanyName) &&
                    object.Equals(this.ContactName, that.ContactName) &&
                    object.Equals(this.ContactTitle, that.ContactTitle) &&
                    object.Equals(this.City, that.City) &&
                    object.Equals(this.Country, that.Country) &&
                    object.Equals( this.Phone, that.Phone) &&
                    object.Equals(this.Fax, that.Fax);
            }

            return false;
        }
    }
}
