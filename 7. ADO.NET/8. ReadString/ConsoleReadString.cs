using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _8.ReadString
{
    class ConsoleReadString
    {
        //Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.
        static void Main(string[] args)
        {
            string myWord = Console.ReadLine();
            SqlConnection dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                String procedure = String.Format(@"DECLARE @p NVARCHAR(70) = '{0}';
                                               DECLARE @Escaped NVARCHAR(70) = REPLACE(@p, '[', '[[]');
                                               SET @Escaped = REPLACE(@Escaped, '_', '[_]');
                                               SET @Escaped = REPLACE(@Escaped, '%', '[%]');
                                               SET @Escaped = REPLACE(@Escaped, '*', '%');
                                               SET @Escaped = REPLACE(@Escaped, '/', '%');
                                               SET @Escaped = REPLACE(@Escaped, '""', '""');

                                               SELECT p.QuantityPerUnit, p.ProductName
                                               FROM Northwind.dbo.Products p
                                               WHERE  p.QuantityPerUnit LIKE '%' + @Escaped + '%' OR p.ProductName LIKE '%' + @Escaped + '%'", myWord);

                SqlCommand cmdContain = new SqlCommand(procedure, dbCon);
                SqlDataReader containReader = cmdContain.ExecuteReader();

                using (containReader)
                {
                    Console.WriteLine("Product name ------ Quantity Per Unit");
                    while (containReader.Read())
                    {
                        string productName = (string)containReader["ProductName"];
                        string quanty = (string)containReader["QuantityPerUnit"];
                        Console.WriteLine("{0} ------ {1}", productName, quanty);
                    }
                }
            }
        }
    }
}
