using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IPlaceLogic
    {
        List<PlaceViewModel> Read(PlaceBindingModel model);

        void CreateOrUpdate(PlaceBindingModel model);

        void Delete(PlaceBindingModel model);
    }
}
