﻿using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public List<ReportRequestsViewModel> RequestPlaces { get; set; }
    }
}
