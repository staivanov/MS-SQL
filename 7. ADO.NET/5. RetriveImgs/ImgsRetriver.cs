using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace _5.RetriveImgs
{
    class ImgsRetriver
    {
        private static SqlConnection dbCon;

        private static void DBconnection()
        {
            dbCon = new SqlConnection("Server=.\\MSSQLSERVERS; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();
        }

        //Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
        static void Main(string[] args)
        {
            DBconnection();

            byte[] imageFromDB;
            string categoryName;

          
            using (dbCon)
            {
                SqlCommand cmdGetCategoriesImages = new SqlCommand(
                "SELECT CategoryName, Picture " +
                "FROM Categories", dbCon);
                SqlDataReader reader = cmdGetCategoriesImages.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        imageFromDB = (byte[])reader["Picture"];
                        categoryName = (string)reader["CategoryName"];
                        categoryName = categoryName.Replace("/", string.Empty);
                        WriteBinaryFile(@"..\..\" + categoryName + ".JPG", imageFromDB);
                    }
                }
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }
    }
}
