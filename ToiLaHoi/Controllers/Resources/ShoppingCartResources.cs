using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Threading.Tasks;


namespace ToiLaHoi.Controllers.Resources
{
    public class ShoppingCartResources
    {

        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public ICollection<CartResources> Carts { get; set; }
    
        
        public UserResources User { get; set; }
        public ShoppingCartResources()
        {
            Carts = new Collection<CartResources>();
        }
    }
}
