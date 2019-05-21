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
    public class EducationService : IService<EducationDTO>
    {
        IUnitOfWork Database { get; set; }

        public EducationService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<EducationDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Education, EducationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(Database.Educations.GetAll());
        }

        public void Create(EducationDTO model)
        {
            Education education = new Education
            {
                Name = model.Name,
                GPA = model.GPA,
                DiplomaPhoto = model.DiplomaPhoto,
                CityId = model.CityId,
                UserId = model.UserId
            };

            Database.Educations.Create(education);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Educations.Delete(id);
            Database.Save();
        }

        public void Update(EducationDTO model)
        {
            Education education = new Education
            {
                Id = model.Id,
                Name = model.Name,
                GPA = model.GPA,
                DiplomaPhoto = model.DiplomaPhoto,
                CityId = model.CityId,
                UserId = model.UserId
            };

            Database.Educations.Update(education);
            Database.Save();
        }
        
        public IEnumerable<EducationDTO> Find(Func<EducationDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(EducationDTO select)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EducationDTO> IService<EducationDTO>.GetByUserId(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Education, EducationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(Database.Educations.GetByUserId(userId));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public EducationDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public EducationDTO CheckToExistUserEmail(EducationDTO model)
        {
            throw new NotImplementedException();
        }

        public EducationDTO CheckToExistUserEmailAndPassword(EducationDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
