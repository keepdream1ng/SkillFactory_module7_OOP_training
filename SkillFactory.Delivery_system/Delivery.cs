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

        public TContractor PickAvailable<TContractor>() where TContractor : DeliveryConractor
        {
            TContractor contractor = null;
            contractor = PickContractor<TContractor>(UnitStatus.Waiting);
            // If there is no waiting Courier it will pick returning one and so on.
            if (contractor == null)
            {
                contractor = PickContractor<TContractor>(UnitStatus.Returning);
            }
            if (contractor == null)
            {
                contractor = PickContractor<TContractor>(UnitStatus.Delivering);
            }
            if (contractor == null)
            {
                contractor = PickContractor<TContractor>(UnitStatus.Off);
            }
            return contractor;
        }
    }
}
