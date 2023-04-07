using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class ShippingUnit : DeliveryConractor
    {
        public void StartShipment(string adress)
        {
            Orders.AddRange(Warehouse.First.ShipMultibleOrders(adress));
            Status = UnitStatus.Delivering;
        }
    }
}
