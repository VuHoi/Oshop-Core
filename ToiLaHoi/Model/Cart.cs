using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Model
{

    [Table("Carts")]
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        [StringLength(255)]
       
        public int Quantity { get; set; }
       
        public ShoppingCart ShoppingCart { get; set; }
        [Required]
        [StringLength(255)]
        public int ShoppingCartID { get; set; }
    }
}
