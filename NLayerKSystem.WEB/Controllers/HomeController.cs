using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Models.pagingHelpers;
using NLayerKSystem.WEB.Models.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NLayerKSystem.WEB.Controllers
{
    [Authorize(Roles = "Manager")]
    public class HomeController : Controller
    {
        IService<UserDTO> userService;
        IService<RoleDTO> roleService;
        IService<CityDTO> cityService;
        IService<EducationDTO> educationService;
        IService<ExperienceDTO> experienceService;
        IService<TrainingDTO> trainingService;
        IService<CertificationTestDTO> cerTestService;
        IService<SportProgrammingDTO> sportProgrammingService;
        IService<SelectionDTO> selectionService;
        IService<ReviewDTO> reviewService;


        public HomeController(IService<UserDTO> userService,
                              IService<RoleDTO> roleService,
                              IService<CityDTO> cityService,
                              IService<EducationDTO> educationService,
                              IService<ExperienceDTO> experienceService,
                              IService<TrainingDTO> trainingService,
                              IService<CertificationTestDTO> cerTestService,
                              IService<SportProgrammingDTO> sportProgrammingService,
                              IService<SelectionDTO> selectionService,
                              IService<ReviewDTO> reviewService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.cityService = cityService;
            this.educationService = educationService;
            this.experienceService = experienceService;
            this.trainingService = trainingService;
            this.cerTestService = cerTestService;
            this.sportProgrammingService = sportProgrammingService;
            this.selectionService = selectionService;
            this.reviewService = reviewService;
        }

        public ActionResult Index(int? page, IndexViewModel indexViewModelParams)
        {
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var mapperExperience = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();
            var mapperCertificationTest = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTestDTO, CertificationViewModel>()).CreateMapper();
            var mapperSportProgramming = new MapperConfiguration(cfg => cfg.CreateMap<SportProgrammingDTO, SportProgrammingViewModel>()).CreateMapper();
            var mapperSelection = new MapperConfiguration(cfg => cfg.CreateMap<IndexViewModel, SelectionDTO>()).CreateMapper();

            IEnumerable<SelectionJoinQueryResultDTO> response = (IEnumerable<SelectionJoinQueryResultDTO>)selectionService.FindJoin(mapperSelection.Map<IndexViewModel, SelectionDTO>(indexViewModelParams));

            IEnumerable<SelectionJoinQueryResultViewModel> selectionJoinQueryResultViewModels = response.Select(m => new SelectionJoinQueryResultViewModel()
            {
                User = mapperUser.Map<UserDTO, UserViewModel>(m.User),
                Educations = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(m.Educations),
                Experiences = mapperExperience.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(m.Experiences),
                Trainings = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(m.Trainings),
                CertificationTests = mapperCertificationTest.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationViewModel>>(m.CertificationTests),
                SportProgrammings = mapperSportProgramming.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(m.SportProgrammings)
            });

            var pager = new Pager(selectionJoinQueryResultViewModels.Count(), page);

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                EducationViewModels = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationService.GetTable()),
                ExperienceViewModels = mapperExperience.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(experienceService.GetTable()),
                TrainingViewModels = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(trainingService.GetTable()),
                CertificationViewModels = mapperCertificationTest.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationViewModel>>(cerTestService.GetTable()),
                SportProgrammingViewModels = mapperSportProgramming.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(sportProgrammingService.GetTable()),
                SelectionJoinQueryResultViewModels = selectionJoinQueryResultViewModels.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(indexViewModel);
        }

        public ActionResult DetailCandidate(int userId)
        {
            var userDTO = userService.GetByUserId(userId);
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            var educationDTO = educationService.GetByUserId(userId);
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var education = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationDTO);

            IEnumerable<ExperienceDTO> experienceDTO = experienceService.GetByUserId(userId);
            var mapperExperience = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var experience = mapperExperience.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(experienceDTO);

            IEnumerable<TrainingDTO> trainingDTO = trainingService.GetByUserId(userId);
            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();
            var training = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(trainingDTO);

            IEnumerable<CertificationTestDTO> cerTestDTO = cerTestService.GetByUserId(userId);
            var mapperCertificationTest = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTestDTO, CertificationViewModel>()).CreateMapper();
            var cerTest = mapperCertificationTest.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationViewModel>>(cerTestDTO);

            IEnumerable<SportProgrammingDTO> sportProgDTO = sportProgrammingService.GetByUserId(userId);
            var mapperSportProgramming = new MapperConfiguration(cfg => cfg.CreateMap<SportProgrammingDTO, SportProgrammingViewModel>()).CreateMapper();
            var sportProg = mapperSportProgramming.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(sportProgDTO);

            IEnumerable<ReviewDTO> reviewDTO = reviewService.GetByUserId(userId);
            var mapperReview = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>()).CreateMapper();
            var review = mapperReview.Map<IEnumerable<ReviewDTO>, IEnumerable<ReviewViewModel>>(reviewDTO);

            IndexViewModelDetailCandidate ivm = new IndexViewModelDetailCandidate
            {
                ListOfViewModelUser = user,
                listOfViewModelEducation = education,
                listOfViewModelExperience = experience,
                listOfViewModelTraining = training,
                listOfViewModelCertificationTest = cerTest,
                listOfViewModelSportProgramming = sportProg,
                listofViewModelReview = review
            };

            return View(ivm);
        }
    }
}