using AbstractUniversityBusinessLogic.BuisnessLogic;
using AbstractUniversityBusinessLogic.Interfaces;
using AbstractUniversityImplementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace AbstractUniversityImplementation.Implements
{
    public class BackUpLogic : IBackUp
    {
        public void SaveJsonRequest(string folderName)
        {
            string fileName = $"{folderName}\\Request.json";
            using (var context = new AbstractUniversityDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Request>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Requests);
                }
            }
        }

        public void SaveJsonRequestPlaces(string folderName)
        {
            string fileName = $"{folderName}\\RequestPlaces.json";
            using (var context = new AbstractUniversityDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<RequestPlace>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.RequestPlaces);
                }
            }
        }
        public void SaveJsonPlaceDiscipline(string folderName)
        {
            string fileName = $"{folderName}\\PlaceDiscipline.json";
            using (var context = new AbstractUniversityDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<PlaceDiscipline>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.PlaceDisciplines);
                }
            }
        }
        public void SaveJsonDiscipline(string folderName)
        {
            string fileName = $"{folderName}\\Discipline.json";
            using (var context = new AbstractUniversityDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Discipline>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Disciplines);
                }
            }
        }
        
        public void SaveJsonPlace(string folderName)
        {
            string fileName = $"{folderName}\\Place.json";
            using (var context = new AbstractUniversityDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Place>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Places);
                }
            }
        }
        public void SaveXmlRequest(string folderName)
        {
            string fileNameDop = $"{folderName}\\Request.xml";
            using (var context = new AbstractUniversityDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Request>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Requests);
                }
            }
        }
        public void SaveXmlRequestPlaces(string folderName)
        {
            string fileNameDop = $"{folderName}\\RequestPlaces.xml";
            using (var context = new AbstractUniversityDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<RequestPlace>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.RequestPlaces);
                }
            }
        }
        public void SaveXmlPlaceDiscipline(string folderName)
        {
            string fileNameDop = $"{folderName}\\PlaceDiscipline.xml";
            using (var context = new AbstractUniversityDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<PlaceDiscipline>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.PlaceDisciplines);
                }
            }
        }
        public void SaveXmlDiscipline(string folderName)
        {
            string fileNameDop = $"{folderName}\\Discipline.xml";
            using (var context = new AbstractUniversityDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Discipline>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Disciplines);
                }
            }
        }
        public void SaveXmlPlace(string folderName)
        {
            string fileNameDop = $"{folderName}\\Place.xml";
            using (var context = new AbstractUniversityDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Place>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Places);
                }
            }
        }
    }
}
