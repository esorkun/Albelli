using Albelli.BLL.Models;
using Albelli.DAL.Entities;
using Albelli.DAL.Managers;
using AutoMapper;
using System.Collections.Generic;

namespace Albelli.BLL.Managers
{
    public class OrderItemManager
    {
        private Albelli.DAL.Managers.OrderItemManagerDAL _DAL_OrderItem;
        private Mapper _orderItemMapper;

        public OrderItemManager()
        {
            _DAL_OrderItem = new OrderItemManagerDAL();

            var _configOrderItem = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemModel, OrderItem>()
            .ForMember(dest => dest.Product, opt => opt.Ignore())
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(x=>x.Product.Id))
            .ForMember(dest => dest.ClientOrderId, opt => opt.MapFrom(x => x.ClientOrderId))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap());
            _orderItemMapper = new Mapper(_configOrderItem);
        }

        public OrderItemModel CreateOrderItem(OrderItemModel orderItem)
        {
            OrderItem neworderItem = _orderItemMapper.Map<OrderItemModel, OrderItem>(orderItem);
            OrderItem recordedorderItem = _DAL_OrderItem.CreateOrderItem(neworderItem); 
            OrderItemModel recordedorderItemModel = _orderItemMapper.Map<OrderItem, OrderItemModel>(recordedorderItem);

            return recordedorderItemModel;
        }

        public List<OrderItemModel> GetOrderItemsByOrderId(int orderId)
        {
            List<OrderItem> orderItemsFromDB = _DAL_OrderItem.GetOrderItemsByOrderId(orderId);
            List<OrderItemModel> orderItemList = _orderItemMapper.Map<List<OrderItem>, List<OrderItemModel>>(orderItemsFromDB);

            return orderItemList;
        }
    }
}
