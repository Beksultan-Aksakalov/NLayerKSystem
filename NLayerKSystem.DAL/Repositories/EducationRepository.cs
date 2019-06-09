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
    public class EducationRepository : IRepository<Education>
    {
        private KSysContext db;

        public EducationRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Education item)
        {
            db.Education.Add(item);
        }

        public void Delete(int id)
        {
            Education education = db.Education.Find(id);
            if (education != null)
            {
                db.Education.Remove(education);
            }
        }

        public void Update(Education item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Education Get(int id)
        {
            return db.Education.Find(id);
        }

        public IEnumerable<Education> GetByUserId(int id)
        {
            return db.Education.Where(m => m.UserId == id).ToList();
        }

        public IEnumerable<Education> GetAll()
        {
            return db.Education;
        }

        public IEnumerable<Education> Find(Func<Education, bool> predicate)
        {
            return db.Education.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(Education select)
        {
            throw new NotImplementedException();
        }

        public Education GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Education GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Education CheckToExistUserEmail(Education model)
        {
            throw new NotImplementedException();
        }

        public Education CheckToExistUserEmailAndPassword(Education model)
        {
            throw new NotImplementedException();
        }

        public Education GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
