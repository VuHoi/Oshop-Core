using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Core;
using ToiLaHoi.Model.Context;

namespace ToiLaHoi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OshopContext _context;

        public UnitOfWork(OshopContext context)
        {
            this._context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
