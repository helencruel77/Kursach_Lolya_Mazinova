using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название заявки")]
        public string RequestName { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public int Count { get; set; }
        public string TypePlace { get; set; }
        public Dictionary<int, (string, int)> RequestPlaces { get; set; }
    }
}
