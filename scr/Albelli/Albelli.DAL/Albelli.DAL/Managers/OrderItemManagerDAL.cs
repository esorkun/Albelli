using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albelli.DAL.Managers
{
    public class OrderItemManagerDAL
    {
        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.OrderItem.Where(o => o.ClientOrderId == orderId).ToList(); ;
            }
        }

        public OrderItem CreateOrderItem(OrderItem newOrderItem)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                dbContext.OrderItem.Add(newOrderItem);
                dbContext.SaveChanges();
            }

            return newOrderItem;
        }
    }
}
