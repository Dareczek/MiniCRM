using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public enum State : byte
    {
        Przyjete,
        Kompletowane,
        Wyslane,
        Zrealizowane
    };
    public class Order
    {
        
        public uint OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Paid { get; set; }
        public State Status { get; set; }
        public uint Amount { get; set; }
        public uint ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
