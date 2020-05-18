using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class CreateCourseBindingModel
    {
        public int DisciplineId { get; set; }
        public int ClientId { get; set; }

        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
