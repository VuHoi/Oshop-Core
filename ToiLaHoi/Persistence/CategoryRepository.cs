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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OshopContext _context;
        public CategoryRepository(OshopContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Categories>> GetCategory()
        {
            return await _context.Categories.ToListAsync(); 
        }
    }
}
