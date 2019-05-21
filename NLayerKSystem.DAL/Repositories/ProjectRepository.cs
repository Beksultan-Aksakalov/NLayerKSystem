using NLayerKSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private KSysContext db;

        public ProjectRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Project item)
        {
            db.Project.Add(item);
        }

        public void Delete(int id)
        {
            Project project = db.Project.Find(id);
            if (project != null)
            {
                db.Project.Remove(project);
            }
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Project Get(int id)
        {
            return db.Project.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Project;
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return db.Project.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(Project select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Project GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Project GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Project CheckToExistUserEmail(Project model)
        {
            throw new NotImplementedException();
        }

        public Project CheckToExistUserEmailAndPassword(Project model)
        {
            throw new NotImplementedException();
        }
    }
}
