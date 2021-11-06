using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Albelli.DAL.Entities
{
    public partial class ClientOrder
    {
        public ClientOrder()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal RequiredBinWidth { get; set; }

        [InverseProperty("ClientOrder")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
