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
                            throw new Exception("Уже есть дисциплина с таким названием");
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
                            var placeDisciplines = context.PlaceDisciplines.Where(rec
                          => rec.DisciplineId == model.Id.Value).ToList();

                            /*
                            context.PlaceDisciplines.RemoveRange(placeDisciplines.Where(rec =>
                           !model.PlaceDisciplines.ContainsKey(rec.PlaceId)).ToList());
                            context.SaveChanges();
                            */
                            foreach (var updatePlace in placeDisciplines)
                            {
                                updatePlace.Count =
                               model.PlaceDisciplines.FirstOrDefault(rec => rec.Id == updatePlace.Id).Count; ;
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.PlaceDisciplines)
                        {
                            context.PlaceDisciplines.Add(new PlaceDiscipline
                            {
                                PlaceId = element.Id,
                                DisciplineId = pc.DisciplineId,
                                Count = pc.Count
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

        public DisciplineViewModel GetElement(int id)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    return new DisciplineViewModel
                    {
                        Id = element.Id,
                        DisciplineName = element.DisciplineName,
                        Price = element.Price,
                        PlaceDisciplines = context.PlaceDisciplines
                            .Where(recPM => recPM.PlaceId == element.Id)
                            .Select(recPM => new PlaceDisciplineViewModel
                            {
                                Id = recPM.Id,
                                PlaceId = recPM.PlaceId,
                                DisciplineId = recPM.DisciplineId,
                                Count = recPM.Count,
                            }).ToList()
                    };
                }
                throw new Exception("Элемент не найден");
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
                List<DisciplineViewModel> result = context.Disciplines.Select(rec => new DisciplineViewModel
                {
                    Id = rec.Id,
                    DisciplineName = rec.DisciplineName,
                    Price = rec.Price,
                    PlaceDisciplines = context.PlaceDisciplines
                    .Where(recPM => recPM.DisciplineId == rec.Id)
                    .Select(recPM => new PlaceDisciplineViewModel
                    {
                        Id = recPM.Id,
                        PlaceId = recPM.PlaceId,
                        DisciplineId = recPM.DisciplineId,
                        Count = recPM.Count
                    }).ToList()
                }).ToList();
                return result;
            }
        }

        public List<DisciplineViewModel> GetClientList(int ClientId)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                var groupDisciplines = context.DisciplineCourses
                                   .Include(rec => rec.Discipline)
                                   .Include(rec => rec.Course)
                                   .Where(rec => rec.Course.ClientId == ClientId)
                                   .Select(rec => new DisciplineViewModel
                                   {
                                       Id = rec.DisciplineId,
                                       DisciplineName = rec.DisciplineName,
                                       Price = rec.Count
                                   })
                                   .GroupBy(rec => rec.Id)
                                   .Select(rec => new
                                   {
                                       DisciplineId = rec.Key,
                                       Count = rec.Sum(r => r.Price)
                                   })
                                   .OrderByDescending(rec => rec.Count)
                                   .ToList();

                List<DisciplineViewModel> result = new List<DisciplineViewModel>();
                foreach (var pre in groupDisciplines)
                {
                    var pres = context.Disciplines.FirstOrDefault(rec => rec.Id == pre.DisciplineId);
                    result.Add(new DisciplineViewModel
                    {
                        Id = pres.Id,
                        DisciplineName = pres.DisciplineName,
                        Price = pres.Price,
                        PlaceDisciplines = context.PlaceDisciplines
                                                  .Where(recPM => recPM.DisciplineId == pres.Id)
                                                  .Select(recPM => new PlaceDisciplineViewModel
                                                  {
                                                      Id = recPM.Id,
                                                      PlaceId = recPM.PlaceId,
                                                      DisciplineId = recPM.DisciplineId,
                                                      Count = recPM.Count
                                                  }).ToList()
                    });
                }

                foreach (var el in context.Disciplines)
                {
                    bool flag = false;
                    foreach (var pre in result)
                    {
                        if (el.Id == pre.Id)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        result.Add(new DisciplineViewModel
                        {
                            Id = el.Id,
                            DisciplineName = el.DisciplineName,
                            Price = el.Price,
                            PlaceDisciplines = context.PlaceDisciplines
                                                  .Where(recPM => recPM.DisciplineId == el.Id)
                                                  .Select(recPM => new PlaceDisciplineViewModel
                                                  {
                                                      Id = recPM.Id,
                                                      PlaceId = recPM.PlaceId,
                                                      DisciplineId = recPM.DisciplineId,
                                                      Count = recPM.Count
                                                  }).ToList()
                        });
                    }
                }

                return result;
            }
        }
    }
}
