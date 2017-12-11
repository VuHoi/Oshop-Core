using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Model;

namespace ToiLaHoi.Core
{
    public interface IShoppingCartRepository
    {

        Task<ShoppingCart> GetShoppingCartId(int id, bool includeRelated = true);
        Task<IEnumerable<ShoppingCart>> GetShoppingCart();
        void Add(ShoppingCart shoppingCart);
        void Remove(ShoppingCart shoppingCart);


    }
}
