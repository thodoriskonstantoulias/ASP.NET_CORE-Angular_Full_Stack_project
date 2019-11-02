using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDutchRepository context;
        private readonly ILogger<ProductsController> logger;

        public OrdersController(IDutchRepository context, ILogger<ProductsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(context.GetAllOrders());
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get orders{ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = context.GetOrderById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get order{ex}");
                return BadRequest("Failed to get order");
            }
        }
    }
}