﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class PlaceDisciplineBindingModel
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int DisciplineId { get; set; }
        public int Count { get; set; }
    }
}
