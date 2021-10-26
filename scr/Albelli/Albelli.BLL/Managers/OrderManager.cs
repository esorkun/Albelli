using Albelli.BLL.Models;
using Albelli.BLL.Managers;
using Albelli.DAL.Managers;
using Albelli.DAL;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albelli.DAL.Entities;

namespace Albelli.BLL
{
    public class OrderManager
    {
        private Albelli.DAL.Managers.OrderManagerDAL _DAL_Orders;
        private Mapper _orderMapper;

        public OrderManager()
        {
            _DAL_Orders = new OrderManagerDAL();

            var _configOrder = new MapperConfiguration(cfg => cfg.CreateMap<Orders, Order>().ReverseMap());
            _orderMapper = new Mapper(_configOrder);
        }

        public List<Order> GetAllOrders()
        {
            List<Orders> ordersFromDB = _DAL_Orders.GetAllOrders();
            List<Order> ordersList = _orderMapper.Map<List<Orders>, List<Order>>(ordersFromDB);

            return ordersList;
        }

        public Order CreateOrder(Order orderRequest)
        {

            foreach (OrderItem orderItemRequest in orderRequest.OrderItems)
            {
                ProductManager productManager = new ProductManager(); 
                Product selectedProduct = productManager.GetProductByName(orderItemRequest.ProductType);

                orderItemRequest.Product = selectedProduct;
            }

            orderRequest.CalculateRequiredBinWidth();

            Orders newOrders = _orderMapper.Map<Order, Orders>(orderRequest);


            Orders orders = _DAL_Orders.CreateOrder(newOrders);
            orderRequest.Id = orders.Id;

            return orderRequest;
        }
    }
}
