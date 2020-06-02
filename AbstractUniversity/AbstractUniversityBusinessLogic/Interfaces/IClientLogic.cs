using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);

        void CreateOrUpdate(ClientBindingModel model);

        void Delete(ClientBindingModel model);

        ClientViewModel GetClient(int id);
    }
}
