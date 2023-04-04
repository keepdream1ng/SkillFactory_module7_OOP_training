using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public abstract class Delivery
    {
        public string Address;

        public Delivery( string address )
        {
            Address = address;
        }
    }
}
