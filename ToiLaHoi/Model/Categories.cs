using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Model
{
    public class Categories
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Native { get; set; }
        public int Id { get; set; }
    }
}
