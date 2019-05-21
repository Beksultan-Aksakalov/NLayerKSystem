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
    public class ExperienceController : Controller
    {
        IService<ExperienceDTO> experienceService;
        IService<CityDTO> cityService;
        IService<UserDTO> userService;
        IService<KnowledgeDTO> knowledgeService;

        public ExperienceController(IService<ExperienceDTO> experienceService, IService<CityDTO> cityService, IService<UserDTO> userService, IService<KnowledgeDTO> knowledgeService)
        {
            this.experienceService = experienceService;
            this.cityService = cityService;
            this.userService = userService;
            this.knowledgeService = knowledgeService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<ExperienceDTO> experienceDTO = experienceService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = experienceService.GetTable().Count() };

            var mapperExperince = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDTO, ExperienceViewModel>()).CreateMapper();
            var experience = mapperExperince.Map<IEnumerable<ExperienceDTO>, IEnumerable<ExperienceViewModel>>(experienceDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IndexViewModel<ExperienceViewModel, CityViewModel, UserViewModel, KnowledgeViewModel> ivm = new IndexViewModel<ExperienceViewModel, CityViewModel, UserViewModel, KnowledgeViewModel>
            { ListOfViewModel = experience, ListOfViewModel2 = city, ListOfViewModel3 = user, ListOfViewModel4 = knowledge, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExperienceViewModel model)
        {
            if (model != null)
            {
                var experienceDTO = new ExperienceDTO
                {
                    CompanyName = model.CompanyName,
                    CountExperience = model.CountExperience,
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            experienceService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ExperienceViewModel model)
        {
            var experienceDTO = new ExperienceDTO
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                CountExperience = model.CountExperience,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            experienceService.Update(experienceDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            experienceService.Dispose();
            cityService.Dispose();
            userService.Dispose();
            knowledgeService.Dispose();
            base.Dispose(disposing);
        }
    }
}