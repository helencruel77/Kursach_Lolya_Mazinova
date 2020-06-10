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
    public class CourseLogic : ICourseLogic
    {

        public List<CourseViewModel> GetClientList(int ClientId)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                List<CourseViewModel> result = context.Courses.
                Where(rec => rec.ClientId == ClientId).
                Select(rec => new CourseViewModel
                {
                    Id = rec.Id,
                    DateCreate = rec.DataCreate,
                    CourseName = rec.CourseName,
                    ClientId = rec.ClientId,
                    Price = rec.Price,
                    isReserved = rec.isReserved,
                    DisciplineCourses = context.DisciplineCourses
                    .Where(recPC => recPC.CourseId == rec.Id)
                    .Select(recPC => new DisciplineCourseViewModel
                    {
                        Id = recPC.Id,
                        CourseId = recPC.CourseId,
                        DisciplineId = recPC.DisciplineId,
                    }).ToList()
                }).ToList();
                return result;
            }
        }


        public void Delete(int id)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Course element = context.Courses.FirstOrDefault(rec => rec.Id == id);
                        if (element != null)
                        {
                            context.DisciplineCourses.RemoveRange(context.DisciplineCourses.Where(rec => rec.CourseId == id));
                            context.Courses.Remove(element);
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

        public DateTime CourseReservation(int id)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Course element = context.Courses.FirstOrDefault(rec => rec.Id == id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        if (element.isReserved)
                        {
                            throw new Exception("Курс уже зарезервирован");
                        }
                        else
                        {
                            element.isReserved = true;
                        }
                        List<PlaceDisciplineViewModel> placeDisciplines = new List<PlaceDisciplineViewModel>();
                        var disciplineCourses = context.DisciplineCourses.Where(rec => rec.CourseId == element.Id).Select(rec => new DisciplineCourseViewModel
                        {
                            DisciplineId = rec.DisciplineId,
                            Count = rec.Count
                        });
                        foreach (var dis in disciplineCourses)
                        {
                            var placeDiscipline = context.PlaceDisciplines.Where(rec => rec.DisciplineId == dis.DisciplineId).Select(rec => new PlaceDisciplineViewModel
                            {
                                PlaceId = rec.PlaceId,
                                Count = rec.Count
                            });
                            foreach (var place in placeDiscipline)
                            {
                                bool flag = false;
                                for (int i = 0; i < placeDisciplines.Count(); i++)
                                {
                                    if (placeDisciplines[i].PlaceId == place.PlaceId)
                                    {
                                        placeDisciplines[i].Count += place.Count;
                                        flag = true;
                                    }
                                }
                                if (!flag)
                                {
                                    placeDisciplines.Add(place);
                                    placeDisciplines.Last().Count = place.Count * dis.Count;
                                }
                            }
                        }
                        var places = context.Places.Select(rec => new PlaceViewModel
                        {
                            Id = rec.Id,
                            Count = rec.Count
                        }).ToList();

                        for (int i = 0; i < placeDisciplines.Count(); i++)
                        {
                            var index = placeDisciplines[i].PlaceId;
                            var Place = context.Places.Where(rec => rec.Id == index);
                            foreach (var pl in Place)
                            {
                                if (placeDisciplines[i].Count <= pl.Count)
                                {
                                    pl.Count -= placeDisciplines[i].Count;
                                    context.SaveChanges();
                                }
                                else
                                {
                                    throw new Exception("Курс забронировать невозможно, попробуйте позже");
                                }
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();

                        return element.DataCreate;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<CourseViewModel> GetList()
        {
            using (var context = new AbstractUniversityDatabase())
            {
                List<CourseViewModel> result = context.Courses.Select(rec =>
                new CourseViewModel
                {
                    Id = rec.Id,
                    DateCreate = rec.DataCreate,
                    ClientId = rec.ClientId,
                    CourseName = rec.CourseName,
                    Price = rec.Price,
                    isReserved = rec.isReserved,
                    DisciplineCourses = context.DisciplineCourses
                        .Where(recPC => recPC.CourseId == rec.Id)
                        .Select(recPC => new DisciplineCourseViewModel
                        {
                            Id = recPC.Id,
                            CourseId = recPC.CourseId,
                            DisciplineId = recPC.DisciplineId,
                            DisciplineName = recPC.Discipline.DisciplineName,
                            Count = recPC.Count,
                        }).ToList()
                }).ToList();
                return result;
            }
        }

        public void CreateCourse(CourseBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Course element = context.Courses.FirstOrDefault(rec =>
                         rec.CourseName == model.CourseName);

                        element = new Course
                        {
                            DataCreate = DateTime.Now,
                            ClientId = model.ClientId,
                            CourseName = model.CourseName,
                            Price = model.Price,
                        };
                        context.Courses.Add(element);
                        context.SaveChanges();
                        //// убираем дубли 
                        var groupDisciplines = model.DisciplineCourses
                            .GroupBy(rec => rec.DisciplineId)
                            .Select(rec => new
                            {
                                DisciplineId = rec.Key,
                                Count = rec.Sum(r => r.Count)
                            });
                        // запоминаем id и названия 
                        var disciplineName = model.DisciplineCourses.Select(rec => new
                        {
                            DisciplineId = rec.DisciplineId,
                            DisciplineName = rec.DisciplineName
                        });
                        // добавляем 
                        foreach (var groupDiscipline in groupDisciplines)
                        {
                            string Name = null;
                            foreach (var discipline in disciplineName)
                            {
                                if (groupDiscipline.DisciplineId == discipline.DisciplineId)
                                {
                                    Name = discipline.DisciplineName;
                                }
                            }
                            context.DisciplineCourses.Add(new DisciplineCourse
                            {
                                CourseId = element.Id,
                                DisciplineId = groupDiscipline.DisciplineId,
                                DisciplineName = Name,
                                Count = groupDiscipline.Count
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

        public void UpdateCourse(CourseBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Course element = context.Courses.FirstOrDefault(rec =>
                        rec.CourseName == model.CourseName && rec.Id != model.Id);
                        element = context.Courses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        element.CourseName = model.CourseName;
                        element.Price = model.Price;
                        context.SaveChanges();

                        // обновляем существуюущие
                        var compIds = model.DisciplineCourses.Select(rec => rec.DisciplineId).Distinct();
                        var updateDisciplines = context.DisciplineCourses.Where(rec =>
                        rec.CourseId == model.Id && compIds.Contains(rec.DisciplineId));
                        foreach (var updateDiscipline in updateDisciplines)
                        {
                            updateDiscipline.Count = model.DisciplineCourses.FirstOrDefault(rec =>
                            rec.Id == updateDiscipline.Id).Count;
                        }
                        context.SaveChanges();
                        context.DisciplineCourses.RemoveRange(context.DisciplineCourses.Where(rec =>
                        rec.CourseId == model.Id && !compIds.Contains(rec.DisciplineId)));
                        context.SaveChanges();
                        // новые записи  
                        var groupDisciplines = model.DisciplineCourses.Where(rec =>
                        rec.Id == 0).GroupBy(rec => rec.DisciplineId).Select(rec => new
                        {
                            DisciplineId = rec.Key,
                            Count = rec.Sum(r => r.Count)
                        });
                        foreach (var groupDiscipline in groupDisciplines)

                        {
                            DisciplineCourse elementPC = context.DisciplineCourses.FirstOrDefault(rec =>
                            rec.CourseId == model.Id && rec.DisciplineId == groupDiscipline.DisciplineId);
                            if (elementPC != null)
                            {
                                elementPC.Count += groupDiscipline.Count;
                                context.SaveChanges();
                            }
                            else
                            {
                                context.DisciplineCourses.Add(new DisciplineCourse
                                {
                                    CourseId = (int)model.Id,
                                    DisciplineId = groupDiscipline.DisciplineId,
                                    Count = groupDiscipline.Count
                                });
                                context.SaveChanges();
                            }
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

        public CourseViewModel GetCourse(int id)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Course element = context.Courses.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    return new CourseViewModel
                    {
                        Id = element.Id,
                        ClientId = element.ClientId,
                        CourseName = element.CourseName,
                        Price = element.Price,
                        DateCreate = element.DataCreate,
                        isReserved = element.isReserved,
                        DisciplineCourses = context.DisciplineCourses
                        .Where(recPC => recPC.CourseId == element.Id)
                        .Select(recPC => new DisciplineCourseViewModel
                        {
                            Id = recPC.Id,
                            CourseId = recPC.CourseId,
                            DisciplineId = recPC.DisciplineId,
                            DisciplineName = recPC.DisciplineName,
                            Count = recPC.Count
                        }).ToList()
                    };
                }
                throw new Exception("Элемент не найден");
            }
        }
    }
}
