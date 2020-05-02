using System.ComponentModel.DataAnnotations;

namespace AbstractUniversityImplementation.Models
{
    public class RequestPlace
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int PlaceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Request Request { get; set; }

        public virtual Place Place { get; set; }
    }
}
