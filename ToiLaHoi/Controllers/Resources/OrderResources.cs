using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Controllers.Resources
{
    public class OrderResources
    {

        public DateTime DatePlaced { get; set; }

        public ProductResources Product { get; set; }
        public int ProductId { get; set; }
      
        public string Address { get; set; }

        public string City { get; set; }
         
        public string Name { get; set; }

        public int UserId { get; set; }
        public UserResources User { get; set; }
    }
}
