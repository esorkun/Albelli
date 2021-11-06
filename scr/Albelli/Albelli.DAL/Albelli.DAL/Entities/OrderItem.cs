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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ClientOrderId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderItem")]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(ClientOrderId))]
        [InverseProperty("OrderItem")]
        public virtual ClientOrder ClientOrder { get; set; }

    }
}
