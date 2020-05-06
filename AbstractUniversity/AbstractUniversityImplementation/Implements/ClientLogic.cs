using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityImplementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractUniversityImplementation.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Client client;
                if (model.Id.HasValue)
                {
                    client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (client == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    client = new Client();
                    context.Clients.Add(client);
                }
                client.ClientName = model.ClientName;
                client.ClientLastName = model.ClientLastName;
                client.Email = model.Email;
                client.Password = model.Password;
                client.Login = model.Login;
                context.SaveChanges();
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {

                List<ClientViewModel> clients = context.Clients.Where(
                         rec => model == null
                      || rec.Id == model.Id
                      || rec.Id == model.Id
                       || rec.Email == model.Email && rec.Password == model.Password
                    ).Select(rec => new ClientViewModel
                    {
                        Id = rec.Id,
                        ClientName = rec.ClientName,
                        ClientLastName = rec.ClientLastName,
                        Email = rec.Email,
                        Password = rec.Password,
                        Login = rec.Login,
                    })
                    .ToList();
                if (clients.Count > 0)
                    return clients;
                return null;
            }
        }
    }
}
