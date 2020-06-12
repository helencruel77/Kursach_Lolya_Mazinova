using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface ICourseLogic
    {
        void Delete(int id);
        void CreateCourse(CourseBindingModel model);
        void UpdateCourse(CourseBindingModel model);
        List<CourseViewModel> GetClientList(int ClientId);
        CourseViewModel GetCourse(int id);
        List<CourseViewModel> GetList();
        DateTime CourseReservation(int id);
        void SendEmail(string mailAddress, string subject, string text, string path);
    }
}
