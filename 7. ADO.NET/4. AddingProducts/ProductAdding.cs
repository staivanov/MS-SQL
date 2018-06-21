using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _4.AddingProducts
{
    class ProductAdding
    {
        //Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.

        public static void AddProduct(string productName, int supplierID, int categoryID, string quantity, int unitPrice, int unitStock, int UnitsOnOrder, int ReorderLvl, bool discounted)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                String procedure = String.Format(@"INSERT INTO Northwind.dbo.Products VALUES ('{0}', {1}, {2}, '{3}', {4}, {5}, {6}, {7}, '{8}')", productName, supplierID, categoryID, quantity, unitPrice, unitStock, UnitsOnOrder, ReorderLvl, discounted);
                SqlCommand cmdAdding = new SqlCommand(procedure, dbCon);
                var result = cmdAdding.ExecuteScalar();
            }
        }

        static void Main(string[] args)
        {
            AddProduct("testera", 4, 4, "dada", 5000, 33, 12, 4, true);
        }
    }
}
