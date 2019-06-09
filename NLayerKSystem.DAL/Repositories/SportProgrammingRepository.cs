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
    public class SportProgrammingRepository : IRepository<SportProgramming>
    {
        private KSysContext db;

        public SportProgrammingRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(SportProgramming item)
        {
            db.SportProgramming.Add(item);
        }

        public void Delete(int id)
        {
            SportProgramming sportpr = db.SportProgramming.Find(id);
            if (sportpr != null)
            {
                db.SportProgramming.Remove(sportpr);
            }
        }

        public void Update(SportProgramming item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public SportProgramming Get(int id)
        {
            return db.SportProgramming.Find(id);
        }

        public IEnumerable<SportProgramming> GetAll()
        {
            return db.SportProgramming;
        }

        public IEnumerable<SportProgramming> Find(Func<SportProgramming, bool> predicate)
        {
            return db.SportProgramming.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(SportProgramming select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportProgramming> GetByUserId(int userId)
        {
            return db.SportProgramming.Where(m => m.UserId == userId).ToList();
        }
        
        public SportProgramming GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public SportProgramming GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SportProgramming CheckToExistUserEmail(SportProgramming model)
        {
            throw new NotImplementedException();
        }

        public SportProgramming CheckToExistUserEmailAndPassword(SportProgramming model)
        {
            throw new NotImplementedException();
        }

        public SportProgramming GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
