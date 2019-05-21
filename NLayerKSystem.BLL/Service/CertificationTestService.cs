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
    public class CertificationTestService : IService<CertificationTestDTO>
    {
        IUnitOfWork Database { get; set; }

        public CertificationTestService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<CertificationTestDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTest, CertificationTestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CertificationTest>, IEnumerable<CertificationTestDTO>>(Database.CertificationTests.GetAll());
        }

        public void Create(CertificationTestDTO model)
        {
            CertificationTest ct = new CertificationTest
            {
                Resource = model.Resource,
                Evaluation = model.Evaluation,
                CertificationPhoto = model.CertificationPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.CertificationTests.Create(ct);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.CertificationTests.Delete(id);
            Database.Save();
        }

        public void Update(CertificationTestDTO model)
        {
            CertificationTest ct = new CertificationTest
            {
                Id = model.Id,
                Resource = model.Resource,
                Evaluation = model.Evaluation,
                CertificationPhoto = model.CertificationPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            Database.CertificationTests.Update(ct);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<CertificationTestDTO> Find(Func<CertificationTestDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(CertificationTestDTO select)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CertificationTestDTO> GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTest, CertificationTestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CertificationTest>, IEnumerable<CertificationTestDTO>>(Database.CertificationTests.GetByUserId(userId));
        }

        public CertificationTestDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public CertificationTestDTO CheckToExistUserEmail(CertificationTestDTO model)
        {
            throw new NotImplementedException();
        }

        public CertificationTestDTO CheckToExistUserEmailAndPassword(CertificationTestDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
