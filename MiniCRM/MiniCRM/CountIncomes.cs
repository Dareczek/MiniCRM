using System.Linq;
using DataBase;

namespace MiniCRM
{
    class CountIncomes : CountMoney
    {
        private readonly int _currency;
        public CountIncomes(int currency)
        {
            _currency = currency;
        }

        public override double Count(CRMEntities crmEntities)
        {
            foreach (var lol in crmEntities.ClientOrders)
            {
               IQueryable<double?> price = from p in crmEntities.Products
                            where lol.ProductId == p.ProductId
                            select p.Price;
                if (lol.Paid == 0)
                    Result += lol.Amount.GetValueOrDefault() * price.First().GetValueOrDefault();
            }
            Result /= Factor[_currency];
            return Result;
        }
    }
}

