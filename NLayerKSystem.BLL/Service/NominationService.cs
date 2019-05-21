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
    public class NominationService : IService<NominationDTO>
    {
        IUnitOfWork Database { get; set; }

        public NominationService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<NominationDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Nomination, NominationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Nomination>, List<NominationDTO>>(Database.Nominations.GetAll());
        }

        public void Create(NominationDTO model)
        {
            Nomination nomination = new Nomination
            {
                Name = model.Name,
                Description = model.Description,
                Photo = model.Photo
            };

            Database.Nominations.Create(nomination);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Nominations.Delete(id);
            Database.Save();
        }

        public void Update(NominationDTO model)
        {
            Nomination nominaation = new Nomination
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Photo = model.Photo
            };

            Database.Nominations.Update(nominaation);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<NominationDTO> Find(Func<NominationDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(NominationDTO select)
        {
            throw new NotImplementedException();
        }

        public NominationDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public NominationDTO CheckToExistUserEmail(NominationDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NominationDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public NominationDTO CheckToExistUserEmailAndPassword(NominationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
