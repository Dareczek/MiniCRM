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

                var lol = new Order() {Amount = 8};
                db.Orders.Add(lol);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Orders
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
