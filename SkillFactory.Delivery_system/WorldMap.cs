using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class WorldMap
    {
        public List<Contributor> contributors = new List<Contributor>();
        private static WorldMap _one;
        /// <summary>
        /// One is the only instance of class we need in this case.
        /// </summary>
        public static WorldMap One
        {
            get
            {
                if ( _one == null )
                {
                    _one = new WorldMap();
                }
                return _one;
            }
        }

        public Contributor this[string adress]
        {
            get
            {
                foreach (Contributor contributor in contributors)
                {
                    if (contributor.Adress == adress)
                    {
                        return contributor;
                    }
                }
                return null;
            }
        }
    }
}
