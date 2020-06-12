using AbstractUniversityBusinessLogic.BindingModels;
using AbstractUniversityBusinessLogic.HelperModels;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractUniversityBusinessLogic.BuisnessLogic
{
    public class ReportLogic
    {
        
        private readonly IRequestLogic requestLogic;
        private readonly IPlaceLogic placeLogic;
        private readonly ICourseLogic courseLogic;
        private readonly IDisciplineLogic disciplineLogic;

        public ReportLogic(IRequestLogic requestLogic, IPlaceLogic placeLogic, IDisciplineLogic disciplineLogic, ICourseLogic courseLogic)
        {
            this.requestLogic = requestLogic;
            this.courseLogic = courseLogic;
            this.disciplineLogic = disciplineLogic;
            this.placeLogic = placeLogic;

        }
       
        public List<ReportRequestPlacesViewModel> GetRequestPlaces()
        {
            var places = placeLogic.Read(null);
            var requests = requestLogic.Read(null);
            var list = new List<ReportRequestPlacesViewModel>();
            foreach (var request in requests)
            {
                var record = new ReportRequestPlacesViewModel
                { 
                    RequestName = request.RequestName,
                    Places = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var place in places)
                {
                    if (request.RequestPlaces.ContainsKey(place.Id))
                    {
                        record.Places.Add(new Tuple<string, int>(place.TypePlace,
                       request.RequestPlaces[place.Id].Item2));
                        record.TotalCount +=
                       request.RequestPlaces[place.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportCoursePlaceViewModel> GetCoursePlace(ReportBindingModel model)
        {
            List<ReportCoursePlaceViewModel> reportRD = new List<ReportCoursePlaceViewModel>();
            {
                var Courses = requestLogic.Read(new RequestBindingModel
                {
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo
                });

                var courses = courseLogic.GetList();
                var places = placeLogic.Read(null);
                foreach (var course in courses.Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                {
                    foreach (var courseDis in course.DisciplineCourses.Where(rec => rec.CourseId == course.Id))
                    {
                        foreach (var place in places.Where(x => x.Id == courseDis.DisciplineId))

                            reportRD.Add(new ReportCoursePlaceViewModel()
                            {
                                DateCreate = course.DateCreate,
                                TypePlace = place.TypePlace,
                                CourseName = course.CourseName
                            });
                    }
                }
            }
            return reportRD.ToList();
        }

        public List<ReportRequestsViewModel> GetPlaces(ReportBindingModel model)
        {
            List<ReportRequestsViewModel> reportRD = new List<ReportRequestsViewModel>();
            {
                var requests = requestLogic.Read(new RequestBindingModel
                {
                    DateFrom = model.DateFrom,
                    DateTo = model.DateTo
                });

                var courses = courseLogic.GetList(); 
                var places = placeLogic.Read(null);
                foreach (var course in courses.Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                {
                    foreach (var courseDis in course.DisciplineCourses.Where(rec => rec.CourseId == course.Id))
                    {
                        foreach (var place in places.Where(x => x.Id == courseDis.DisciplineId))

                            reportRD.Add(new ReportRequestsViewModel()
                            {
                                DateCreate = course.DateCreate,
                                TypePlace = place.TypePlace,
                                Count = courseDis.Count,
                                Title = course.CourseName
                            });
                    }
                }
                foreach (var request in requests)
                {
                    foreach (var place in request.RequestPlaces)
                    {
                        reportRD.Add(new ReportRequestsViewModel()
                        {
                            DateCreate = request.DateCreate,
                            TypePlace = place.Value.Item1,
                            Count = place.Value.Item2,
                            Title = request.RequestName
                        });
                    }
                }
            }
            return reportRD.OrderBy(x => x.DateCreate).ToList();

        }
        
        public void SaveRequestPlaceToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                DisciplineCourses = null, 
                RequestPlaces = GetRequestPlaces()
            });
        }
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                DisciplineCourses = null,
                RequestPlaces = GetRequestPlaces()
            });
        }
        public void SaveRequestDisciplineToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo()
            {
                FileName = model.FileName,
                Title = "Список заявок и дисциплин",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                CoursePlaces = null,
                RequestPlaces = GetPlaces(model)
            });
        }
        public void SaveCoursePlaceToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo()
            {
                FileName = model.FileName,
                Title = "Список курсов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                RequestPlaces = null,
                CoursePlaces = GetCoursePlace(model)
            });
        }

    }
}
