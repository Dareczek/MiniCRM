using DataBase;

namespace MiniCRM
{
    abstract class CountMoney
    {
        protected double _result;
        protected double[] Factor = {1, 4.38, 3.89};
        public abstract double Count(CRMEntities crmEntities);
    }
}
