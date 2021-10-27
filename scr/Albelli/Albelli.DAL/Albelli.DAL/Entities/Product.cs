using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Albelli.DAL.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(36)]
        public string ProductType { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal Width { get; set; }
        public int StackabilityLimit { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
