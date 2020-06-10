using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Тип места")]
        public string TypePlace { get; set; }
        public int Count { get; set; }
    }
}
