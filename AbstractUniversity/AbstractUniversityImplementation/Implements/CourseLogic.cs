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
                element.DataCreate = model.DataCreate;
             //   element.IsReserved = model.IsReserved; 
             //Я убрала потому что мы заменили на статус, не знаю надо тут че менять или нет
                context.SaveChanges();
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
                     DataCreate = rec.DataCreate,
             //        IsReserved = rec.IsReserved,
                     ClientName = rec.Client.ClientName,
                     ClientLastName = rec.Client.ClientLastName,
                 })
            .ToList();
            }
        }
    }
}
