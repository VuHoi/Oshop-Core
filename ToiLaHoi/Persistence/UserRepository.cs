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
    public class UserRepository : IUserRepository
    {

        private readonly OshopContext _context;
        public UserRepository(OshopContext context)
        {
            this._context = context;
        }
        public void Add(User user)
        {
            _context.User.Add(user);
        }
        public void Remove(User user)
        {
            _context.User.Remove(user);
        }
        public async Task<User> GetUserId(int id, bool includeRelated)
        {
            if (!includeRelated)
                return await _context.User.FindAsync(id);

            return await _context.User
                .SingleOrDefaultAsync(v => v.Id == id);
        }

      
    }
}
