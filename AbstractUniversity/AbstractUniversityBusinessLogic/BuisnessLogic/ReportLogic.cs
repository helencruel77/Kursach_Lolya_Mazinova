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
        public ReportLogic(IRequestLogic requestLogic, IPlaceLogic placeLogic)
        {
            this.requestLogic = requestLogic;
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
        public List<ReportRequestsViewModel> GetPlaces(ReportBindingModel model)
        {
            return requestLogic.Read(new RequestBindingModel
            {
                DataCreate = model.DataCreate,
            })
            .Select(x => new ReportRequestsViewModel
            {
                DateCreate = x.DataCreate,
                Title = x.RequestName,
                Count = x.Count,
                TypePlace = x.TypePlace
            })
           .ToList();
        }


        public void SaveRequestPlaceToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                RequestPlaces = GetRequestPlaces()
            });
        }
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                RequestPlaces = GetRequestPlaces()
            });
        }
        public void SaveRequestDisciplineToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заявок и дисциплин",
                DateCreate = model.DataCreate.Value,
                RequestPlaces = GetPlaces(model)
            });
        }

    }
}
