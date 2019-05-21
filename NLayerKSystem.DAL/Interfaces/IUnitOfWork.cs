using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<City> Cities { get; }
        IRepository<Country> Countries { get; }
        IRepository<Role> Roles { get; }
        IRepository<User> Users { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Education> Educations { get; }
        IRepository<Knowledge> Knowledges { get; }
        IRepository<Nomination> Nominations { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Experience> Experiences { get; }
        IRepository<Project> Projects { get; }
        IRepository<Training> Trainings { get; }
        IRepository<CertificationTest> CertificationTests { get; }
        IRepository<SportProgramming> SportProgrammings { get; }
        IRepository<Selection> Selections { get; }
        IRepository<SelectionUser> SelectionUsers { get; }
        void Save();
        void Dispose();
    }
}
