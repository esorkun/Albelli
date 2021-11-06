using Albelli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Albelli.DAL.Managers
{
    public class ProductManagerDAL
    {
        public Product GetProductByProductType(string productType)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.Product.FirstOrDefault(x => x.ProductType == productType);
            }
        }

        public Product GetProductById(int productId)
        {
            using (var dbContext = new AlbelliDbContext())
            {
                return dbContext.Product.FirstOrDefault(x => x.Id == productId);
            }
        }
    }
}
