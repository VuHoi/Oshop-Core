using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToiLaHoi.Model;

namespace ToiLaHoi.Controllers.Resources
{
    public class CartResources
    {

        public int Id { get; set; }
       
        public ProductResources Product { get; set; }
     

        public int Quantity { get; set; }

      
    }
}
