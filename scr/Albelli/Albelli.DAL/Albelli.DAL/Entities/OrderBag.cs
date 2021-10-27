using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Albelli.DAL.Entities
{
    public partial class OrderBag
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(ClientOrder.OrderBag))]
        public virtual ClientOrder Order { get; set; }
        [ForeignKey(nameof(OrderItemId))]
        [InverseProperty("OrderBag")]
        public virtual OrderItem OrderItem { get; set; }
    }
}
