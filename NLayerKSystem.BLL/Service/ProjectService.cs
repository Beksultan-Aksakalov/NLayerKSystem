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
    public class ProjectService: IService<ProjectDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProjectService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<ProjectDTO> GetTable()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(Database.Projects.GetAll());
        }

        public void Create(ProjectDTO model)
        {
            Project project = new Project
            {
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                UseTechnology = model.UseTechnology,
                CountProgrammers = model.CountProgrammers,
                NominationId = model.NominationId,
                ExperienceId = model.ExperienceId
            };

            Database.Projects.Create(project);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Projects.Delete(id);
            Database.Save();
        }

        public void Update(ProjectDTO model)
        {
            Project project = new Project
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                UseTechnology = model.UseTechnology,
                CountProgrammers = model.CountProgrammers,
                NominationId = model.NominationId,
                ExperienceId = model.ExperienceId
            };

            Database.Projects.Update(project);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ProjectDTO> Find(Func<ProjectDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<object> FindJoin(ProjectDTO select)
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetUserByRoleId(int? roleId)
        {
            throw new NotImplementedException();
        }

        public ProjectDTO CheckToExistUserEmail(ProjectDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDTO> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public ProjectDTO CheckToExistUserEmailAndPassword(ProjectDTO model)
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
