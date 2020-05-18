using AbstractUniversityBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class CourseBindingModel //order
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public int Price { get; set; }
        public DateTime DataCreate { get; set; }
        public CourseStatus Status { get; set; }
        public decimal Sum { get; set; }
        public int DisciplineId { get; set; }
        public int Count { get; set; }
    }
}
