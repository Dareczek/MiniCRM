using System.Linq;
using System.Net.Sockets;
using DataBase;

namespace MiniCRM
{
    class CountOutgoings : CountMoney
    {

        private double _tax;
        private int _currency;
        public CountOutgoings(double tax, int currency)
        {
            _tax = 0.01*tax;
            _currency = currency;
        }


        public override double Count(CRMEntities crmEntities)
        {
            foreach (var lol in crmEntities.Orderiks)
            {
                var price = from p in crmEntities.Products
                    where (lol.ProductId == p.ProductId)
                    select p.Price;
                if(lol.Paid == 0)
                    _result += lol.Amount.GetValueOrDefault() * price.First().GetValueOrDefault();
            }
            _result *= (1-_tax)/Factor[_currency];
            return _result;
        }
    }
}
