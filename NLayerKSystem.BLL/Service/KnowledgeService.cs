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
    public class KnowledgeService : IService<KnowledgeDTO>
    {
        IUnitOfWork Database { get; set; }

        public KnowledgeService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<KnowledgeDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Knowledge>, IEnumerable<KnowledgeDTO>>(Database.Knowledges.GetAll());
        }

        public void Create(KnowledgeDTO model)
        {
            Knowledge knowledge = new Knowledge
            {
                Name = model.Name,
                Description = model.Description,
                ParentId = model.ParentId                
            };

            Database.Knowledges.Create(knowledge);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Knowledges.Delete(id);
            Database.Save();
        }

        public void Update(KnowledgeDTO model)
        {
            Knowledge knowledge = new Knowledge
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ParentId = model.ParentId
            };

            Database.Knowledges.Update(knowledge);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<KnowledgeDTO> Find(Func<KnowledgeDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(KnowledgeDTO select)
        {
            throw new NotImplementedException();
        }

        public KnowledgeDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public KnowledgeDTO CheckToExistUserEmail(KnowledgeDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KnowledgeDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public KnowledgeDTO CheckToExistUserEmailAndPassword(KnowledgeDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
