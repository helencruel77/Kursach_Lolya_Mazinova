using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface ICourseLogic
    {
        List<CourseViewModel> Read(CourseBindingModel model);

        void CreateOrUpdate(CourseBindingModel model);

        void Delete(CourseBindingModel model);
    }
}
