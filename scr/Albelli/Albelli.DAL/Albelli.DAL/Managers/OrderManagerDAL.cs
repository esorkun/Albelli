using Albelli.DAL;
using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.DAL.Managers
{
    public class OrderManagerDAL
    {
        public List<Orders> GetAllOrders()
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.Orders.ToList();
            }
        }

        public Orders GetOrdersById(int orderId)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.Orders.FirstOrDefault(x => x.Id == orderId);
            }
        }

        public Orders CreateOrder(Orders newOrder)
        {

            using (var dbContext = new AlbelliDbContext())
            {
                dbContext.Orders.Add(newOrder);
                dbContext.SaveChanges();
            }

            return newOrder;
        }
    }
}
