using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class DisciplineBindingModel //component
    {
        public int? Id { get; set; }
        public int CourseId { get; set; }
        public string DisciplineName { get; set; }
        public int Price { get; set; }
        public Dictionary<int, (string, int)> PlaceDisciplines { get; set; }
    }
}
