using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.Service
{
    public class UserService : IService<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork database)
        {
            Database = database;
        }

        public UserService()
        {
        }

        public IEnumerable<UserDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(Database.Users.GetAll());
        }

        public void Create(UserDTO model)
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Photo = model.Photo,
                CityId = model.CityId,
                RoleId = model.RoleId
            };

            Database.Users.Create(user);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public void Update(UserDTO model)
        {
            User user = new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Photo = model.Photo,
                CityId = model.CityId,
                RoleId = model.RoleId
            };

            Database.Users.Update(user);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<UserDTO> Find(Func<UserDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(UserDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(Database.Users.GetByUserId(userId));
        }

        public UserDTO CheckToExistUserEmail(UserDTO model)
        {
            User user = new User
            {
                Email = model.Email
            };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(Database.Users.CheckToExistUserEmail(user));
        }

        public UserDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public UserDTO CheckToExistUserEmailAndPassword(UserDTO model)
        {
            User user = new User
            {
                Email = model.Email,
                Password = model.Password
            };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(Database.Users.CheckToExistUserEmail(user));
        }
    }
}
