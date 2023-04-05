using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public abstract class DeliveryConractor : Contributor
    {
        public UnitStatus Status { get; private set; }

        public void DeliverPackage(string adress)
        {

            foreach (Order<Delivery> order in Orders)
            {
                if (order.Status != OrderStatus.Cancelled)
                {
                    Thread.Sleep(Estimations.Time(order.ToString()));
                    WorldMap.One[adress].Orders.Add(order);
                    order.Status = OrderStatus.Delivered;
                    Orders.Remove(order);
                }
            }
            if (this.Orders.Count == 0)
            {
                Status = UnitStatus.Returning;
            }
        }
    }
}
