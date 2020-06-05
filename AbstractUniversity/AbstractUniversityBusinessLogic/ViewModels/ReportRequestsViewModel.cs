using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    public class ReportRequestsViewModel
    {
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public int Count { get; set; }
        public string TypePlace { get; set; }

    }
}
