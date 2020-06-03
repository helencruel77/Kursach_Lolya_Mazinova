using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.Enums;
using AbstractUniversityBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BuisnessLogic
{
    public class MainLogic
    {
        private readonly IRequestLogic requestLogic;
        private readonly ICourseLogic courseLogic;
        public MainLogic(IRequestLogic requestLogic, ICourseLogic courseLogic)
        {
            this.courseLogic = courseLogic;
            this.requestLogic = requestLogic;
        }
        public void CreateCourse(CreateCourseBindingModel model)
        {
            courseLogic.CreateOrUpdate(new CourseBindingModel
            {
                Name = model.Name,
                DisciplineId = model.DisciplineId,
                ClientId = model.ClientId,
                Price = model.Price,
                DataCreate = DateTime.Now,
                Status = CourseStatus.Зарезервирован
            });
        }
        public void TakeCourseInWork(ChangeStatusBindingModel model)
        {
            var order = courseLogic.Read(new CourseBindingModel { Id = model.CourseId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден курс");
            }

            if (order.Status != CourseStatus.Оплачен)
            {
                throw new Exception("Заказ не в статусе \"Оплачен\"");
            }

            courseLogic.CreateOrUpdate(new CourseBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                DisciplineId = order.DisciplineId,
                Price = order.Price,
                DataCreate = order.DataCreate,
                Status = CourseStatus.Выполняется
            });
        }

        public void FinishCourse(ChangeStatusBindingModel model)
        {
            var order = courseLogic.Read(new CourseBindingModel { Id = model.CourseId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден курс");
            }

            if (order.Status != CourseStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            courseLogic.CreateOrUpdate(new CourseBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                DisciplineId = order.DisciplineId,
                Price = order.Price,
                DataCreate = order.DataCreate,
                Status = CourseStatus.Пройден
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = courseLogic.Read(new CourseBindingModel { Id = model.CourseId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден курс");
            }

            if (order.Status != CourseStatus.Зарезервирован)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            courseLogic.CreateOrUpdate(new CourseBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                DisciplineId = order.DisciplineId,
                Price = order.Price,
                DataCreate = order.DataCreate,
                Status = CourseStatus.Оплачен
            });
        }

        public void CreateRequest(RequestPlaceBindingModel model)
        {
            requestLogic.AddPlace(model);
        }
    }
}
