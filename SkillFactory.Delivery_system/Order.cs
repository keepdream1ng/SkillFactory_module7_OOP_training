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
        }


        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }
}
