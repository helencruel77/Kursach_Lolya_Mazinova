using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class PlaceDiscipline
    {
        public int Id { get; set; }

        public int PlaceId { get; set; }

        public int DisciplineId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Place Place { get; set; }

        public virtual Discipline Discipline { get; set; }
    }
}
