using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace _6.OleDB
{
    class OleDBtableExcell
    {
        //Create an Excel file with 2 columns: name and score:
        //Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
        //T:\SQL\7.ADO.NET\ADOdotNET\oleDB.xlsx
        static void Main(string[] args)
        {
            OleDbConnection dbCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=T:\SQL\7. ADO.NET\ADOdotNET\oleDB.xlsx;Extended Properties=Excel 12.0;HDR=YES; ");
            dbCon.Open();

            using (dbCon)
            {
                OleDbCommand cmdDisplayRow = new OleDbCommand("SELECT Name, Score FROM oleDB.xlsx", dbCon);
                OleDbDataReader readRow = cmdDisplayRow.ExecuteReader();

                while (readRow.Read())
                {
                    string name = (string)readRow["Name"];
                    int score = (int)readRow["Score"];
                    Console.WriteLine("{0} {1}", name, score);
                }
            }
        }
    }
}
