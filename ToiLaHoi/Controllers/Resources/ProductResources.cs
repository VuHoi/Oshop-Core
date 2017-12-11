using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Controllers.Resources
{
    public class ProductResources
    {


        public int Id { get; set; }
        public CategoryResources Categories { get; set; }
       
     
        public int Price { get; set; }
        public string ImageUrl { get; set; }
      
        public string Title { get; set; }
    }
}
