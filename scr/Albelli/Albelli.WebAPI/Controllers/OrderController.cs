﻿using Albelli.BLL;
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
        public List<OrderModel> GetAllOrders()
        {
            return _orderManagerBLL.GetAllOrders();
        }

        [HttpGet]
        [Route("getOrderById/{orderId}")]
        public OrderModel GetOrderById(int orderId)
        {
            return _orderManagerBLL.GetOrderById(orderId);
        }

        [HttpPost]
        [Route("createOrder")]
        public ActionResult<OrderModel> CreateOrder([FromBody] OrderModel newOrder)
        {
            try
            {
                OrderModel order = _orderManagerBLL.CreateOrder(newOrder);
                return Ok(order);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
