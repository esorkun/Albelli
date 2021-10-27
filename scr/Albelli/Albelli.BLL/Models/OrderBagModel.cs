using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Models
{
    public class OrderBagModel
    {
        internal int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public OrderBagModel()
        {

        }

        public OrderBagModel(OrderModel orderModel, OrderItemModel orderItemModel)
        {
            this.OrderId = orderModel.Id;
            this.OrderItemId = orderItemModel.Id;
        }
    }
}
