using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public string ProductType { get; set; }
        internal Product Product { get; set; }

        public OrderItem()
        {
        }

    }
}
