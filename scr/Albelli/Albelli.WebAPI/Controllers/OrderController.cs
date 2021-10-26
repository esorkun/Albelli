using Albelli.BLL;
using Albelli.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albelli.WebAPI.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private Albelli.BLL.OrderManager _orderManagerBLL;
        public OrderController()
        {
            _orderManagerBLL = new Albelli.BLL.OrderManager();
        }

        [HttpGet]
        [Route("getAllOrders")]
        public List<Order> GetAllOrders()
        {
            return _orderManagerBLL.GetAllOrders();
        }

        [HttpPost]
        [Route("createOrder")]
        public Order CreateOrder([FromBody] Order newOrder)
        {
            Order storedOrder = _orderManagerBLL.CreateOrder(newOrder);
            return storedOrder;
        }

    }
}
