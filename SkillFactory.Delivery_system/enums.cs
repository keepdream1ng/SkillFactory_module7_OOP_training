using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public enum DeliveryType
    {
        HomeDelivery = 0,
        PickUpDelivery,
        ShopDelivery
    }

    public enum Status
    {
        Cancelled = 0,
        Pending,
        Collecting,
        Shipment,
        Awaiting,
        Delivered
    }
}
