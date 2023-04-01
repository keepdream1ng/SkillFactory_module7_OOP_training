using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory.Delivery_system
{
    public class Product
    {
        private static int _count = 0;
        public int Id;
        
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public bool IsReturned { get; set; }

        public Product(string name, int quantity = 1)
        {
            Id = ++_count;
            Name = name;
            Quantity = quantity;
            IsReturned = false;
        }

        public override string ToString()
        {
            return $"Id{Id}_{Name}x{Quantity}{( IsReturned ? "_Returned" : String.Empty )}";
        }
    }
}
