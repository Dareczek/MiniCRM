namespace MiniCRM
{
    public class Product
    {
       
        public uint ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public uint Amount { get; set; }

        public virtual Order Order { get; set; }
    }
}
