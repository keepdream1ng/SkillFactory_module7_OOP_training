using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class PickPointDelivery : Delivery
    {
        private ShippingUnit _pickedShippingUnit;
        public ShippingUnit PickedShippingUnit
        {
            get
            {
                if (_pickedShippingUnit == null)
                {
                    return _pickedShippingUnit = PickAvailable<ShippingUnit>();
                }
                return _pickedShippingUnit;
            }
        }

        public PickPointDelivery(string adress) : base(adress)
        {
        }

        public override void StartDelivery()
        {
            PickedShippingUnit.StartShipment(Address);
            PickedShippingUnit.DeliverPackage(Address);
        }

        public override string ToString()
        {
            return $"Delivery to {Address}, with contractor {PickedShippingUnit.Id}";
        }
    }
}
