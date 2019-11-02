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
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository context;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IDutchRepository context, ILogger<ProductsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(context.GetAllProducts());
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get products{ex}");
                return BadRequest("Failed to get products");               
            }           
        }


    }
}