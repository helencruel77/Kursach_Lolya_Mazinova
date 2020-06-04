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
        public string DisciplineName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<DisciplineCourse> DisciplineCourse { get; set; }
        public virtual List<PlaceDiscipline> PlaceDiscipline { get; set; }
    }
}
