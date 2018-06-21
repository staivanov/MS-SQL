namespace CompareSQLQuerysPerfomance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    using TelericAcademyModel;

    class SQLperfomance
    {
        //Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.

        public static void FastCorrect()
        {
            TelerikAcademyEntities dbTelerikAcademy = new TelerikAcademyEntities();
            Stopwatch omega = new Stopwatch();
            var queryEmployee = dbTelerikAcademy.Employees.Select(x =>
               new
                 {
                     Name = x.FirstName,
                     LastName = x.LastName,
                     Town = x.Address.Town.Name
                 }).ToList();

            using (dbTelerikAcademy)
            {
                omega.Start();

                foreach (var employeeName in queryEmployee)
                {
                    if (employeeName.Town == "Sofia")
                        Console.WriteLine("{0} {1} --> {2}", employeeName.Name, employeeName.LastName, employeeName.Town);
                }

                omega.Stop();
                Console.WriteLine(omega.Elapsed);
            }
        }

        static void Main(string[] args)
        {
            FastCorrect();

        }
    }
}
