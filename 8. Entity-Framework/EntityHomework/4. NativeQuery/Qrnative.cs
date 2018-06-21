using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNorthwindDB;

namespace _4.NativeQuery
{
    class QrNative
    {
        //Implement previous by using native SQL query and executing it through the DbContext.

        //SELECT c.CompanyName, c.ContactName, c.ContactTitle, o.ShippedDate
        //FROM Northwind.dbo.Customers c INNER JOIN Northwind.dbo.Orders o
        //ON c.CustomerID = o.CustomerID
        //WHERE o.ShipCountry = 'Canada' AND (o.ShippedDate BETWEEN '1997-01-01' AND '1997-12-31')

        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                string orderBetween = @"SELECT *
                                        FROM Northwind.dbo.Customers c INNER JOIN Northwind.dbo.Orders o
                                        ON c.CustomerID = o.CustomerID
                                        WHERE o.ShipCountry = 'Canada' AND (o.ShippedDate BETWEEN '1997-01-01' AND '1997-12-31')";
               
                var executedQuery = db.Database.SqlQuery<Customer>(orderBetween);

                foreach (var item in executedQuery)
                {
                    Console.WriteLine(item.ContactName);
                }
            
            }

        }
    }
}
