using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class DisciplineCourse
    {
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("DisciplineId")]
        public virtual Discipline Discipline { get; set; }
    }
}
