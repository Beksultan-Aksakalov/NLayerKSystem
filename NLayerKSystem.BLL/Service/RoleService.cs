using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.DAL.Interfaces;
using TestEF.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.BLL.Service
{
    public class RoleService : IService<RoleDTO>
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork database)
        {
            Database = database;
        }

        public RoleService()
        {
        }

        public IEnumerable<RoleDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Role>, List<RoleDTO>>(Database.Roles.GetAll());
        }

        public void Create(RoleDTO model)
        {
            Role role = new Role
            {
                Name = model.Name
            };

            Database.Roles.Create(role);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Roles.Delete(id);
            Database.Save();
        }

        public void Update(RoleDTO model)
        {
            Role role = new Role
            {
                Id = model.Id,
                Name = model.Name
            };

            Database.Roles.Update(role);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<RoleDTO> Find(Func<RoleDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(RoleDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetUserByRoleId(int? roleId)
        {   
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<Role, RoleDTO>(Database.Roles.GetUserByRoleId(roleId));
        }

        public RoleDTO CheckToExistUserEmail(RoleDTO model)
        {
            throw new NotImplementedException();
        }

        public RoleDTO CheckToExistUserEmailAndPassword(RoleDTO model)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
