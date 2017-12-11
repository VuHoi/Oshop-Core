using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToiLaHoi.Core;
using ToiLaHoi.Model;
using ToiLaHoi.Model.Context;

namespace ToiLaHoi.Persistence
{
    public class ProductRepository : IProductRepository
    {

        private readonly OshopContext _context;
        public ProductRepository(OshopContext context)
        {
            this._context = context;
        }

        public async Task<Product> GetProductID(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Products.FindAsync(id);

            return await _context.Products.Include(c => c.Categories)

                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
           

            return await _context.Products.Include(c => c.Categories)

                .ToListAsync();
        }



        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

    }
}
