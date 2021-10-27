using Albelli.BLL.Models;
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
    public class OrderItemManager
    {
        private Albelli.DAL.Managers.OrderItemManagerDAL _DAL_OrderItem;
        private Mapper _orderItemMapper;

        public OrderItemManager()
        {
            _DAL_OrderItem = new OrderItemManagerDAL();

            var _configOrderItem = new MapperConfiguration(cfg => cfg.CreateMap<OrderItem, OrderItemModel>().ReverseMap());
            _orderItemMapper = new Mapper(_configOrderItem);
        }

        public OrderItemModel CreateOrderItem(OrderItemModel orderItem)
        {
            OrderItem neworderItem = _orderItemMapper.Map<OrderItemModel, OrderItem>(orderItem);
            OrderItem recordedorderItem = _DAL_OrderItem.CreateOrderItem(neworderItem); 
            OrderItemModel recordedorderItemModel = _orderItemMapper.Map<OrderItem, OrderItemModel>(recordedorderItem);

            return recordedorderItemModel;
        }
    }
}
