using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Model;

namespace ToiLaHoi.Core
{
    public interface IUserRepository
    {
        Task<User> GetUserId(int id, bool includeRelated = true);
       
        void Add(User user);
        void Remove(User user);


    }
}
