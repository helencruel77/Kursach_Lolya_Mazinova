using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class PlaceDisciplineViewModel
    {
        public int Id { get; set; }

        public int PlaceId { get; set; }

        public int DisciplineId { get; set; }

        [DisplayName("Тип места")]
        public string TypePlace { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
