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
    public class SelectionUserService : IService<SelectionUserDTO>
    {
        IUnitOfWork Database { get; set; }

        public SelectionUserService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<SelectionUserDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SelectionUser, SelectionUserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SelectionUser>, IEnumerable<SelectionUserDTO>>(Database.SelectionUsers.GetAll());
        }

        public void Create(SelectionUserDTO model)
        {
            SelectionUser selectionUser = new SelectionUser
            {
                SelectionId = model.SelectionId,
                UserId = model.UserId,
                IsSelected = model.IsSelected
            };

            Database.SelectionUsers.Create(selectionUser);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.SelectionUsers.Delete(id);
            Database.Save();
        }

        public void Update(SelectionUserDTO model)
        {
            SelectionUser selectionUser = new SelectionUser
            {
                Id = model.Id,
                SelectionId = model.SelectionId,
                UserId = model.UserId,
                IsSelected = model.IsSelected
            };

            Database.SelectionUsers.Update(selectionUser);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SelectionUserDTO> Find(Func<SelectionUserDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(SelectionUserDTO select)
        {
            throw new NotImplementedException();
        }

        public SelectionUserDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SelectionUserDTO CheckToExistUserEmail(SelectionUserDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectionUserDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public SelectionUserDTO CheckToExistUserEmailAndPassword(SelectionUserDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
