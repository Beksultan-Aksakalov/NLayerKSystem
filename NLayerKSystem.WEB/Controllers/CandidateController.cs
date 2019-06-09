using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Models.pagingHelpers;
using NLayerKSystem.WEB.Models.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace NLayerKSystem.WEB.Controllers
{
    [Authorize(Roles = "Candidate")]
    public class CandidateController : Controller
    {
        IService<UserDTO> userService;
        IService<CityDTO> cityService;
        IService<EducationDTO> educationService;
        IService<ExperienceDTO> experienceService;
        IService<TrainingDTO> trainingService;
        IService<CertificationTestDTO> cerTestService;
        IService<SportProgrammingDTO> sportProgrammingService;
        IService<SelectionDTO> selectionService;
        IService<ReviewDTO> reviewService;
        IService<KnowledgeDTO> knowledgeService;

        public CandidateController(
            IService<UserDTO> userService,
            IService<CityDTO> cityService,
            IService<EducationDTO> educationService,
            IService<ExperienceDTO> experienceService,
            IService<TrainingDTO> trainingService,
            IService<CertificationTestDTO> cerTestService,
            IService<SportProgrammingDTO> sportProgrammingService,
            IService<SelectionDTO> selectionService,
            IService<ReviewDTO> reviewService,
            IService<KnowledgeDTO> knowledgeService)
        {
            this.userService = userService;
            this.cityService = cityService;
            this.educationService = educationService;
            this.experienceService = experienceService;
            this.trainingService = trainingService;
            this.cerTestService = cerTestService;
            this.sportProgrammingService = sportProgrammingService;
            this.selectionService = selectionService;
            this.reviewService = reviewService;
            this.knowledgeService = knowledgeService;
        }

        // GET: Programmer
        public ActionResult Index()
        {
            var userEmail = HttpContext.User.Identity.Name;

            UserDTO userDTO = new UserDTO
            {
                Email = userEmail
            };

            var userD = userService.CheckToExistUserEmail(userDTO);
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<UserDTO, UserViewModel>(userD);

            IEnumerable<UserDTO> userDTOList = userService.GetTable();
            var mapperUserList = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var userList = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTOList);

            var cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            var educationDTO = educationService.GetByUserId(user.Id);
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var education = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationDTO);

            var experienceDTO = experienceService.GetByUserId(user.Id);
            var mapperExperience = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var experience = mapperExperience.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(experienceDTO);

            var trainingDTO = trainingService.GetByUserId(user.Id);
            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();
            var training = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(trainingDTO);

            var cerTestDTO = cerTestService.GetByUserId(user.Id);
            var mapperCertificationTest = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTestDTO, CertificationViewModel>()).CreateMapper();
            var cerTest = mapperCertificationTest.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationViewModel>>(cerTestDTO);

            var sportProgDTO = sportProgrammingService.GetByUserId(user.Id);
            var mapperSportProgramming = new MapperConfiguration(cfg => cfg.CreateMap<SportProgrammingDTO, SportProgrammingViewModel>()).CreateMapper();
            var sportProg = mapperSportProgramming.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(sportProgDTO);

            var reviewDTO = reviewService.GetByUserId(user.Id);
            var mapperReview = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>()).CreateMapper();
            var review = mapperReview.Map<IEnumerable<ReviewDTO>, IEnumerable<ReviewViewModel>>(reviewDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IndexViewModelCandidate ivm = new IndexViewModelCandidate
            {
                UserViewModel = user,
                ListUserViewModel = userList,
                ListOfViewModelCity = city,
                ListOfViewModelEducation = education,
                ListOfViewModelExperience = experience,
                ListOfViewModelTraining = training,
                ListOfViewModelCertificationTest = cerTest,
                ListOfViewModelSportProgramming = sportProg,
                ListofViewModelReview = review,
                ListofViewModelKnowledge = knowledge
            };

            return View(ivm);
        }

        public ActionResult UserEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserEdit(UserViewModel model)
        {
            var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            var extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.Photo = "~/Areas/production/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
            model.ImageFile.SaveAs(fileName);

            var userDTO = new UserDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                Email = model.Email.Trim(),
                Password = model.Password.Trim(),
                Photo = model.Photo.Trim(),
                CityId = model.CityId,
                RoleId = model.RoleId
            };

            userService.Update(userDTO);

            return RedirectToAction("Index");
        }

        public ActionResult EducationCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationCreate(EducationViewModel model)
        {
            if (model != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.DiplomaPhoto = "~/Areas/production/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                var educationDTO = new EducationDTO
                {
                    Name = model.Name.Trim(),
                    GPA = model.GPA,
                    DiplomaPhoto = model.DiplomaPhoto.Trim(),
                    CityId = model.CityId,
                    UserId = model.UserId
                };

                educationService.Create(educationDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult EducationEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationEdit(EducationViewModel model)
        {
            var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            var extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.DiplomaPhoto = "~/Areas/production/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
            model.ImageFile.SaveAs(fileName);

            var educationDTO = new EducationDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                GPA = model.GPA,
                DiplomaPhoto = model.DiplomaPhoto.Trim(),
                CityId = model.CityId,
                UserId = model.UserId
            };

            educationService.Update(educationDTO);

            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EducationDelete(int id)
        {
            educationService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExpCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpCreate(ExperienceViewModel model)
        {
            if (model != null)
            {
                var experienceDTO = new ExperienceDTO
                {
                    CompanyName = model.CompanyName.Trim(),
                    CountExperience = model.CountExperience.Trim(),
                    CityId = model.CityId,
                    KnowledgeId = model.KnowledgeId,
                    UserId = model.UserId
                };

                experienceService.Create(experienceDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult ExpEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpEdit(ExperienceViewModel model)
        {
            var experienceDTO = new ExperienceDTO
            {
                Id = model.Id,
                CompanyName = model.CompanyName.Trim(),
                CountExperience = model.CountExperience.Trim(),
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            experienceService.Update(experienceDTO);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ExpDelete(int id)
        {
            experienceService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrCreate(TrainingViewModel model)
        {
            if (model != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.ProjectPhoto = "~/Areas/production/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                TrainingDTO training = new TrainingDTO
                {
                    Resource = model.Resource.Trim(),
                    Course = model.Course.Trim(),
                    Duration = model.Duration.Trim(),
                    FinalEvaluation = model.FinalEvaluation,
                    ProjectPhoto = model.ProjectPhoto.Trim(),
                    CityId = model.CityId,
                    KnowledgeId = model.KnowledgeId,
                    UserId = model.UserId
                };

                trainingService.Create(training);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        public ActionResult TrEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrEdit(TrainingViewModel model)
        {
            var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            var extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.ProjectPhoto = "~/Areas/production/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
            model.ImageFile.SaveAs(fileName);

            TrainingDTO trainingDTO = new TrainingDTO
            {
                Id = model.Id,
                Resource = model.Resource.Trim(),
                Course = model.Course.Trim(),
                Duration = model.Duration.Trim(),
                FinalEvaluation = model.FinalEvaluation,
                ProjectPhoto = model.ProjectPhoto.Trim(),
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            trainingService.Update(trainingDTO);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult TrDelete(int id)
        {
            trainingService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CrCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrCreate(CertificationViewModel model)
        {
            if (model != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CertificationPhoto = "~/Areas/production/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                CertificationTestDTO ct = new CertificationTestDTO
                {
                    Resource = model.Resource.Trim(),
                    Evaluation = model.Evaluation.Trim(),
                    CertificationPhoto = model.CertificationPhoto.Trim(),
                    CityId = model.CityId,
                    KnowledgeId = model.KnowledgeId,
                    UserId = model.UserId
                };

                cerTestService.Create(ct);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult CrEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrEdit(CertificationViewModel model)
        {
            var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            var extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.CertificationPhoto = "~/Areas/production/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
            model.ImageFile.SaveAs(fileName);

            CertificationTestDTO ct = new CertificationTestDTO
            {
                Id = model.Id,
                Resource = model.Resource.Trim(),
                Evaluation = model.Evaluation.Trim(),
                CertificationPhoto = model.CertificationPhoto.Trim(),
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            }; ;

            cerTestService.Update(ct);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult CrDelete(int id)
        {
            cerTestService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SpCreate(SportProgrammingViewModel model)
        {
            if (model != null)
            {
                SportProgrammingDTO ct = new SportProgrammingDTO
                {
                    Resourse = model.Resourse.Trim(),
                    Level = model.Level.Trim(),
                    CityId = model.CityId,
                    KnowledgeId = model.KnowledgeId,
                    UserId = model.UserId
                };

                sportProgrammingService.Create(ct);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult SpEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SpEdit(SportProgrammingViewModel model)
        {
            SportProgrammingDTO ct = new SportProgrammingDTO
            {
                Id = model.Id,
                Resourse = model.Resourse.Trim(),
                Level = model.Level.Trim(),
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            sportProgrammingService.Update(ct);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SpDelete(int id)
        {
            sportProgrammingService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }
    }
}