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
    public class CertificationTestRepository : IRepository<CertificationTest>
    {
        private KSysContext db;

        public CertificationTestRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(CertificationTest item)
        {
            db.CertificationTest.Add(item);
        }

        public void Delete(int id)
        {
            CertificationTest certest = db.CertificationTest.Find(id);
            if (certest != null)
            {
                db.CertificationTest.Remove(certest);
            }
        }

        public void Update(CertificationTest item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public CertificationTest Get(int id)
        {
            return db.CertificationTest.Find(id);
        }

        public IEnumerable<CertificationTest> GetAll()
        {
            return db.CertificationTest;
        }

        public IEnumerable<CertificationTest> Find(Func<CertificationTest, bool> predicate)
        {
            return db.CertificationTest.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(CertificationTest select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CertificationTest> GetByUserId(int userId)
        {
            return db.CertificationTest.Where(m => m.UserId == userId).ToList();
        }

        public CertificationTest GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public CertificationTest GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public CertificationTest CheckToExistUserEmail(CertificationTest model)
        {
            throw new NotImplementedException();
        }

        public CertificationTest CheckToExistUserEmailAndPassword(CertificationTest model)
        {
            throw new NotImplementedException();
        }

        public CertificationTest GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
