using System.Data.Entity;

namespace DataModel
{
    class Context : DbContext
    {
        public DbSet<BusinessClient> BusinessClients { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RetailClient> RetailClients { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
