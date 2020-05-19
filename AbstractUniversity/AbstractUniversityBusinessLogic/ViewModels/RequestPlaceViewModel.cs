using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class RequestPlaceViewModel
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int PlaceId { get; set; }

        [DisplayName("Тип места")]
        public string TypePlace { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
