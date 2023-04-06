﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Client : Contributor
    {
        private string ClosestPickpoint { get; set; }
        private string ClosestShop { get; set; }

        public List<string> Messages = new List<string>();

        public void CreateOrder(Product[] package, DeliveryType delivery = DeliveryType.HomeDelivery)
        {
            Delivery pickedDelivery = null;
            switch (delivery)
            {
                case DeliveryType.HomeDelivery:
                    {
                        pickedDelivery = new HomeDelivery(Adress);
                        break;
                    }
                case DeliveryType.PickPointDelivery:
                    {
                        pickedDelivery = new PickPointDelivery(ClosestPickpoint);
                        break;
                    }
                case DeliveryType.ShopDelivery:
                    {
                        pickedDelivery = new ShopDelivery(ClosestShop);
                        break;
                    }
            }

            var NewOrder = new Order<Delivery>(this, package, pickedDelivery);
            OrderCollection.One.OrderQueue.Enqueue(NewOrder);
            OrderCollection.One.OrderArchive.Add(NewOrder);
        }

        private void CancelOrder(int number)
        {
            OrderCollection.One[number].Status = OrderStatus.Cancelled;
        }

        private void CheckOrders()
        {
            Console.WriteLine(OrderCollection.One.TrackOrder(Name));
        }
    }
}
