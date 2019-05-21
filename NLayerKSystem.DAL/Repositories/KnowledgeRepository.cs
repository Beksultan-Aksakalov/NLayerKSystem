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
    public class KnowledgeRepository:IRepository<Knowledge>
    {
        private KSysContext db;

        public KnowledgeRepository(KSysContext db)
        {
            this.db = db;
        }
        public void Create(Knowledge item)
        {
            db.Knowledge.Add(item);
        }

        public void Delete(int id)
        {
            Knowledge knowledge = db.Knowledge.Find(id);
            if (knowledge != null)
            {
                db.Knowledge.Remove(knowledge);
            }
        }

        public void Update(Knowledge item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Knowledge Get(int id)
        {
            return db.Knowledge.Find(id);
        }

        public IEnumerable<Knowledge> GetAll()
        {
            return db.Knowledge;
        }

        public IEnumerable<Knowledge> Find(Func<Knowledge, bool> predicate)
        {
            return db.Knowledge.Where(predicate).ToList();
        }
        
        public IEnumerable<object> FindJoin(Knowledge select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Knowledge> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
       
        public Knowledge GetByUserRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public Knowledge GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public Knowledge CheckToExistUserEmail(Knowledge model)
        {
            throw new NotImplementedException();
        }

        public Knowledge CheckToExistUserEmailAndPassword(Knowledge model)
        {
            throw new NotImplementedException();
        }
    }
}
