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
    public class PlaceLogic : IPlaceLogic
    {
        public void CreateOrUpdate(PlaceBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Place element = context.Places.FirstOrDefault(rec => rec.TypePlace == model.TypePlace && rec.Id != model.Id);

                if (element != null)
                {
                    throw new Exception("Уже есть место с таким типом");
                }

                if (model.Id.HasValue)
                {
                    element = context.Places.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Place();
                    context.Places.Add(element);
                }

                element.TypePlace = model.TypePlace;

                context.SaveChanges();
            }
        }

        public void Delete(PlaceBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Place element = context.Places.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Places.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<PlaceViewModel> Read(PlaceBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                return context.Places
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new PlaceViewModel
                {
                    Id = rec.Id,
                    TypePlace = rec.TypePlace
                })
                .ToList();
            }
        }
    }
}
