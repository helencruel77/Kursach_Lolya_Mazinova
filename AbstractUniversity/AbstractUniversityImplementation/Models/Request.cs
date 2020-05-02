using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbstractUniversityImplementation.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string RequestName { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }

        public virtual List<RequestPlace> RequestPlace { get; set; }
    }
}
