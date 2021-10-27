using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.DAL.Managers
{
    public class OrderBagManagerDAL
    {
        public OrderBag CreateOrderBag(OrderBag newOrderBag)
        {

            using (var dbContext = new AlbelliDbContext())
            {
                dbContext.OrderBag.Add(newOrderBag);
                dbContext.SaveChanges();
            }

            return newOrderBag;
        }
    }
}
