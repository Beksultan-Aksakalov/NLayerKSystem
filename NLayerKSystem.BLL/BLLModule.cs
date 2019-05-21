using Autofac;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.BLL
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryService>().As<IService<CountryDTO>>();
            builder.RegisterType<CityService>().As<IService<CityDTO>>();
            builder.RegisterType<NominationService>().As<IService<NominationDTO>>();
            builder.RegisterType<RoleService>().As<IService<RoleDTO>>();
            builder.RegisterType<UserService>().As<IService<UserDTO>>();
            builder.RegisterType<ReviewService>().As<IService<ReviewDTO>>();
            builder.RegisterType<EducationService>().As<IService<EducationDTO>>();
            builder.RegisterType<KnowledgeService>().As<IService<KnowledgeDTO>>();
            builder.RegisterType<SubjectService>().As<IService<SubjectDTO>>();
            builder.RegisterType<ExperienceService>().As<IService<ExperienceDTO>>();
            builder.RegisterType<ProjectService>().As<IService<ProjectDTO>>();
            builder.RegisterType<TrainingService>().As<IService<TrainingDTO>>();
            builder.RegisterType<CertificationTestService>().As<IService<CertificationTestDTO>>();
            builder.RegisterType<SportProgrammingService>().As<IService<SportProgrammingDTO>>();
            builder.RegisterType<SelectionService>().As<IService<SelectionDTO>>();
            builder.RegisterType<SelectionUserService>().As<IService<SelectionUserDTO>>();
        }
    }
}
