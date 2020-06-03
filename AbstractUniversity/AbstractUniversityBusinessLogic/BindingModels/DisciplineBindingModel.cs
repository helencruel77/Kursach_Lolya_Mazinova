using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class DisciplineBindingModel //продукт
    {
        public int? Id { get; set; }
        public string DisciplineName { get; set; }
        public int Price { get; set; }
        public List<PlaceDisciplineBindingModel> PlaceDisciplines { get; set; }
    }
}
