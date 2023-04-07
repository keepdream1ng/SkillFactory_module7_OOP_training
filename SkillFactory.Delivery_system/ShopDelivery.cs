using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class ShopDelivery : Delivery
    {
        public ShopDelivery(string address) : base(address)
        {
        }

        public override void StartDelivery()
        {
            List<Order<Delivery>> delivery = Warehouse.First.ShipMultibleOrders(Address);
            WorldMap.One[Address].Orders.AddRange(delivery);
            foreach (Order<Delivery> order in delivery)
            {
                order.Status = OrderStatus.Delivered;
            }
        }

        public override string ToString()
        {
            return $"Delivery to shop's adress {Address}";
        }
    }
}
