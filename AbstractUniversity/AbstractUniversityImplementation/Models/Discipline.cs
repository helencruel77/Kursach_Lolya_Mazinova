using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string DisciplineName { get; set; }
        [Required]
        public int Price { get; set; }
        public virtual DisciplineCourse DisciplineCourse { get; set; }
    }
}
