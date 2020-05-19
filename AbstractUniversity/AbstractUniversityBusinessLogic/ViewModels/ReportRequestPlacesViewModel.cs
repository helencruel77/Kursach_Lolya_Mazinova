using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class ReportRequestPlacesViewModel
    {
        public string RequestName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Places { get; set; }
    }
}
