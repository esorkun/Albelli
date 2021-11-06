using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Models
{
    public class OrderItemModel
    {
        internal int ClientOrderId { get; set; }
        public int Quantity { get; set; }
        public string ProductType { get; set; }
        internal ProductModel Product { get; set; }

        public OrderItemModel()
        {
        }

        
    }
}
