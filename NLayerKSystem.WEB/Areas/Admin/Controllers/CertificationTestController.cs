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
    public class CertificationTestController : Controller
    {
        IService<CertificationTestDTO> ctService;
        IService<CityDTO> cityService;
        IService<KnowledgeDTO> knowledgeService;
        IService<UserDTO> userService;

        public CertificationTestController(IService<CertificationTestDTO> ctService, IService<CityDTO> cityService, IService<KnowledgeDTO> knowledgeService, IService<UserDTO> userService)
        {
            this.ctService = ctService;
            this.cityService = cityService;
            this.knowledgeService = knowledgeService;
            this.userService = userService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<CertificationTestDTO> ctDTO = ctService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = ctService.GetTable().Count() };

            var mapperCT = new MapperConfiguration(cfg => cfg.CreateMap<CertificationTestDTO, CertificationTestViewModel>()).CreateMapper();
            var ct = mapperCT.Map<IEnumerable<CertificationTestDTO>, IEnumerable<CertificationTestViewModel>>(ctDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IndexViewModel<CertificationTestViewModel, CityViewModel, KnowledgeViewModel, UserViewModel> ivm = new IndexViewModel<CertificationTestViewModel, CityViewModel, KnowledgeViewModel, UserViewModel>
            { ListOfViewModel = ct, ListOfViewModel2 = city, ListOfViewModel3 = knowledge, ListOfViewModel4 = user, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CertificationTestViewModel model)
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
                    Resource = model.Resource,
                    Evaluation = model.Evaluation,
                    CertificationPhoto = model.CertificationPhoto,
                    CityId = model.CityId,
                    KnowledgeId = model.KnowledgeId,
                    UserId = model.UserId
                };

                ctService.Create(ct);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ctService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CertificationTestViewModel model)
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
                Resource = model.Resource,
                Evaluation = model.Evaluation,
                CertificationPhoto = model.CertificationPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            }; ;

            ctService.Update(ct);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ctService.Dispose();
            cityService.Dispose();
            knowledgeService.Dispose();
            userService.Dispose();
            base.Dispose(disposing);
        }
    }
}