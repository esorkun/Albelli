using Albelli.BLL.Models;
using Albelli.DAL.Entities;
using Albelli.DAL.Managers;
using AutoMapper;

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

            ProductModel productDAL = _productMapper.Map<Product, ProductModel>(productsDAL);
            return productDAL;
        }

        public ProductModel GetProductById(int productId)
        {
            Product productsDAL = _DAL_Products.GetProductById(productId);

            ProductModel productDAL = _productMapper.Map<Product, ProductModel>(productsDAL);
            return productDAL;
        }
    }
}
