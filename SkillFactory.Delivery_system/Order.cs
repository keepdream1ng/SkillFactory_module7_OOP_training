using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    class Order<TDelivery> where TDelivery : Delivery
    {
        private static int _count = 0;
        public int Number { get; private set; }
        public string Description { get => this.ToString(); }
        public Status Status;

        public Client Owner;
        public TDelivery Delivery;
        public Product[] OrderPackage;

        public Order(Client owner, Product[] orderPackage)
        {
            Number = ++_count;
            Status = Status.Pending;
            Owner = owner;
            OrderPackage = orderPackage;
            // I couldnt find at a glance option to include different Delivery objects inside the constructor,  
            // so the Delivery field will be added to the object in CreateOrder() method.
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }
}
