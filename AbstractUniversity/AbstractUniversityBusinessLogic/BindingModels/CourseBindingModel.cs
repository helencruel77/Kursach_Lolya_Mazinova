using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class CourseBindingModel //order
    {
        public int? Id { get; set; }
        public int ClientId { get; set; }
        public string CourseName { get; set; }
        public int Price { get; set; }
        public DateTime DateCreate { get; set; }
        public bool isReserved { get; set; }
        public int DisciplineId { get; set; }
        public List<DisciplineCourseBindingModel> DisciplineCourses { get; set; }
    }
}
