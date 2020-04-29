using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class DisciplineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название дисциплины")]
        public string DisciplineName { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
    }
}
