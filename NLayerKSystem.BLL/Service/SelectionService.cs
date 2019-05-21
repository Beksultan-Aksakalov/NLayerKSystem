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
using static NLayerKSystem.DAL.Repositories.SelectionRepository;

namespace NLayerKSystem.BLL.Service
{
    public class SelectionService : IService<SelectionDTO>
    {
        IUnitOfWork Database { get; set; }

        public SelectionService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<SelectionDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Selection, SelectionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Selection>, IEnumerable<SelectionDTO>>(Database.Selections.GetAll());
        }

        public void Create(SelectionDTO model)
        {
            Selection selection = new Selection
            {
                Name = model.Name,
                EducationId = model.EducationId,
                ExperienceId = model.ExperienceId,
                TrainingId = model.TrainingId,
                CertificationTestId = model.CertificationTestId,
                SportProgrammingId = model.SportProgrammingId
            };

            Database.Selections.Create(selection);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Selections.Delete(id);
            Database.Save();
        }

        public void Update(SelectionDTO model)
        {
            Selection selection = new Selection
            {
                Id = model.Id,
                Name = model.Name,
                EducationId = model.EducationId,
                ExperienceId = model.ExperienceId,
                TrainingId = model.TrainingId,
                CertificationTestId = model.CertificationTestId,
                SportProgrammingId = model.SportProgrammingId
            };

            Database.Selections.Update(selection);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SelectionDTO> Find(Func<SelectionDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(SelectionDTO select)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SelectionDTO, Selection>()).CreateMapper();
            IEnumerable<SelectionJoinQueryResult> response = (IEnumerable<SelectionJoinQueryResult>)Database.Selections.FindJoin(mapper.Map<SelectionDTO, Selection>(select));

            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<Education, EducationDTO>()).CreateMapper();
            var mapperExperience = new MapperConfiguration(cfg => cfg.CreateMap<Experience, ExperienceDTO>()).CreateMapper();
            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();
            var mapperCertificationTest = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTest, CertificationTestDTO>()).CreateMapper();
            var mapperSportProgramming = new MapperConfiguration(cfg => cfg.CreateMap<SportProgramming, SportProgrammingDTO>()).CreateMapper();

            return response.GroupBy(
                m => m.User,
                (k, c) => new SelectionJoinQueryResultDTO()
                {
                    User = mapperUser.Map<User, UserDTO>(k),
                    Educations = mapperEducation.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(c.Select(m => m.Education)),
                    Experiences = mapperExperience.Map<IEnumerable<Experience>, IEnumerable<ExperienceDTO>>(c.Select(m => m.Experience)),
                    Trainings = mapperTraining.Map<IEnumerable<Training>, IEnumerable<TrainingDTO>>(c.Select(m => m.Training)),
                    CertificationTests = mapperCertificationTest.Map<IEnumerable<CertificationTest>, IEnumerable<CertificationTestDTO>>(c.Select(m => m.CertificationTest)),
                    SportProgrammings = mapperSportProgramming.Map<IEnumerable<SportProgramming>, IEnumerable<SportProgrammingDTO>>(c.Select(m => m.SportProgramming))
                }
                );
        }

        public SelectionDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SelectionDTO CheckToExistUserEmail(SelectionDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectionDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public SelectionDTO CheckToExistUserEmailAndPassword(SelectionDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
