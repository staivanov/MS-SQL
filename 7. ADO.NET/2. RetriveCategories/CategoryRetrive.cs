using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _2.RetriveCategories
{
    class CategoryRetrive
    {
        //Write a program that retrieves the name and description of all categories in the Northwind DB.

        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCategories = new SqlCommand(@"SELECT c.CategoryName, c.Description FROM Northwind.dbo.Categories c", dbCon);
                SqlDataReader dReader = cmdCategories.ExecuteReader();

                using (dReader)
                {
                    while (dReader.Read())
                    {
                        string categoryName = (string)dReader["CategoryName"];
                        string description = (string)dReader["Description"];
                        Console.WriteLine("{0} - {1}", categoryName, description);
                    }
                }
            }
        }
    }
}
