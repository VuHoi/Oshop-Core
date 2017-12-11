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
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        private readonly OshopContext _context;
        public ShoppingCartRepository(OshopContext context)
        {
            this._context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartId(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.ShoppingCarts.FindAsync(id);

            return await _context.ShoppingCarts.Include(c => c.Carts).ThenInclude(p=>p.Product).Include(u=>u.User)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public async Task<IEnumerable<ShoppingCart>> GetShoppingCart()
        {


            return await _context.ShoppingCarts.Include(c => c.Carts).ThenInclude(p=>p.Product).Include(u=>u.User)

                .ToListAsync();
        }



        public void Add(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
        }

        public void Remove(ShoppingCart shoppingCart)
        {
            _context.Remove(shoppingCart);
        }



    }
}
