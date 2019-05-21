using NLayerKSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private KSysContext db;
        private UserRepository userRepo;
        private RoleRepository roleRepo;
        private EducationRepository educationRepo;
        private ExperienceRepository experienceRepo;
        private TrainingRepository trainingRepo;
        private CertificationTestRepository certificationTestRepo;
        private SportProgrammingRepository sportPrRepo;
        private ReviewRepository reviewRepo;
        private KnowledgeRepository knowledgePrRepo;
        private SubjectRepository subjectRepo;
        private CountryRepository countryRepo;
        private CityRepository cityRepo;
        private ProjectRepository projectRepo;
        private NominationRepository nominationRepo;
        private SelectionRepository selectionRepo;
        private SelectionUserRepository selectionUserRepo;
        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            db = new KSysContext();
        }

        public IRepository<Selection> Selections
        {
            get
            {
                if (selectionRepo == null)
                {
                    selectionRepo = new SelectionRepository(db);
                }
                return selectionRepo;
            }
        }

        public IRepository<SelectionUser> SelectionUsers
        {
            get
            {
                if (selectionUserRepo == null)
                {
                    selectionUserRepo = new SelectionUserRepository(db);
                }
                return selectionUserRepo;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepo == null)
                {
                    userRepo = new UserRepository(db);
                }
                return userRepo;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepo == null)
                {
                    roleRepo = new RoleRepository(db);
                }
                return roleRepo;
            }
        }

        public IRepository<Education> Educations
        {
            get
            {
                if (educationRepo == null)
                {
                    educationRepo = new EducationRepository(db);
                }
                return educationRepo;
            }
        }

        public IRepository<Experience> Experiences
        {
            get
            {
                if (experienceRepo == null)
                {
                    experienceRepo = new ExperienceRepository(db);
                }
                return experienceRepo;
            }
        }

        public IRepository<Training> Trainings
        {
            get
            {
                if (trainingRepo == null)
                {
                    trainingRepo = new TrainingRepository(db);
                }
                return trainingRepo;
            }
        }

        public IRepository<CertificationTest> CertificationTests
        {
            get
            {
                if (certificationTestRepo == null)
                {
                    certificationTestRepo = new CertificationTestRepository(db);
                }
                return certificationTestRepo;
            }
        }

        public IRepository<SportProgramming> SportProgrammings
        {
            get
            {
                if (sportPrRepo == null)
                {
                    sportPrRepo = new SportProgrammingRepository(db);
                }
                return sportPrRepo;
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepo == null)
                {
                    reviewRepo = new ReviewRepository(db);
                }
                return reviewRepo;
            }
        }

        public IRepository<Knowledge> Knowledges
        {
            get
            {
                if (knowledgePrRepo == null)
                {
                    knowledgePrRepo = new KnowledgeRepository(db);
                }
                return knowledgePrRepo;
            }
        }

        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectRepo == null)
                {
                    subjectRepo = new SubjectRepository(db);
                }
                return subjectRepo;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                if (countryRepo == null)
                {
                    countryRepo = new CountryRepository(db);
                }
                return countryRepo;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepo == null)
                {
                    cityRepo = new CityRepository(db);
                }
                return cityRepo;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepo == null)
                {
                    projectRepo = new ProjectRepository(db);
                }
                return projectRepo;
            }
        }

        public IRepository<Nomination> Nominations
        {
            get
            {
                if (nominationRepo == null)
                {
                    nominationRepo = new NominationRepository(db);
                }
                return nominationRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
