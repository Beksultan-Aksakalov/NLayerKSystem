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
    public class ReviewRepository : IRepository<Review>
    {
        private KSysContext db;

        public ReviewRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Review item)
        {
            db.Review.Add(item);
        }

        public void Delete(int id)
        {
            Review review = db.Review.Find(id);
            if (review != null)
            {
                db.Review.Remove(review);
            }
        }

        public void Update(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Review Get(int id)
        {
            return db.Review.Find(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Review;
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return db.Review.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(Review select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetByUserId(int userId)
        {
            return db.Review.Where(m => m.UserId == userId).ToList();
        }
        
        public Review GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Review GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Review CheckToExistUserEmail(Review model)
        {
            throw new NotImplementedException();
        }

        public Review CheckToExistUserEmailAndPassword(Review model)
        {
            throw new NotImplementedException();
        }

        public Review GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
