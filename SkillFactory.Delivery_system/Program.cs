using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Prod1 = new Product("prod1");
            var Prod2 = new Product("prod2");
            Product[] products = new Product[] { Prod1, Prod2 };
            var MyOrder = new Order<Delivery>(new Client(), products, new HomeDelivery());
            OrderCollection.One.OrderArchive.Add(MyOrder);
            Console.WriteLine(OrderCollection.One[1].Description);
        }
    }
}