using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext ctx;

        public DutchRepository(DutchContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems) { 
            return ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(p =>p.Product)
                  .ToList();
            }
            else
            {
                return ctx.Orders
                  .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ctx.Products.OrderBy(x => x.Title).ToList();
        }

        public Order GetOrderById(int id)
        {
            return ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(p => p.Product)
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products.Where(x => x.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0 ;
        }
    }
}
