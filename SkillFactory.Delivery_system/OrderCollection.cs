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

        public Order<Delivery> GiveOrder() 
        {
            return OrderCollection.One.OrderQueue.Dequeue();
        }
        
        /// <summary>
        /// Method returns order status by taking its number.
        /// </summary>
        public string TrackOrder( int number )
        {
            return OrderCollection.One[number].ToString();
        }

        /// <summary>
        /// Method returns orders status by taking their owner's name.
        /// </summary>
        public string TrackOrder( string name )
        {
            int i = 0;
            string result = string.Empty;
            foreach ( Order<Delivery> o in OrderCollection.One.OrderArchive )
            {
                if ( o.Owner.Name == name )
                {
                    if (i != 0) result += "\n";
                    i++;
                    result += o.ToString();
                }
            }
            return result;
        }
    }
}
