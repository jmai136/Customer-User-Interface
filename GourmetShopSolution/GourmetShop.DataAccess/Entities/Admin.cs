namespace GourmetShop.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(320)]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
