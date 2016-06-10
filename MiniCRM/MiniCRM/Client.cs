using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public enum YesNo
    {
        Nie,
        Tak
    }

    public class Client
    {
        [Key]
        public uint ClientId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public YesNo Active { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}
