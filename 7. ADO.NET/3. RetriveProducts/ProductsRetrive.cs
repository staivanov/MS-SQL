using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _3.RetriveProducts
{
    class ProductsRetrive
    {
        //Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. Can you do this with a single SQL query (with table join)?

        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand retriveProductCategories = new SqlCommand(@"SELECT p.ProductName, c.CategoryName FROM Northwind.dbo.Categories c  INNER JOIN Northwind.dbo.Products p ON c.CategoryID = p.CategoryID", dbCon);
                SqlDataReader retrivedResult = retriveProductCategories.ExecuteReader();

                using (retrivedResult)
                {
                    Console.WriteLine("Product name ******* Category name");
                    Console.WriteLine(new string('*', 40));

                    while (retrivedResult.Read())
                    {
                        string productName = (string)retrivedResult["ProductName"];
                        string categoryName = (string)retrivedResult["CategoryName"];                        
                        Console.WriteLine("{0} - {1}", productName, categoryName);
                    }
                }               
            }
        }
    }
}
