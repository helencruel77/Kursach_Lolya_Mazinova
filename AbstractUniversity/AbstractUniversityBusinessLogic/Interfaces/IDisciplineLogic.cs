using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IDisciplineLogic
    {

      
        List<DisciplineBindingModel> GetList();
        DisciplineViewModel GetElement(int disciplineId);

        void AddElement(DisciplineBindingModel model);

        void UpdElement(DisciplineBindingModel model);

        void DelElement(int id);
        List<DisciplineViewModel> GetClientList(int ClientId);

    }
}
