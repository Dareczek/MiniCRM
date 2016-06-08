using System.Collections.Generic;

namespace DataModel
{
    enum YesNo
    {
        Nie,
        Tak
    };

    class Client
    {
        public uint Id { get; set; }    
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public YesNo Active { get; set; }
        public virtual ICollection<ClientOrder> Orders { get; set; }
    }
}
