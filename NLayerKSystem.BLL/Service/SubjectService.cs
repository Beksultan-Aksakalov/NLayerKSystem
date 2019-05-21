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
    public class SubjectService : IService<SubjectDTO>
    {
        IUnitOfWork Database { get; set; }

        public SubjectService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<SubjectDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Subject, SubjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(Database.Subjects.GetAll());
        }

        public void Create(SubjectDTO model)
        {
            Subject subject = new Subject
            {
                Name = model.Name,
                Description = model.Description,
                CountCredit = model.CountCredit,
                Evaluation = model.Evaluation,
                NominationId = model.NominationId,
                EducationId = model.EducationId,
                KnowledgeId = model.KnowledgeId
            };

            Database.Subjects.Create(subject);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Subjects.Delete(id);
            Database.Save();
        }

        public void Update(SubjectDTO model)
        {
            Subject subject = new Subject
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CountCredit = model.CountCredit,
                Evaluation = model.Evaluation,
                NominationId = model.NominationId,
                EducationId = model.EducationId,
                KnowledgeId = model.KnowledgeId
            };

            Database.Subjects.Update(subject);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SubjectDTO> Find(Func<SubjectDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(SubjectDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public SubjectDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public SubjectDTO CheckToExistUserEmail(SubjectDTO model)
        {
            throw new NotImplementedException();
        }

        public SubjectDTO CheckToExistUserEmailAndPassword(SubjectDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
