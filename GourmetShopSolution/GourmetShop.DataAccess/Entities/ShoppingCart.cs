namespace GourmetShop.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*public ShoppingCart()
        {
            ShoppingCartDetails = new HashSet<ShoppingCartDetail>();
        }*/

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }*/
    }
}
