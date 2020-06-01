using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation;
using AbstractUniversityImplementation.Implements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace AbstractUniversityClientView.App_Start
{
    public class Program
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
        public static IUnityContainer Container => container.Value;
        #endregion
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, AbstractUniversityDatabase>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlaceLogic, PlaceLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<IDisciplineLogic, DisciplineLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<ICourseLogic, CourseLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<IRequestLogic, RequestLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
        }
    }
}