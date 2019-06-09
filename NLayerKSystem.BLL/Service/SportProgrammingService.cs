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
    public class SportProgrammingService : IService<SportProgrammingDTO>
    {
        IUnitOfWork Database { get; set; }

        public SportProgrammingService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<SportProgrammingDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportProgramming, SportProgrammingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SportProgramming>, IEnumerable<SportProgrammingDTO>>(Database.SportProgrammings.GetAll());
        }

        public void Create(SportProgrammingDTO model)
        {
            SportProgramming sp = new SportProgramming
            {
                Resourse = model.Resourse,
                Level = model.Level,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.SportProgrammings.Create(sp);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.SportProgrammings.Delete(id);
            Database.Save();
        }

        public void Update(SportProgrammingDTO model)
        {
            SportProgramming sp = new SportProgramming
            {
                Id = model.Id,
                Resourse = model.Resourse,
                Level = model.Level,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.SportProgrammings.Update(sp);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SportProgrammingDTO> Find(Func<SportProgrammingDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(SportProgrammingDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportProgrammingDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportProgramming, SportProgrammingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SportProgramming>, IEnumerable<SportProgrammingDTO>>(Database.SportProgrammings.GetByUserId(userId));
        }

        public SportProgrammingDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SportProgrammingDTO CheckToExistUserEmail(SportProgrammingDTO model)
        {
            throw new NotImplementedException();
        }

        public SportProgrammingDTO CheckToExistUserEmailAndPassword(SportProgrammingDTO model)
        {
            throw new NotImplementedException();
        }

        public SportProgrammingDTO GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
