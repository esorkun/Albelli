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

            var _configProducts = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductModel>().ReverseMap());
            _productMapper = new Mapper(_configProducts);
        }

        public ProductModel GetProductByName(string productType)
        {
            Product productsDAL = _DAL_Products.GetProductByProductType(productType);

            //if (null == productsDAL)
            //    throw new InvalidOperationException(String.Format("Invalid Product Type : {0}",
            //             productType));


            ProductModel productDAL = _productMapper.Map<Product, ProductModel>(productsDAL);
            return productDAL;
        }
    }
}
