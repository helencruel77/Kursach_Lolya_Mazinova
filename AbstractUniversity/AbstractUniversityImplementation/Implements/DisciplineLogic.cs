using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using AbstractUniversityImplementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractUniversityImplementation.Implements
{
    public class DisciplineLogic : IDisciplineLogic
    {
        public void CreateOrUpdate(DisciplineBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Discipline element = context.Disciplines.FirstOrDefault(rec =>
                       rec.DisciplineName == model.DisciplineName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Disciplines.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Discipline();
                            context.Disciplines.Add(element);
                        }
                        element.DisciplineName = model.DisciplineName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var placeDiscipline = context.PlaceDisciplines.Where(rec
                           => rec.DisciplineId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.PlaceDisciplines.RemoveRange(placeDiscipline.Where(rec =>
                            !model.PlaceDisciplines.ContainsKey(rec.PlaceId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateDiscipline in placeDiscipline)
                            {
                                updateDiscipline.Count =
                               model.PlaceDisciplines[updateDiscipline.PlaceId].Item2;

                                model.PlaceDisciplines.Remove(updateDiscipline.PlaceId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.PlaceDisciplines)
                        {
                            context.PlaceDisciplines.Add(new PlaceDiscipline
                            {
                                DisciplineId = element.Id,
                                PlaceId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
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
        public void Delete(DisciplineBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.PlaceDisciplines.RemoveRange(context.PlaceDisciplines.Where(rec =>
                        rec.DisciplineId == model.Id));
                        Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Disciplines.Remove(element);
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
        public List<DisciplineViewModel> Read(DisciplineBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                return context.Disciplines
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new DisciplineViewModel
               {
                   Id = rec.Id,
                   DisciplineName = rec.DisciplineName,
                   Price = rec.Price,
                   PlaceDisciplines = context.PlaceDisciplines
                .Include(recPC => recPC.Place)
               .Where(recPC => recPC.DisciplineId == rec.Id)
               .ToDictionary(recPC => recPC.PlaceId, recPC =>
                (recPC.Place?.TypePlace, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
