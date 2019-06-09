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
    public class SportProgrammingController : Controller
    {
        IService<SportProgrammingDTO> spService;
        IService<CityDTO> cityService;
        IService<KnowledgeDTO> knowledgeService;
        IService<UserDTO> userService;

        public SportProgrammingController(IService<SportProgrammingDTO> spService, IService<CityDTO> cityService, IService<KnowledgeDTO> knowledgeService, IService<UserDTO> userService)
        {
            this.spService = spService;
            this.cityService = cityService;
            this.knowledgeService = knowledgeService;
            this.userService = userService;
        }
        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<SportProgrammingDTO> ctDTO = spService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = spService.GetTable().Count() };

            var mapperSp = new MapperConfiguration(cfg => cfg.CreateMap<SportProgrammingDTO, SportProgrammingViewModel>()).CreateMapper();
            var sp = mapperSp.Map<IEnumerable<SportProgrammingDTO>, IEnumerable<SportProgrammingViewModel>>(ctDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IndexViewModel<SportProgrammingViewModel, CityViewModel, KnowledgeViewModel, UserViewModel> ivm = new IndexViewModel<SportProgrammingViewModel, CityViewModel, KnowledgeViewModel, UserViewModel>
            { ListOfViewModel = sp, ListOfViewModel2 = city, ListOfViewModel3 = knowledge, ListOfViewModel4 = user, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SportProgrammingViewModel model)
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

                spService.Create(ct);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            spService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SportProgrammingViewModel model)
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

            spService.Update(ct);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            spService.Dispose();
            cityService.Dispose();
            knowledgeService.Dispose();
            userService.Dispose();
            base.Dispose(disposing);
        }
    }
}