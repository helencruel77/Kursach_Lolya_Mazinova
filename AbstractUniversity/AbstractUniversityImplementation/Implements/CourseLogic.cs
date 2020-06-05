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
                Course element;
                if (model.Id.HasValue)
                {
                    element = context.Courses.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Course { };
                    context.Courses.Add(element);
                }
                element.ClientId = model.ClientId == 0 ? element.ClientId : (int)model.ClientId;
                element.Price = model.Price;
                element.DataCreate = model.DateCreate;
                element.Status = model.Status; 
                context.SaveChanges();
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
                return context.Courses
                 .Where(rec => model == null || rec.Id == model.Id && model.Id.HasValue
                    ///////////////////тут datato datafrom надо или нет хз но оно тут 
                    /// || model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo
                    || model.ClientId.HasValue && rec.ClientId == model.ClientId)
                 .Include(rec => rec.Client)
                 .Select(rec => new CourseViewModel
                 {
                     Id = rec.Id,
                     ClientId = rec.ClientId,
                     Price = rec.Price,
                     DateCreate = rec.DataCreate,
                     Status = rec.Status
                 })
            .ToList();
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
                        }).ToList()
                    };
                }
                throw new Exception("Элемент не найден");
            }
        }
    }
}
