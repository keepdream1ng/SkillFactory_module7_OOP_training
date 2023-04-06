using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class PickPoint : DeliveryPoint
    {
        public override string ToString()
        {
            return $"Pickpoint {Name} with an address {Adress}";
        }
    }

}
