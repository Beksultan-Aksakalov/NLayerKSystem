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
    public class ExperienceRepository : IRepository<Experience>
    {
        private KSysContext db;

        public ExperienceRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Experience item)
        {
            db.Experience.Add(item);
        }

        public void Delete(int id)
        {
            Experience experience = db.Experience.Find(id);
            if (experience != null)
            {
                db.Experience.Remove(experience);
            }
        }

        public void Update(Experience item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Experience Get(int id)
        {
            return db.Experience.Find(id);
        }

        public IEnumerable<Experience> GetAll()
        {
            return db.Experience;
        }

        public IEnumerable<Experience> Find(Func<Experience, bool> predicate)
        {
            return db.Experience.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Experience select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Experience> GetByUserId(int userId)
        {
            return db.Experience.Where(m => m.UserId == userId).ToList();
        }

        public Experience GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Experience GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Experience CheckToExistUserEmail(Experience model)
        {
            throw new NotImplementedException();
        }

        public Experience CheckToExistUserEmailAndPassword(Experience model)
        {
            throw new NotImplementedException();
        }

        public Experience GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
