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
    public class NominationRepository : IRepository<Nomination>
    {
        private KSysContext db;

        public NominationRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Nomination item)
        {
            db.Nomination.Add(item);
        }

        public void Delete(int id)
        {
            Nomination nomination = db.Nomination.Find(id);
            if (nomination != null)
            {
                db.Nomination.Remove(nomination);
            }
        }

        public void Update(Nomination item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Nomination Get(int id)
        {
            return db.Nomination.Find(id);
        }

        public IEnumerable<Nomination> GetAll()
        {
            return db.Nomination;
        }

        public IEnumerable<Nomination> Find(Func<Nomination, bool> predicate)
        {
            return db.Nomination.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Nomination select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nomination> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        
        public Nomination GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Nomination GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Nomination CheckToExistUserEmail(Nomination model)
        {
            throw new NotImplementedException();
        }

        public Nomination CheckToExistUserEmailAndPassword(Nomination model)
        {
            throw new NotImplementedException();
        }

        public Nomination GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
