using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Order<TDelivery> where TDelivery : Delivery
    {
        private static int _count = 0;
        public int Number { get; private set; }
        public string Description { get => this.ToString(); }
        public OrderStatus Status;

        public Client Owner;
        public TDelivery Delivery;
        public Product[] OrderPackage;

        public Order(Client owner, Product[] orderPackage, TDelivery delivery)
        {
            Number = ++_count;
            Status = OrderStatus.Pending;
            Owner = owner;
            Delivery = delivery;
            OrderPackage = orderPackage;
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        public override string ToString()
        {
            return $"Order #{Number} from {Owner.ToString} delivery adress {Delivery.Address} is {Status}.";
        }
    }
}
