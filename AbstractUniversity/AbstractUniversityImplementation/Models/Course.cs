using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }
        [Required]
        public bool isReserved { get; set; }
        public virtual List<DisciplineCourse> DisciplineCourse { get; set; }
        public virtual Client Client { get; set; }
    }
}
