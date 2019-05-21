using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using TestEF.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerKSystem.DAL.Interfaces;

namespace NLayerKSystem.BLL.Service
{
    public class CountryService : IService<CountryDTO>
    {
        IUnitOfWork Database { get; set; }

        public CountryService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<CountryDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(Database.Countries.GetAll());
        }

        public void Create(CountryDTO model)
        {
            Country country = new Country
            {
                Name = model.Name
            };

            Database.Countries.Create(country);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Countries.Delete(id);
            Database.Save();
        }
        
        public void Update(CountryDTO model)
        {
            Country country = new Country
            {
                Id = model.Id,
                Name = model.Name
            };

            Database.Countries.Update(country);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<CountryDTO> Find(Func<CountryDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> FindJoin(CountryDTO select)
        {
            throw new NotImplementedException();
        }

        public CountryDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public CountryDTO CheckToExistUserEmail(CountryDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public CountryDTO CheckToExistUserEmailAndPassword(CountryDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
