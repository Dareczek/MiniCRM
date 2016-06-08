using System;
using System.Linq;

namespace DataModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Model())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var lol = new ClientOrder() {Amount = 8};
                db.ClientOrders.Add(lol);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.ClientOrders
                            orderby b.Amount
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Amount.ToString());
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
