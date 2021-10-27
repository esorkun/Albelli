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
        private Albelli.DAL.Managers.ClientOrderManagerDAL _DAL_Orders;
        private Mapper _orderMapper;

        public OrderManager()
        {
            _DAL_Orders = new ClientOrderManagerDAL();

            var _configOrder = new MapperConfiguration(cfg => cfg.CreateMap<ClientOrder, OrderModel>().ReverseMap());
            _orderMapper = new Mapper(_configOrder);
        }

        public List<OrderModel> GetAllOrders()
        {
            List<ClientOrder> ordersFromDB = _DAL_Orders.GetAllOrders();
            List<OrderModel> ordersList = _orderMapper.Map<List<ClientOrder>, List<OrderModel>>(ordersFromDB);

            return ordersList;
        }

        public OrderModel GetOrderById(int orderId)
        {
            ClientOrder orderFromDB = _DAL_Orders.GetOrderById(orderId);
            OrderModel ordersList = _orderMapper.Map<ClientOrder,OrderModel>(orderFromDB);

            return ordersList;
        }

        public OrderModel CreateOrder(OrderModel orderRequest)
        {
            ProductManager productManager = new ProductManager();
            OrderItemManager orderItemManager = new OrderItemManager();
            OrderBagManager orderBagManager = new OrderBagManager();

            // Get Products from DB for all OrderItems
            orderRequest.OrderItems.Select(x => { x.Product = productManager.GetProductByName(x.ProductType); return x; }).ToList();

            orderRequest.OrderItems.Select(x => { x.ProductId = x.Product.Id; return x; }).ToList();

            orderRequest.CalculateRequiredBinWidth();

            ClientOrder newOrders = _orderMapper.Map<OrderModel, ClientOrder>(orderRequest);

            ClientOrder order = _DAL_Orders.CreateOrder(newOrders);
            orderRequest.Id = order.Id;

            foreach (var orderItem in orderRequest.OrderItems)
            {
                OrderItemModel recordedOrderItem = orderItemManager.CreateOrderItem(orderItem);

                OrderBagModel newOrderBag = new OrderBagModel(orderRequest, recordedOrderItem);
                OrderBag recordedOrderBag = orderBagManager.CreateOrderBag(newOrderBag);
            }

            return orderRequest;
        }
    }
}
