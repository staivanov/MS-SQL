using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNorthwindDB;

namespace _3.FindCustomers
{
    class CustomerAround
    {
        //Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

        //SELECT c.CompanyName, c.ContactName, c.ContactTitle, o.ShippedDate
        //FROM Northwind.dbo.Customers c INNER JOIN Northwind.dbo.Orders o
        //ON c.CustomerID = o.CustomerID
        //WHERE o.ShipCountry = 'Canada' AND (o.ShippedDate BETWEEN '1997-01-01' AND '1997-12-31')

        public static readonly NorthwindEntities db = new NorthwindEntities();

        public static void FindCustomerShippedToCanada()
        {
            using (db)
            {
                DateTime start = new DateTime(1997, 01, 01);
                DateTime end = new DateTime(1997, 12, 31);
               
                var res =
                    from c in db.Customers
                    join o in db.Orders
                    on c.CustomerID equals o.CustomerID
                    where o.OrderDate > start && o.ShippedDate < end && o.ShipCountry == "Canada"
                    select new
                    {
                        c.ContactName,
                        c.ContactTitle,
                    };
             
                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
            }
        }


        static void Main(string[] args)
        {

            FindCustomerShippedToCanada();

        }
    }
}
