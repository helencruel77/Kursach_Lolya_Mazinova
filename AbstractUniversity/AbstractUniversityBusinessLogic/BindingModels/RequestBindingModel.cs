using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public string RequestName { get; set; }
        public List<RequestPlaceBindingModel> RequestPlace { get; set; }
        public DateTime? DataCreate { get; set; }
    }
}
