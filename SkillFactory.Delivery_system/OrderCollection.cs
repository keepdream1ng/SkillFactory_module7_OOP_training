using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class OrderCollection
    {
        public Queue<Object> OrderQueue;
        public List<Object> OrderOrderArchive;

        /// <summary>
        /// One is the only instance of class we need in this case.
        /// </summary>
        public static OrderCollection One
        {
            get
            {
                if ( One == null )
                {
                    One = new OrderCollection();
                }
                return One;
            }
            private set
            {
                One = value;
            }
        }
    }
}
