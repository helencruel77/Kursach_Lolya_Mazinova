using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class DisciplineCourse
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int DisciplineId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Discipline Discipline { get; set; }
    }
}
