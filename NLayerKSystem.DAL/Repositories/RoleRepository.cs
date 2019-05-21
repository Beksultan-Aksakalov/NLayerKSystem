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
    public class RoleRepository : IRepository<Role>
    {
        private KSysContext db;

        public RoleRepository(KSysContext db)
        {
            this.db = db;
        }
        
        public void Create(Role item)
        {
            db.Role.Add(item);
        }

        public void Delete(int id)
        {
            Role role = db.Role.Find(id);
            if (role != null)
            {
                db.Role.Remove(role);
            }
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Role Get(int id)
        {
            return db.Role.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Role;
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return db.Role.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Role select)
        {
            throw new NotImplementedException();
        }

        public Role GetUserByRoleId(int? roleId)
        {
            return db.Role.Find(roleId);
        }

        public Role CheckToExistUserEmail(Role model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Role CheckToExistUserEmailAndPassword(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
