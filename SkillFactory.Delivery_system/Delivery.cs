using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public abstract class Delivery
    {
        public string Address;

        public Delivery( string address )
        {
            Address = address;
        }

        public abstract void StartDelivery();

        public TContractor PickContractor<TContractor>(UnitStatus status) where TContractor : DeliveryConractor
        {
            foreach (Contributor contributor in WorldMap.One.contributors)
            {
                if (contributor.GetType() == typeof(TContractor))
                {
                    var courier = (TContractor)contributor;
                    if (courier.Status == status)
                    {
                        return courier;
                    }
                }
            }
            return null;
        }
    }
}
