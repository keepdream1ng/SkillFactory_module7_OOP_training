using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class OrderCollection
    {
        public Queue<Order<Delivery>> OrderQueue;
        public List<Order<Delivery>> OrderArchive;

        private static OrderCollection _one;
        /// <summary>
        /// One is the only instance of class we need in this case.
        /// </summary>
        public static OrderCollection One
        {
            get
            {
                if ( _one == null )
                {
                    _one = new OrderCollection();
                }
                return _one;
            }
        }

        public Order<Delivery> this[int number]
        {
            get
            {
                foreach (Order<Delivery> o in OrderArchive )
                {
                    if (o.Number == number )
                    {
                        return o;
                    }
                }
                return null;
            }
        }

        public Order<Delivery> this[string name]
        {
            get
            {
                foreach (Order<Delivery> o in OrderArchive)
                {
                    if ( o.Owner.Name == name )
                    {
                        return o;
                    }
                }
                return null;
            }
        }

        public Order<Delivery> GiveOrder() 
        {
            return OrderCollection.One.OrderQueue.Dequeue();
        }


    }
}
