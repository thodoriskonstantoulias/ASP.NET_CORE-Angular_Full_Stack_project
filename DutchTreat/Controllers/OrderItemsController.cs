﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/orders/{orderid}/items")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : ControllerBase
    {
        private readonly IDutchRepository context;
        private readonly ILogger<ProductsController> logger;
        private readonly IMapper mapper;

        public OrderItemsController(IDutchRepository context, ILogger<ProductsController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get(int orderId)          
        {
            var username = User.Identity.Name;
            //var order = context.GetOrderById(orderId);
            var order = context.GetOrderById(username,orderId);
            if (order != null)
            {
                return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var username = User.Identity.Name;
            var order = context.GetOrderById(username,orderId);
            if (order != null)
            {
                var item = order.Items.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                { 
                    return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
            }
            return NotFound();
        }
    }
}