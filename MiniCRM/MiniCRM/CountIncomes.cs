using System.Linq;
using DataBase;

namespace MiniCRM
{
    class CountIncomes : CountMoney
    {
        private int _currency;
        public CountIncomes(int currency)
        {
            _currency = currency;
        }


        public override double Count(CRMEntities crmEntities)
        {
            foreach (var lol in crmEntities.ClientOrders)
            {
                var price = from p in crmEntities.Products
                            where (lol.ProductId == p.ProductId)
                            select p.Price;
                if (lol.Paid == 0)
                    _result += lol.Amount.GetValueOrDefault() * price.First().GetValueOrDefault();
            }
            _result /= Factor[_currency];
            return _result;
        }
    }
}

