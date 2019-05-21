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
    public class CityService : IService<CityDTO>
    {
        IUnitOfWork Database { get; set; }

        public CityService(IUnitOfWork database)
        {
            Database = database;
        }

        public CityService()
        {
        }

        public IEnumerable<CityDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(Database.Cities.GetAll());
        }

        public void Create(CityDTO model)
        {
            City city = new City
            {
                Name = model.Name,
                CountryId = model.CountryId,
            };

            Database.Cities.Create(city);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Cities.Delete(id);
            Database.Save();
        }

        public void Update(CityDTO model)
        {
            City city = new City
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId
            };

            Database.Cities.Update(city);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<CityDTO> Find(Func<CityDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(CityDTO select)
        {
            throw new NotImplementedException();
        }

        public CityDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public CityDTO CheckToExistUserEmail(CityDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public CityDTO CheckToExistUserEmailAndPassword(CityDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
