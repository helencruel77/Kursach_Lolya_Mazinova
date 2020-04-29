using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class CourseBindingModel //order
    {
        public int? Id { get; set; }
        public string ClientId { get; set; }
        public int Price { get; set; }
        public DateTime DataCreate { get; set; }
        public bool IsReserved { get; set; }
    }
}
