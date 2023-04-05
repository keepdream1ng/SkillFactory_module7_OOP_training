using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Warehouse
    {
        public WarehouseStatus Status { get; private set; }
        public List<Order<Delivery>> ReadyToShip = new List<Order<Delivery>>();

        private static Warehouse _first;
        /// <summary>
        /// First is the only instance of class we need (for now).
        /// </summary>
        public static Warehouse First
        {
            get
            {
                if ( _first == null )
                {
                    _first = new Warehouse();
                }
                return _first;
            }
        }

        public Order<Delivery> this[string adress]
        {
            get
            {
                foreach (Order<Delivery> o in ReadyToShip)
                {
                    if (o.Delivery.Address == adress )
                    {
                        return o;
                    }
                }
                return null;
            }
        }

        public Warehouse()
        {
            Status = WarehouseStatus.Waiting;
        }

        public void PrepareOrder(Order<Delivery> order )
        {
            if (order.Status != OrderStatus.Cancelled)
            {
                this.Status = WarehouseStatus.Collecting;
                order.Status = OrderStatus.Collecting;
                // I didnt wanted to just do random wait even for study project, so the
                // time estimation can be rewriten to actually estimate stuff.
                foreach (Product p in order.OrderPackage)
                {
                    Thread.Sleep(Estimations.Time(p.ToString()));
                }
                ReadyToShip.Add(order);
                this.Status = WarehouseStatus.Waiting;
                order.Status = OrderStatus.Awaiting;
            }
        }

        public Order<Delivery> ShipOrder(string adress)
        {
            Order<Delivery> order = Warehouse.First[adress];
            if ((order != null) && (order.Status != OrderStatus.Cancelled))
            {
                this.Status = WarehouseStatus.Unloading;
                order.Status = OrderStatus.Shipment;
                ReadyToShip.Remove(order);
                Thread.Sleep (Estimations.Time(order.ToString()));
                this.Status = WarehouseStatus.Waiting;
                return order;
            }
            return null;
        }

        public List<Order<Delivery>> ShipMultibleOrders(string adress)
        {
            var ordersList = new List<Order<Delivery>>();
            while (Warehouse.First[adress] != null)
            {
                ordersList.Add(ShipOrder(adress));
            }
            return ordersList;
        }
    }
}
