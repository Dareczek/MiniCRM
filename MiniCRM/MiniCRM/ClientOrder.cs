namespace MiniCRM
{
    public class ClientOrder : Order
    {
        public uint ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
