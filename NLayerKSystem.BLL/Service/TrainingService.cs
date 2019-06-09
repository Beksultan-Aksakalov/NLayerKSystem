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
    public class TrainingService : IService<TrainingDTO>
    {
        IUnitOfWork Database { get; set; }

        public TrainingService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<TrainingDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Training>, IEnumerable<TrainingDTO>>(Database.Trainings.GetAll());
        }

        public void Create(TrainingDTO model)
        {
            Training training = new Training
            {
                Resource = model.Resource,
                Course = model.Course,
                Duration = model.Duration,
                FinalEvaluation = model.FinalEvaluation,
                ProjectPhoto = model.ProjectPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.Trainings.Create(training);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Trainings.Delete(id);
            Database.Save();
        }

        public void Update(TrainingDTO model)
        {
            Training training = new Training
            {
                Id = model.Id,
                Resource = model.Resource,
                Course = model.Course,
                Duration = model.Duration,
                FinalEvaluation = model.FinalEvaluation,
                ProjectPhoto = model.ProjectPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.Trainings.Update(training);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TrainingDTO> Find(Func<TrainingDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(TrainingDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrainingDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Training, TrainingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Training>, IEnumerable<TrainingDTO>>(Database.Trainings.GetByUserId(userId));
        }

        public TrainingDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public TrainingDTO CheckToExistUserEmail(TrainingDTO model)
        {
            throw new NotImplementedException();
        }

        public TrainingDTO CheckToExistUserEmailAndPassword(TrainingDTO model)
        {
            throw new NotImplementedException();
        }

        public TrainingDTO GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
