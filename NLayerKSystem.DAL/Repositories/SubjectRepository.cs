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
    public class SubjectRepository : IRepository<Subject>
    {
        private KSysContext db;

        public SubjectRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Subject item)
        {
            db.Subject.Add(item);
        }

        public void Delete(int id)
        {
            Subject subject = db.Subject.Find(id);
            if (subject != null)
            {
                db.Subject.Remove(subject);
            }
        }

        public void Update(Subject item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Subject Get(int id)
        {
            return db.Subject.Find(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subject;
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return db.Subject.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(Subject select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Subject GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Subject GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Subject CheckToExistUserEmail(Subject model)
        {
            throw new NotImplementedException();
        }

        public Subject CheckToExistUserEmailAndPassword(Subject model)
        {
            throw new NotImplementedException();
        }

        public Subject GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
