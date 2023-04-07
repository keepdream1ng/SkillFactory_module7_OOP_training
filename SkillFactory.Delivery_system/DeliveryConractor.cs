using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public abstract class DeliveryConractor : Contributor
    {
        public UnitStatus Status { get; set; }

        public void DeliverPackage(string adress)
        {

            foreach (Order<Delivery> order in Orders)
            {
                if (order.Status != OrderStatus.Cancelled)
                {
                    Thread.Sleep(Estimations.Time(order.ToString()));
                    order.Status = OrderStatus.Delivered;
                    WorldMap.One[adress].Orders.Add(order);
                }
            }
            Orders.Clear();
            Status = UnitStatus.Returning;
        }
    }
}
