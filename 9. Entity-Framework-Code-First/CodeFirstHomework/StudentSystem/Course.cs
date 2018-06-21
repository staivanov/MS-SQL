namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {

        public int CourseId { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }      
        public string Desctiption { get; set; }
        public string Material { get; set; }
        public int HomeworkId { get; set; }
        public virtual ICollection<Homework> Homework { get; set; }
    }
}
