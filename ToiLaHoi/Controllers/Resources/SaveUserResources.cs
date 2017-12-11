using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Controllers.Resources
{
    public class SaveUserResources
    {
      
        public string Email { get; set; }
        
        public string Name { get; set; }
        
        public string Pass { get; set; }
        public bool IsAdmin { get; set; }
        public int Id { get; set; }

    }
}
