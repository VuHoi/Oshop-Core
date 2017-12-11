using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Model
{
    public class User
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Pass { get; set; }
        public bool IsAdmin { get; set; }
        public int  Id { get; set; }
    }
}
