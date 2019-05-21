using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        T Get(int id);
        T GetUserByRoleId(int? roleId);
        T CheckToExistUserEmail(T model);
        T CheckToExistUserEmailAndPassword(T model);
        IEnumerable<T> GetByUserId(int userId);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        IEnumerable<object> FindJoin(T select);
    }
}
