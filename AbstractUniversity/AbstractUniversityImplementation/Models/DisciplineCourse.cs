using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class DisciplineCourse
    {
        [ForeignKey("CourseId")]
        public virtual List<Course> Courses { get; set; }
        [ForeignKey("DisciplineId")]
        public virtual List<Discipline> Disciplines { get; set; }
    }
}
