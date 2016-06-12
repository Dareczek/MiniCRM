using System.Linq;
using DataBase;

namespace MiniCRM
{
    class CountOutgoings : CountMoney
    {

        private readonly double _tax;
        private readonly int _currency;
        public CountOutgoings(double tax, int currency)
        {
            _tax = 0.01 * tax;
            _currency = currency;
        }
        public override double Count(CRMEntities crmEntities)
        {
            foreach (var lol in crmEntities.Orderiks)
            {
                IQueryable<double?> price = from p in crmEntities.Products
                                            where lol.ProductId == p.ProductId
                                            select p.Price;
                if (lol.Paid == 0)
                    Result += lol.Amount.GetValueOrDefault() * price.First().GetValueOrDefault();
            }
            Result *= (1 - _tax) / Factor[_currency];
            return Result;
        }
    }
}
