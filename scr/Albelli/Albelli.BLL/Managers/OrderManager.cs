using Albelli.BLL.Models;
using Albelli.BLL.Managers;
using Albelli.DAL.Managers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Albelli.DAL.Entities;

namespace Albelli.BLL
{
    public class OrderManager
    {
        private Albelli.DAL.Managers.ClientOrderManagerDAL _DAL_Orders;
        private OrderItemManager orderItemManager;
        private ProductManager productManager;
        private Mapper _orderMapper;

        public OrderManager()
        {
            _DAL_Orders = new ClientOrderManagerDAL();

            orderItemManager = new OrderItemManager();
            productManager = new ProductManager();

            var _configOrder = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, ClientOrder>().ForMember(dest => dest.OrderItem, opt => opt.Ignore()).ReverseMap());
            _orderMapper = new Mapper(_configOrder);

        }

        private OrderModel FillOrderWithItems(OrderModel order)
        {
            // Get orderItems of the order
            order.OrderItem = orderItemManager.GetOrderItemsByOrderId(order.Id);

            // Get products of the order item
            order.OrderItem.Select(x => { x.Product = productManager.GetProductById(x.Product.Id); return x; }).ToList();

            // Set productTypes of the order
            order.OrderItem.ToList().ForEach(o => { o.ProductType = o.Product.ProductType; });

            return order;
        }



        public OrderModel GetOrderById(int orderId)
        {
            ClientOrder orderFromDB = _DAL_Orders.GetOrderById(orderId);
            OrderModel order = _orderMapper.Map<ClientOrder, OrderModel>(orderFromDB);

            // Fill order information with items (OrderItem and Product Info)
            FillOrderWithItems(order);

            return order;
        }

        public List<OrderModel> GetAllOrders()
        {
            List<ClientOrder> ordersFromDB = _DAL_Orders.GetAllClientOrders();
            List<OrderModel> ordersList = _orderMapper.Map<List<ClientOrder>, List<OrderModel>>(ordersFromDB);

            ordersList.ToList().ForEach(x => FillOrderWithItems(x));

            return ordersList;
        }

        public OrderModel CheckOrderExistById(int orderId)
        {
            ClientOrder orderFromDB = _DAL_Orders.GetOrderById(orderId);
            OrderModel order = _orderMapper.Map<ClientOrder, OrderModel>(orderFromDB);

            return order;
        }




        public OrderModel CreateOrder(OrderModel orderRequest)
        {
            // Validation : Check if the order Id valid
            if (null != CheckOrderExistById(orderRequest.Id))
                throw new InvalidOperationException("This order is already exists. Please change the OrderId.");

            // Validation : Check if the quantities valid
            if (orderRequest.OrderItem.Any(x => x.Quantity <= 0))
                throw new InvalidOperationException("Invalid quantity.");

            // Get Products of the orderItems from DB. 
            orderRequest.OrderItem.Select(x => { x.Product = productManager.GetProductByName(x.ProductType); return x; }).ToList();

            // Validation : If any of the products are not on the list, then return "Bad Request" message.
            if (orderRequest.OrderItem.Any(x => x.Product == null))
                throw new InvalidOperationException("Invalid product type.");

            orderRequest.CalculateRequiredBinWidth();

            // Create ClientOrder record
            ClientOrder clientOrder = _orderMapper.Map<OrderModel, ClientOrder>(orderRequest);
            _DAL_Orders.CreateOrder(clientOrder);

            // Create OrderItem record
            foreach (var item in orderRequest.OrderItem)
            {
                //item.ProductId = item.Product.Id;
                item.ClientOrderId = orderRequest.Id;
                orderItemManager.CreateOrderItem(item);
            }

            return orderRequest;
        }
    }
}
