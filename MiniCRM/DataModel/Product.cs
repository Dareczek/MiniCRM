using System.Collections.Generic;

namespace DataModel
{
    class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public uint Amount { get; set; }

        public virtual Order Order { get; set; }
    }
}
