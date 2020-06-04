using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class RequestPlaceBindingModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int PlaceId { get; set; }
        public int Count { get; set; }

    }
}
