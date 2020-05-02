using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbstractUniversityImplementation.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Required]
        public string TypePlace { get; set; }

        [ForeignKey("PlaceId")]
        public virtual List<PlaceDiscipline> PlaceDiscipline { get; set; }

        [ForeignKey("PlaceId")]
        public virtual List<RequestPlace> RequestPlace { get; set; }
    }
}
