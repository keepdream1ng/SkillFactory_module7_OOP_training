using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class DeliveryPoint : Contributor
    {
        public void NotifyClient(Order<Delivery> order)
        {
            if ( (order != null) && (order.Status != OrderStatus.Cancelled) )
            {
                order.Owner.Messages.Add(order.ToString());
            }
        }
    }
}
