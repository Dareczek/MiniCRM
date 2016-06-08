using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class ClientOrder : Order
    {
        public Client Client { get; set; }
    }
}
