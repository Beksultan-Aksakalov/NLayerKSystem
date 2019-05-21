using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.BLL.Interface
{
    public interface IService<T>
    {
        IEnumerable<T> GetTable();
        void Create(T model);
        void Delete(int id);
        void Update(T model);
        void Dispose();
        T GetUserByRoleId(int? roleId);
        T CheckToExistUserEmail(T model);
        T CheckToExistUserEmailAndPassword (T model);
        IEnumerable<T> GetByUserId(int userId);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        IEnumerable<Object> FindJoin(T select);
    }
}
