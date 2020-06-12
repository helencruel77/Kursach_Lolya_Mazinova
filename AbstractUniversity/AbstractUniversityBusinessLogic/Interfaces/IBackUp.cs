using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.Interfaces
{
    public interface IBackUp
    {
        void SaveJsonRequest(string folderName);
        void SaveJsonRequestPlaces(string folderName);
        void SaveJsonPlaceDiscipline(string folderName);
        void SaveJsonDiscipline(string folderName);
        void SaveJsonPlace(string folderName);
        void SaveXmlRequest(string folderName);
        void SaveXmlRequestPlaces(string folderName);
        void SaveXmlPlaceDiscipline(string folderName);
        void SaveXmlDiscipline(string folderName);
        void SaveXmlPlace(string folderName);
    }
}
