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
    public class SelectionUserRepository : IRepository<SelectionUser>
    {
        private KSysContext db;

        public SelectionUserRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(SelectionUser item)
        {
            db.SelectionUser.Add(item);
        }

        public void Delete(int id)
        {
            SelectionUser selectionUser = db.SelectionUser.Find(id);
            if (selectionUser != null)
            {
                db.SelectionUser.Remove(selectionUser);
            }
        }

        public void Update(SelectionUser item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public SelectionUser Get(int id)
        {
            return db.SelectionUser.Find(id);
        }

        public IEnumerable<SelectionUser> GetAll()
        {
            return db.SelectionUser;
        }

        public IEnumerable<SelectionUser> Find(Func<SelectionUser, bool> predicate)
        {
            return db.SelectionUser.Where(predicate).ToList();
        }

        public IEnumerable<object> FindJoin(SelectionUser select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectionUser> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        
        public SelectionUser GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public SelectionUser GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SelectionUser CheckToExistUserEmail(SelectionUser model)
        {
            throw new NotImplementedException();
        }

        public SelectionUser CheckToExistUserEmailAndPassword(SelectionUser model)
        {
            throw new NotImplementedException();
        }

        public SelectionUser GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
