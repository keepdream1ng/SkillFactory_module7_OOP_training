using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Contributor
    {
        private int _count;
        public int Id { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }

        protected string ContactInfo { get; set; }

        public List<Order<Delivery>> Orders = new List<Order<Delivery>>();
        
        public override string ToString()
        {
            return $"{this.GetType().Name} {Name}";
        }
    }
}
