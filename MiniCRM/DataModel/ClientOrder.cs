namespace DataModel
{
    class ClientOrder : Order
    {
        public virtual Client Client { get; set; }
    }
}
