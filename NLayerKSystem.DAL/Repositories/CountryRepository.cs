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
    public class CountryRepository : IRepository<Country>
    {
        private KSysContext db;

        public CountryRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Country item)
        {
            db.Country.Add(item);
        }

        public void Delete(int id)
        {
            Country country = db.Country.Find(id);
            if (country != null)
            {
                db.Country.Remove(country);
            }
        }

        public void Update(Country item)
        {
              db.Entry(item).State = EntityState.Modified;
        }

        public Country Get(int id)
        {
            return db.Country.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Country;
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return db.Country.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Country select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        
        public Country GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Country GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Country CheckToExistUserEmail(Country model)
        {
            throw new NotImplementedException();
        }

        public Country CheckToExistUserEmailAndPassword(Country model)
        {
            throw new NotImplementedException();
        }

        public Country GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
