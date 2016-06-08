using System;
using System.Collections.Generic;

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
        public uint Amount { get; set; }
        public virtual  ICollection<Product> Products { get; set; }

    }
}
