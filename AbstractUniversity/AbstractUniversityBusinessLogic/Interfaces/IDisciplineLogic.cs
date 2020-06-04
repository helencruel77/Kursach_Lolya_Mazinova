using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IDisciplineLogic
    {

        List<DisciplineViewModel> Read(DisciplineBindingModel model);
        void Delete(DisciplineBindingModel model);

        DisciplineViewModel GetElement(int disciplineId);

        void AddElement(DisciplineBindingModel model);

        void UpdElement(DisciplineBindingModel model);

        List<DisciplineViewModel> GetClientList(int ClientId);

    }
}
