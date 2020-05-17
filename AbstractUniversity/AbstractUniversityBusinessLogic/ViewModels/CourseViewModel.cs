using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class CourseViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("Имя клиента")]
        public string ClientName { get; set; }
        [DataMember]
        [DisplayName("Фамилия клиента")]
        public string ClientLastName { get; set; }
        [DataMember]
        [DisplayName("Название дисциплины")]
        public string DisciplineName { get; set; }
        [DataMember]
        [DisplayName("Стоимость")]
        public int Price { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DataCreate { get; set; }
        [DataMember]
        [DisplayName("Резервирование")]
        public bool IsReserved { get; set; }
    }
}
