using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Client : Contributor
    {
        private List<Order<Delivery>> MyOrders = new List<Order<Delivery>>();
        private string ClosestPickpoint { get; set; }
        private string ClosestShop { get; set; }

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
            MyOrders.Add(NewOrder);
            OrderCollection.One.OrderQueue.Enqueue(NewOrder);
            OrderCollection.One.OrderArchive.Add(NewOrder);
        } 
    }
}
