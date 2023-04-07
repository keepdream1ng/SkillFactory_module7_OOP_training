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
            // Here is some test code, i think i spent way too much time writing out whole system - new module just opened.
            var Prod1 = new Product("prod1");
            var Prod2 = new Product("prod2");
            Product[] products = new Product[] { Prod1, Prod2 };
            Client Client1 = new Client() { Name = "Mike", Adress = "too space", Id = 1, ClosestPickpoint = "Pickpoint Lane 1", ClosestShop = "Shop Lane 1" };
            Console.WriteLine($"{Client1} is created!");
            WorldMap.One.contributors.Add(Client1);
            Courier Courier1 = new Courier() { Name = "Chad", Adress = "non of your business", Id = 2, Status = UnitStatus.Waiting};
            WorldMap.One.contributors.Add(Courier1);
            Console.WriteLine($"{Courier1} is created!");
            Client1.CreateOrder(products, DeliveryType.HomeDelivery);
            Client1.CheckOrders();
            // Order is taken from queue and processed.
            var ProcessingOrder = OrderCollection.One.GiveOrder();
            Warehouse.First.PrepareOrder(ProcessingOrder);
            Client1.CheckOrders();
            ProcessingOrder.Delivery.StartDelivery();
            Client1.CheckOrders();

            // Now test for Pickpoint option.
            DeliveryPoint Pickpoint1 = new PickPoint() { Name = "Go get your stuff", Adress = Client1.ClosestPickpoint, Id = 3};
            Console.WriteLine($"{Pickpoint1} is created!");
            WorldMap.One.contributors.Add(Pickpoint1);
            ShippingUnit ShippingUnit1 = new ShippingUnit() { Name = "ChadCorp", Adress = "non of your business", Id = 4, Status = UnitStatus.Waiting};
            Console.WriteLine($"{ShippingUnit1} is created!");
            WorldMap.One.contributors.Add(ShippingUnit1);
            Client1.CreateOrder(products, DeliveryType.PickPointDelivery);
            Client1.CheckOrders();
            ProcessingOrder = OrderCollection.One.GiveOrder();
            Warehouse.First.PrepareOrder(ProcessingOrder);
            Client1.CheckOrders();
            ProcessingOrder.Delivery.StartDelivery();
            Client1.CheckOrders();
            Pickpoint1.NotifyClient(ProcessingOrder);
            Console.WriteLine($"{Pickpoint1.Orders.Count} order is ready at PickPoint");

            // Now test for Shop delivery.
            Shop Shop1 = new Shop() { Name = "Buy stuff here", Adress = Client1.ClosestShop, Id = 5 };
            Console.WriteLine($"{Shop1} is created!");
            WorldMap.One.contributors.Add(Shop1);
            Client1.CreateOrder(products, DeliveryType.ShopDelivery);
            Client1.CheckOrders();
            ProcessingOrder = OrderCollection.One.GiveOrder();
            Warehouse.First.PrepareOrder(ProcessingOrder);
            Client1.CheckOrders();
            ProcessingOrder.Delivery.StartDelivery();
            Client1.CheckOrders();
            Shop1.NotifyClient(ProcessingOrder);
            Console.WriteLine($"{Shop1.Orders.Count} order is ready at Shop");


            Console.ReadKey();
        }
    }
}