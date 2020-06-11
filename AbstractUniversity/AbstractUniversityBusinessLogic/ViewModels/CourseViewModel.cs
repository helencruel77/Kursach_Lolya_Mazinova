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
        public int DisciplineId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("Название курса")]
        public string CourseName { get; set; }
        [DataMember]
        [DisplayName("Стоимость")]
        public int Price { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public bool isReserved { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public List<DisciplineCourseViewModel> DisciplineCourses { get; set; }

    }
}
