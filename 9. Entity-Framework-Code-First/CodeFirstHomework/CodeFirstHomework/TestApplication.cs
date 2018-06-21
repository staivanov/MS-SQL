using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BreakAwayContext;
using StudentSystem;
using BreakAwayContext.Migrations;


namespace CodeFirstHomework
{
    class TestApplication
    {
        //Write a console application that uses the data

        static void Main(string[] args)
        {
            //Everytime entity is changed db update. Don't delete or drop db.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BreakAway, Configuration>());

            var db = new BreakAway();
            ///===== Student =====
            //var astudent = new Student()
            //{
            //    Name = "Angel",
            //    StudentNumber = 7777777
            //};

            //db.Students.Add(astudent);
            //db.SaveChanges();
            ///===== Course =====
            //var angelCourse = new Course()
            //{
            //    Name = "Biology",
            //    Desctiption = "Very interesting",
            //    Material = "Soft tissue"
            //};

            //db.Courses.Add(angelCourse);
            //db.SaveChanges();
            ///===== Homework =====
            //var angelHomework = new Homework()
            //{
            //    Content = "Make every shoot count",
            //    TimeSend = new DateTime(2015, 01, 12)
            //};

            //db.Homeworks.Add(angelHomework);
            //db.SaveChanges();        
        }
    }
}
