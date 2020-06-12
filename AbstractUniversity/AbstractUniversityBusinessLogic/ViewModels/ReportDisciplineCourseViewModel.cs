using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class ReportDisciplineCourseViewModel
    {
        public string CourseName { get; set; }
        public List<Tuple<string, int>> DisciplineCourses { get; set; }
    }
}
