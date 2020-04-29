using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    [DataContract]
    public class CourseDisciplineBindingModel
    {
        [DataMember]
        public int DisciplineId { get; set; }
        [DataMember]
        public int CourseId { get; set; }
    }
}
