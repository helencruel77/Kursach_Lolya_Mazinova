using AbstractUniversityImplementation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityImplementation
{
    public class AbstractUniversityDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source = COMPUTER\SQLEXPRESS;Initial Catalog=AbstractUniversity;Integrated Security=True;MultipleActiveResultSets=True;");
                /////// COMPUTER\SQLEXPRESS эт твое
                /////// спасибо
                /////// DESKTOP-1L0DP37\SQLEXPRESS а это твое
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Course> Courses { set; get; }
        public virtual DbSet<Discipline> Disciplines { set; get; }
        public virtual DbSet<DisciplineCourse> DisciplineCourses { set; get; }
        public virtual DbSet<Place> Places { set; get; }
        public virtual DbSet<PlaceDiscipline> PlaceDisciplines { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<RequestPlace> RequestPlaces { set; get; }
    }
}
