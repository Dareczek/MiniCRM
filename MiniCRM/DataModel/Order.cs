using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    enum State : byte
    {
        Przyjete,
        Kompletowane,
        Wyslane,
        Zrealizowane
    };
    class Order
    {
        public uint Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool Paid { get; set; }
        public State Status { get; set; }
        public Product Product  { get; set; }
        public uint Amount { get; set; }

    }
}
