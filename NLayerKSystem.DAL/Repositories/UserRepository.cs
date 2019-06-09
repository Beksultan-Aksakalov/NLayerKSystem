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
    public class UserRepository : IRepository<User>
    {
        private KSysContext db;

        public UserRepository(KSysContext db)
        {
            this.db = db;
        }
        
        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
            {
                db.User.Remove(user);
            }
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public User Get(int id)
        {
            return db.User.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.User;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.User.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(User select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByUserId(int userId)
        {
            return db.User.Where(m => m.Id == userId).ToList();
        }

        public User CheckToExistUserEmail(User user)
        {
            return db.User.Where(u => u.Email == user.Email).FirstOrDefault();
        }

        public User CheckToExistUserEmailAndPassword(User user)
        {
            return db.User.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
        }

        public User GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            return db.User.Where(m => m.Id == userId).FirstOrDefault();
        }
    }
}
