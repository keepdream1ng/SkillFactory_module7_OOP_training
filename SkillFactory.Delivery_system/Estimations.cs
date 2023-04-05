using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public static class Estimations
    {
        private const int _period = 100;
        private static System.Random random = new System.Random();
        private static List<Order<Delivery>> MyList = new List<Order<Delivery>>();
        public static int Time( string key )
        {
            // This functionality can be updated for realistic estimations.
            // For study project its random.
            return _period * random.Next(10, 30);
        }
    }
}
