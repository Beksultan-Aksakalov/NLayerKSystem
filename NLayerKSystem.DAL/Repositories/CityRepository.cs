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
    public class CityRepository : IRepository<City>
    {
        private KSysContext db;

        public CityRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(City item)
        {
            db.City.Add(item);
        }

        public void Delete(int id)
        {
            City city = db.City.Find(id);
            if (city != null)
            {
                db.City.Remove(city);
            }
        }

        public void Update(City item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public City Get(int id)
        {
            return db.City.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return db.City.Include(m => m.Country);
        }

        public IEnumerable<City> Find(Func<City, bool> predicate)
        {
            return db.City.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(City select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public City GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public City GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public City CheckToExistUserEmail(City model)
        {
            throw new NotImplementedException();
        }

        public City CheckToExistUserEmailAndPassword(City model)
        {
            throw new NotImplementedException();
        }
    }
}
