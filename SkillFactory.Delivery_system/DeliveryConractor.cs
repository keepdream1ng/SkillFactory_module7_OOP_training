using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public abstract class DeliveryConractor : Contributor
    {
        public UnitStatus Status { get; protected set; }

        public void DeliverPackage(string adress)
        {

            foreach (Order<Delivery> order in Orders)
            {
                if (order.Status != OrderStatus.Cancelled)
                {
                    Thread.Sleep(Estimations.Time(order.ToString()));
                    WorldMap.One[adress].Orders.Add(order);
                    if (order.Owner.Name == WorldMap.One[adress].Name)
                    {
                        order.Status = OrderStatus.Delivered;
                    }
                    this.Orders.Remove(order);
                }
            }
            if (this.Orders.Count == 0)
            {
                Status = UnitStatus.Returning;
            }
        }
    }
}
