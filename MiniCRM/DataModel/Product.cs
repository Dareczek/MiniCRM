using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Product
    {
        [Key]
        public uint ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public uint Amount { get; set; }

        public uint OrderId { get; set; }
        public virtual Order Order { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}
