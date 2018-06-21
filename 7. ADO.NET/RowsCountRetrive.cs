using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADOdotNET
{
    class RowsCountRetrive
    {
      //Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.

        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using(dbCon)
            {
                SqlCommand categoryCounter = new SqlCommand("SELECT COUNT(c.CategoryID) FROM Northwind.dbo.Categories c", dbCon);
                int categoryNumber = (int)categoryCounter.ExecuteScalar();
                Console.WriteLine("Number of categories is {0}", categoryNumber);
            }

        }
    }
}
