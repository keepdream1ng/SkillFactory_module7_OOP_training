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
            Console.WriteLine("Hello, World!");
            var Prod1 = new Product("prod1");
            var Prod2 = new Product("prod2");
            Product[] products = new Product[] { Prod1, Prod2 };
            var MyOrder = new Order<HomeDelivery>(new Client(), products);
            MyOrder.Delivery = new HomeDelivery(); 
        }
    }
}