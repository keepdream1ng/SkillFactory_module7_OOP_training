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
                    return _pickedCourier = PickAvailable<Courier>();
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
