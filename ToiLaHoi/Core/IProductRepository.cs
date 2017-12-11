using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Model;

namespace ToiLaHoi.Core
{
    public interface IProductRepository
    {
        Task<Product> GetProductID(int id, bool includeRelated = true);
        Task<IEnumerable<Product>> GetProduct();
        void Add(Product product);
        void Remove(Product product);

    }
}
