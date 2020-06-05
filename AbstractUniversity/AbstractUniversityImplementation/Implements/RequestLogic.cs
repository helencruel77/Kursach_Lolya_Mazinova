using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityImplementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AbstractUniversityImplementation.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Request element = context.Requests.FirstOrDefault(rec => rec.RequestName == model.RequestName && rec.Id != model.Id);
                if (model.Id.HasValue)
                {
                    element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Request();
                    context.Requests.Add(element);
                }

                element.RequestName = model.RequestName;
                element.DateCreate = model.DateCreate;

                context.SaveChanges();
            }
        }

        public void Delete(RequestBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RequestPlaces.RemoveRange(context.RequestPlaces.Where(rec => rec.RequestId == model.Id));
                        Request element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.Requests.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                return context.Requests
               .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                )

                .ToList()
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    RequestName = rec.RequestName,
                    DateCreate = rec.DateCreate,
                    RequestPlaces = context.RequestPlaces
                                                .Include(recWC => recWC.Place)
                                                .Where(recWC => recWC.RequestId == rec.Id)
                                                .ToDictionary(recWC => recWC.PlaceId, recWC => (
                                                    recWC.Place?.TypePlace, recWC.Count
                                                ))
                })
                .ToList();
            }
        }

        public void AddPlace(RequestPlaceBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                RequestPlace element =
                    context.RequestPlaces.FirstOrDefault(rec => rec.RequestId == model.RequestId && rec.PlaceId == model.PlaceId);

                if (element != null)
                {
                    element.Count += model.Count;
                }
                else
                {

                    element = new RequestPlace();
                    context.RequestPlaces.Add(element);
                    element.RequestId = model.RequestId;
                    element.PlaceId = model.PlaceId;
                    element.Count = model.Count;
                }          
                context.SaveChanges();
            }
        }
    }
}
