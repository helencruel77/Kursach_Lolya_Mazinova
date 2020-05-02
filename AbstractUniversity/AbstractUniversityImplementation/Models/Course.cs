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
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }
        [Required]
        public bool IsReserved { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Client> Clients { get; set; }
    }
}
