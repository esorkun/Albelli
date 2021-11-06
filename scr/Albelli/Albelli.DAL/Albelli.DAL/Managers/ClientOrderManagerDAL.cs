using Albelli.DAL;
using Albelli.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.DAL.Managers
{
    public class ClientOrderManagerDAL
    {
        public List<ClientOrder> GetAllClientOrders()
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.ClientOrder.ToList();
            }
        }

        public ClientOrder GetOrderById(int orderId)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.ClientOrder.FirstOrDefault(x => x.Id == orderId);
            }
        }

        public ClientOrder CreateOrder(ClientOrder newOrder)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                dbContext.ClientOrder.Add(newOrder);
                dbContext.SaveChanges();
            }

            return newOrder;
        }
    }
}
