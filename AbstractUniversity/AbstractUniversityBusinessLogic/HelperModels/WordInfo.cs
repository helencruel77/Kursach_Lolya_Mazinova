using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportRequestPlacesViewModel> RequestPlaces { get; set; }
        public List<CourseViewModel> DisciplineCourses { get; set; }
    }
}
