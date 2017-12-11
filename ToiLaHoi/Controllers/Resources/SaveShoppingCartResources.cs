using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ToiLaHoi.Controllers.Resources
{
    public class SaveShoppingCartResources
    {
        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public ICollection<SaveCartResources> Carts { get; set; }

        public int UserId { get; set; }
      
        public SaveShoppingCartResources()
        {
            Carts = new Collection<SaveCartResources>();
        }



    }
}
