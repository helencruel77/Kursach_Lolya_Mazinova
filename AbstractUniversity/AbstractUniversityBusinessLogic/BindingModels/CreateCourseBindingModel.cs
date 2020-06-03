using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class CreateCourseBindingModel
    {
        public int DisciplineId { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
