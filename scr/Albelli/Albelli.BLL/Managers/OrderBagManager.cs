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
    class OrderBagManager
    {
        private Albelli.DAL.Managers.OrderBagManagerDAL _DAL_OrderBag;
        private Mapper _orderBagMapper;

        public OrderBagManager()
        {
            _DAL_OrderBag = new OrderBagManagerDAL();

            var _configOrderBag= new MapperConfiguration(cfg => cfg.CreateMap<OrderBag, OrderBagModel>().ReverseMap());
            _orderBagMapper = new Mapper(_configOrderBag);
        }

        public OrderBag CreateOrderBag(OrderBagModel orderBag)
        {
            OrderBag newOrderBag = _orderBagMapper.Map<OrderBagModel, OrderBag>(orderBag);
            OrderBag recordedOrderBag = _DAL_OrderBag.CreateOrderBag(newOrderBag);

            return recordedOrderBag;
        }
    }
}
