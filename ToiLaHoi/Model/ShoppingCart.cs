using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public ICollection<Cart> Carts { get; set; }
        [Required]
        [StringLength(50)]
        public int UserId { get; set; }
        public User User { get; set; }
        public ShoppingCart()
        {
            Carts=new Collection<Cart>();
        }

    }
}
