using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Areas.Admin.Models.pagingHelpers;
using NLayerKSystem.WEB.Areas.Admin.Models.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerKSystem.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SelectionController : Controller
    {
        IService<SelectionDTO> selectionService;
        IService<EducationDTO> educationService;
        IService<ExperienceDTO> experienceService;
        IService<TrainingDTO> trainingService;
        IService<CertificationTestDTO> cerTestService;
        IService<SportProgrammingDTO> sportProgrammingService;

        public SelectionController(IService<SelectionDTO> selectionService, IService<EducationDTO> educationService, IService<ExperienceDTO> experienceService, IService<TrainingDTO> trainingService, IService<CertificationTestDTO> cerTestService, IService<SportProgrammingDTO> sportProgrammingService)
        {
            this.selectionService = selectionService;
            this.educationService = educationService;
            this.experienceService = experienceService;
            this.trainingService = trainingService;
            this.cerTestService = cerTestService;
            this.sportProgrammingService = sportProgrammingService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<SelectionDTO> selectionDTO = selectionService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = selectionService.GetTable().Count() };

            var mapperSelection = new MapperConfiguration(cfg => cfg.CreateMap<SelectionDTO, SelectionViewModel>()).CreateMapper();
            var selection = mapperSelection.Map<IEnumerable<SelectionDTO>, IEnumerable<SelectionViewModel>>(selectionDTO);

            IEnumerable<EducationDTO> educationDTO = educationService.GetTable();
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var education = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationDTO);

            IEnumerable<ExperienceDTO> expDTO = experienceService.GetTable();
            var mapperExp = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var experience = mapperExp.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(expDTO);

            IEnumerable<TrainingDTO> trainingDTO = trainingService.GetTable();
            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();
            var training = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(trainingDTO);

            IEnumerable<CertificationTestDTO> cerDTO = cerTestService.GetTable();
            var mapperCer = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTestDTO, CertificationTestViewModel>()).CreateMapper();
            var certificationTest = mapperCer.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationTestViewModel>>(cerDTO);

            IEnumerable<SportProgrammingDTO> spDTO = sportProgrammingService.GetTable();
            var mapperSp = new MapperConfiguration(cfg => cfg.CreateMap<SportProgrammingDTO, SportProgrammingViewModel>()).CreateMapper();
            var sportProg = mapperSp.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(spDTO);

            IndexViewModelSelection ivm = new IndexViewModelSelection()
            {
                listOfViewModelSelection = selection,
                listOfViewModelEducation = education,
                listOfViewModelExperience = experience,
                listOfViewModelTraining = training,
                listOfViewModelCertificationTest = certificationTest,
                listOfViewModelSportProgramming = sportProg,
                PageInfo = pageInfo
            };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SelectionViewModel model)
        {
            if (model != null)
            {
                SelectionDTO selectionDTO = new SelectionDTO
                {
                    Name = model.Name.Trim(),
                    EducationId = model.EducationId,
                    ExperienceId = model.ExperienceId,
                    TrainingId = model.TrainingId,
                    CertificationTestId = model.CertificationTestId,
                    SportProgrammingId = model.SportProgrammingId
                };

                selectionService.Create(selectionDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            selectionService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SelectionViewModel model)
        {
            SelectionDTO selectionDTO = new SelectionDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                EducationId = model.EducationId,
                ExperienceId = model.ExperienceId,
                TrainingId = model.TrainingId,
                CertificationTestId = model.CertificationTestId,
                SportProgrammingId = model.SportProgrammingId
            };

            selectionService.Update(selectionDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            selectionService.Dispose();
            educationService.Dispose();
            experienceService.Dispose();
            trainingService.Dispose();
            cerTestService.Dispose();
            sportProgrammingService.Dispose();
            base.Dispose(disposing);
        }
    }
}