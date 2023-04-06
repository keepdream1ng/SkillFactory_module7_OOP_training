using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Courier : DeliveryConractor
    {
        public void TakeDelivery(string adress)
        {
            Orders.Add(Warehouse.First.ShipOrder(adress));
            Status = UnitStatus.Delivering;
        }
    }
}
