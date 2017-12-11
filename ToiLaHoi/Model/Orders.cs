using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ToiLaHoi.Model
{
    public class Orders
    {
       
        
        public DateTime DatePlaced { get; set; }
      
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public string City { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public Orders()
        {
          
        }
    }
}
