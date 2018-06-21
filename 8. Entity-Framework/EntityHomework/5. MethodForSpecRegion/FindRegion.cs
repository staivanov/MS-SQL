using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNorthwindDB;

namespace _5.MethodForSpecRegion
{
    class FindRegion
    {
        //Write a method that finds all the sales by specified region and period (start / end dates).

        public static readonly NorthwindEntities db = new NorthwindEntities();

        public static void FindSpecific(string myRegion, DateTime start, DateTime end )
        {
            using (db)
            {
                var query =
                    from o in db.Orders
                    where o.ShipRegion == myRegion && o.OrderDate > start && o.ShippedDate < end 
                    select o.ShipName;

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Main(string[] args)
        {
            DateTime start = new DateTime(1997, 01, 01);
            DateTime end = new DateTime(1997, 12, 31);
            string region = "RJ";

            FindSpecific(region, start, end);
        }
    }
}
