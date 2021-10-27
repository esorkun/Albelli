using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Albelli.DAL.Entities
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            OrderBag = new HashSet<OrderBag>();
        }

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderItem")]
        public virtual Product Product { get; set; }
        [InverseProperty("OrderItem")]
        public virtual ICollection<OrderBag> OrderBag { get; set; }
    }
}
