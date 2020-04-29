using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название заявки")]
        public string DisciplineName { get; set; }
        public List<RequestPlaceViewModel> RequestPlace { get; set; }
    }
}
