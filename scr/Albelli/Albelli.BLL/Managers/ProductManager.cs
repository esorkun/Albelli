using Albelli.BLL.Models;
using Albelli.DAL;
using Albelli.DAL.Entities;
using Albelli.DAL.Managers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albelli.BLL.Managers
{
    public class ProductManager
    {
        private Albelli.DAL.Managers.ProductManagerDAL _DAL_Products;
        private Mapper _productMapper;

        public ProductManager()
        {
            _DAL_Products = new ProductManagerDAL();

            var _configProducts = new MapperConfiguration(cfg => cfg.CreateMap<Products, Product>().ReverseMap());
            _productMapper = new Mapper(_configProducts);
        }

        public Product GetProductByName(string productType)
        {
            Products productsDAL = _DAL_Products.GetProductByName(productType);
            Product productDAL = _productMapper.Map<Products, Product>(productsDAL);
            return productDAL;
        }
    }
}
