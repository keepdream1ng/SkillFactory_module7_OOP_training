using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Shop : DeliveryPoint 
    {
        public List<Product> ReturnedProducts = new List<Product>();

        public override string ToString()
        {
            return $"Shop {Name} with an address {Adress}";
        }
    }
}
