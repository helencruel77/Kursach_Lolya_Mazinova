using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BuisnessLogic
{
    public class MainLogic
    {
        private readonly IRequestLogic requestLogic;
        public MainLogic(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }
        public void CreateRequest(RequestPlaceBindingModel model)
        {
            requestLogic.AddPlace(model);
        }
    }
}
