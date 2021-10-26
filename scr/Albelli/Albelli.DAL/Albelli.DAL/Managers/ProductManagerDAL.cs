using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.DAL.Managers
{
    public class ProductManagerDAL
    {
        public Products GetProductByName(string productType)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.Products.FirstOrDefault(x => x.ProductType == productType);
            }
        }
    }
}
