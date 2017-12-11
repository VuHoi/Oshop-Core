using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Model;

namespace ToiLaHoi.Core
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categories>> GetCategory();

    }
}
