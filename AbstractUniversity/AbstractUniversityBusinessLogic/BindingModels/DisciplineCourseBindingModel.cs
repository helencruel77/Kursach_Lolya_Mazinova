using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    [DataContract]
    public class DisciplineCourseBindingModel
    {
        public int Id { get; set; }
        [DataMember]
        public int DisciplineId { get; set; }
        [DataMember]
        public int CourseId { get; set; }
        public int Count { get; set; }
        public string DisciplineName { get; set; }
    }
}
