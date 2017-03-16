using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memberships.Models
{
    public class ProductSection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ItemTypeId { get; set; }
        public IEnumerable<ProductItemRow> Items { get; set; }
    }
}