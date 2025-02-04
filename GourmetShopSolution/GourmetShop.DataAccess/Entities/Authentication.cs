namespace GourmetShop.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Authentication")]
    public partial class Authentication
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(320)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
