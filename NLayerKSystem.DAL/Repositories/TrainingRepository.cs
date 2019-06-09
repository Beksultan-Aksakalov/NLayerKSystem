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
    public class TrainingRepository : IRepository<Training>
    {
        private KSysContext db;

        public TrainingRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Training item)
        {
            db.Training.Add(item);
        }

        public void Delete(int id)
        {
            Training training = db.Training.Find(id);
            if (training != null)
            {
                db.Training.Remove(training);
            }
        }

        public void Update(Training item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Training Get(int id)
        {
            return db.Training.Find(id);
        }

        public IEnumerable<Training> GetAll()
        {
            return db.Training;
        }

        public IEnumerable<Training> Find(Func<Training, bool> predicate)
        {
            return db.Training.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Training select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Training> GetByUserId(int userId)
        {
            return db.Training.Where(m => m.UserId == userId).ToList();
        }
        
        public Training GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Training GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Training CheckToExistUserEmail(Training model)
        {
            throw new NotImplementedException();
        }

        public Training CheckToExistUserEmailAndPassword(Training model)
        {
            throw new NotImplementedException();
        }

        public Training GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
