using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);

        void CreateOrUpdate(RequestBindingModel model);

        void Delete(RequestBindingModel model);
        void СompletedRequest(RequestPlaceBindingModel model);
    }
}
