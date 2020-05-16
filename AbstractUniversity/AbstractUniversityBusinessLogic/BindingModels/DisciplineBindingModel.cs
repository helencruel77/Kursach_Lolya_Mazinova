using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class DisciplineBindingModel //продукт
    {
        public int? Id { get; set; }
        public string DisciplineName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PlaceDisciplines { get; set; }
    }
}
