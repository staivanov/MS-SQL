
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        public int StudentNumber { get; set; }
        public int HomeworkId { get; set; }
        public virtual ICollection<Homework> Homework { get; set; }

    }
}
