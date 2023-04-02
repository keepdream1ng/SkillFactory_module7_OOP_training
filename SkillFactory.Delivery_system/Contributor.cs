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
        public int Id { get; }
        public string Name { get; private set; }

        protected string Adress { get; private set; }

        protected string ContactInfo { get; private set; }

        public override string ToString()
        {
            return $"{Name} Contact: {ContactInfo}";
        }
    }
}
