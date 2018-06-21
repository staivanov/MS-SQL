using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNorthwindDB;

namespace EntityHomework
{
    public class dbFunctionality
    {
        //Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.

        public static readonly NorthwindEntities northwind = new NorthwindEntities();

        public static void InsertCustomer(string id, string companyName, string contactName, string contactTitle, string adress, string city, string region, string postCode, string country, string phone, string fax)
        {
            using (northwind)
            {
                Customer myCustomer = new Customer()
                {
                    CustomerID = id,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = adress,
                    City = city,
                    Region = region,
                    PostalCode = postCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                northwind.Customers.Add(myCustomer);
                northwind.SaveChanges();
            }
        }

        public static void ModifyingCustomer(string id, string companyName, string contactName, string contactTitle, string adress, string city, string region, string postCode, string country, string phone, string fax)
        {
            using (northwind)
            {
                var myCustomer = northwind.Customers.Find(id);
                myCustomer.CompanyName = companyName;
                myCustomer.ContactName = contactName;
                myCustomer.ContactTitle = contactTitle;
                myCustomer.Address = adress;
                myCustomer.City = city;
                myCustomer.Region = region;
                myCustomer.PostalCode = postCode;
                myCustomer.Country = country;
                myCustomer.Phone = phone;
                myCustomer.Fax = fax;

                northwind.SaveChanges();
            }
        }

        public static void DeleteCustomer(string id)
        {
            using (northwind)
            {         
                var removedCustomer = northwind.Customers.Find(id);
                northwind.Customers.Remove(removedCustomer);
                northwind.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            //InsertCustomer("WWWWW", "Tuz", "Tuzovo", "Nachalnik", "IQWUe", "Acebase", "Code", "5555", "SHA", "9999", "88888");
            //DeleteCustomer("WWWWW");
            //ModifyingCustomer("WWWWW", "Tuzlence", "Tuzovo", "Nachalnik", "IQWUe", "Acebase", "Code", "5555", "SHA", "9999", "88888");
        }
    }
}
