using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.DAL.Managers
{
    public class OrderItemManagerDAL
    {
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
