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
        public void CreateOrUpdate(CourseBindingModel model)
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
                        var groupDisciplines = model.DisciplineCourses
                            .GroupBy(rec => rec.DisciplineId)
                            .Select(rec => new
                            {
                                DisciplineId = rec.Key,
                                Count = rec.Sum(r => r.Count)
                            });
                        var disciplineName = model.DisciplineCourses.Select(rec => new
                        {
                            DisciplineId = rec.DisciplineId,
                            DisciplineName = rec.DisciplineName
                        });

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

            public List<CourseViewModel> GetClientList(int ClientId)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                List<CourseViewModel> result = context.Courses.
                Where(rec => rec.ClientId ==ClientId).
                Select(rec => new CourseViewModel
                {
                    Id = rec.Id,
                    DateCreate = rec.DataCreate,
                    CourseName = rec.CourseName,
                    ClientId = rec.ClientId,
                    Price = rec.Price,
                    Status = rec.Status,
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


        public void Delete(CourseBindingModel model)
        {
            using (var context = new AbstractUniversityDatabase())
            {
                Course element = context.Courses.FirstOrDefault(rec => rec.Id ==
          model.Id);
                if (element != null)
                {
                    context.Courses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<CourseViewModel> Read(CourseBindingModel model)
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
                Status = rec.Status,
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
                        Status = element.Status,
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
