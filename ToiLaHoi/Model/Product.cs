using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Model
{
    public class Product
    {
        public int  Id { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesId { get; set; }
        [Required]
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }


    }
}
