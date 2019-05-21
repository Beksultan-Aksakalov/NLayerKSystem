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
    public class ExperienceService : IService<ExperienceDTO>
    {
        IUnitOfWork Database { get; set; }

        public ExperienceService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<ExperienceDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Experience, ExperienceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Experience>, IEnumerable<ExperienceDTO>>(Database.Experiences.GetAll());
        }

        public void Create(ExperienceDTO model)
        {
            Experience experience = new Experience
            {
               CompanyName = model.CompanyName,
               CountExperience = model.CountExperience,
               CityId = model.CityId,
               KnowledgeId = model.KnowledgeId,
               UserId = model.UserId
            };

            Database.Experiences.Create(experience);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Experiences.Delete(id);
            Database.Save();
        }

        public void Update(ExperienceDTO model)
        {
            Experience experience = new Experience
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                CountExperience = model.CountExperience,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.Experiences.Update(experience);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ExperienceDTO> Find(Func<ExperienceDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(ExperienceDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperienceDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Experience, ExperienceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Experience>, IEnumerable<ExperienceDTO>>(Database.Experiences.GetByUserId(userId));
        }

        public ExperienceDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public ExperienceDTO CheckToExistUserEmail(ExperienceDTO model)
        {
            throw new NotImplementedException();
        }

        public ExperienceDTO CheckToExistUserEmailAndPassword(ExperienceDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
