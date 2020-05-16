using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractUniversity
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPlaceLogic, PlaceLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDisciplineLogic, DisciplineLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
