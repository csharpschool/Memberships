using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Memberships.Entities
{
    [Table("ProductItem")]
    public class ProductItem
    {
        [Required]
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [Required]
        [Key, Column(Order = 2)]
        public int ItemId { get; set; }
        [NotMapped]
        public int OldProductId { get; set; }
        [NotMapped]
        public int OldItemId { get; set; }

    }
}