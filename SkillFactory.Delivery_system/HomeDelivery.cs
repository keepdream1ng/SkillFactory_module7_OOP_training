using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class HomeDelivery : Delivery
    {
        private Courier _pickedCourier;
        public Courier PickedCourier
        {
            get
            {
                if (_pickedCourier == null)
                {
                    _pickedCourier = PickContractor<Courier>(UnitStatus.Waiting);
                    // If there is no waiting Courier it will pick returning one and so on.
                    if (_pickedCourier == null)
                    {
                        _pickedCourier = PickContractor<Courier>(UnitStatus.Returning);
                    }
                    if (_pickedCourier == null)
                    {
                        _pickedCourier = PickContractor<Courier>(UnitStatus.Delivering);
                    }
                    if (_pickedCourier == null)
                    {
                        _pickedCourier = PickContractor<Courier>(UnitStatus.Off);
                    }
                    return _pickedCourier;
                }
                return _pickedCourier;
            }
        }
        public HomeDelivery(string adress) : base(adress)
        {
        }

        public override void StartDelivery()
        {
            PickedCourier.TakeDelivery(Address);
            PickedCourier.DeliverPackage(Address);
        }

        public override string ToString()
        {
            return $"Delivery to {Address}, with courier {PickedCourier.Id}";
        }
    }

}
