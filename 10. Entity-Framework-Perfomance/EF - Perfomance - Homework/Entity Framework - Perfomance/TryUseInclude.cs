namespace EntityFrameworkPerfomance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    using TelericAcademyModel;

    class TryUseInclude
    {
        //Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.

        static void Main(string[] args)
        {
            Stopwatch omega = new Stopwatch();
            TelerikAcademyEntities dbTelerikAcademy = new TelerikAcademyEntities();
                
                //SELECT e.FirstName + e.LastName AS [Full Name], d.Name AS [Department Name], t.Name AS [City Name]
                //FROM TelerikAcademy.dbo.Employees e JOIN TelerikAcademy.dbo.Departments d
                //ON e.DepartmentID = d.DepartmentID
                //JOIN  TelerikAcademy.dbo.Addresses a
                //ON e.AddressID = a.AddressID
                //JOIN TelerikAcademy.dbo.Towns t
                //ON a.TownID = t.TownID

            using (dbTelerikAcademy)
            {
                //Withoud .Include
                foreach (var entity in dbTelerikAcademy.Employees)
                {
                    omega.Start();
                    Console.Write("Name: {0} {1} ==== Department: {2} ==== Town: {3} ", entity.FirstName, entity.LastName, entity.Department.Name, entity.Address.Town.Name);
                    Console.WriteLine();
                    omega.Stop();
                }
                // 00:00:00:9303638
                Console.WriteLine("Time without .Include is {0} )", omega.Elapsed);

                //With .Include
                foreach (var entity in dbTelerikAcademy.Employees.Include("Department").Include("Address"))
                {
                    omega.Start();
                    Console.Write("Name: {0} {1} ==== Department: {2} ==== Town: {3} ", entity.FirstName, entity.LastName, entity.Department.Name, entity.Address.Town.Name);
                    Console.WriteLine();
                    omega.Stop();
                }
                // 00:00:00:3903638
                Console.WriteLine("Time with .Include is {0} ", omega.Elapsed);
            }
        }
    }
}
