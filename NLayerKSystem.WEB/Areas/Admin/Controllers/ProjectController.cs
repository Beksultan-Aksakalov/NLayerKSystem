using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Areas.Admin.Models.pagingHelpers;
using NLayerKSystem.WEB.Areas.Admin.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerKSystem.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        IService<ProjectDTO> projectService;
        IService<NominationDTO> nominationService;
        IService<ExperienceDTO> experienceService;

        public ProjectController(IService<ProjectDTO> projectService, IService<NominationDTO> nominationService, IService<ExperienceDTO> experienceService)
        {
            this.projectService = projectService;
            this.nominationService = nominationService;
            this.experienceService = experienceService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<ProjectDTO> projectDTO = projectService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = projectService.GetTable().Count() };

            var mapperProject = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, ProjectViewModel>()).CreateMapper();
            var project = mapperProject.Map<IEnumerable<ProjectDTO>, IEnumerable<ProjectViewModel>>(projectDTO);

            IEnumerable<NominationDTO> nominationDTO = nominationService.GetTable();
            var mapperNomination = new MapperConfiguration(cfg => cfg.CreateMap<NominationDTO, NominationViewModel>()).CreateMapper();
            var nomination = mapperNomination.Map<IEnumerable<NominationDTO>, IEnumerable<NominationViewModel>>(nominationDTO);

            IEnumerable<ExperienceDTO> experienceDTO = experienceService.GetTable();
            var mapperExperience = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var experience = mapperExperience.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(experienceDTO);

            IndexViewModel<ProjectViewModel, NominationViewModel, ExperienceViewModel> ivm = new IndexViewModel<ProjectViewModel, NominationViewModel, ExperienceViewModel>
            { ListOfViewModel = project, ListOfViewModel2 = nomination, ListOfViewModel3 = experience, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel model)
        {
            if (model != null)
            {
                var projectDTO = new ProjectDTO
                {
                    Name = model.Name,
                    Description = model.Description,
                    Duration = model.Duration,
                    UseTechnology = model.UseTechnology,
                    CountProgrammers = model.CountProgrammers,
                    NominationId = model.NominationId,
                    ExperienceId = model.ExperienceId
                };

                projectService.Create(projectDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            projectService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProjectViewModel model)
        {
            var projectDTO = new ProjectDTO
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
            
            projectService.Update(projectDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            projectService.Dispose();
            nominationService.Dispose();
            experienceService.Dispose();
            base.Dispose(disposing);
        }
    }
}