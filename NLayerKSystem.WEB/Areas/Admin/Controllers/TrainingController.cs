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
    public class TrainingController : Controller
    {
        IService<TrainingDTO> trainingService;
        IService<CityDTO> cityService;
        IService<KnowledgeDTO> knowledgeService;
        IService<UserDTO> userService;

        public TrainingController(IService<TrainingDTO> trainingService, IService<CityDTO> cityService, IService<KnowledgeDTO> knowledgeService, IService<UserDTO> userService)
        {
            this.trainingService = trainingService;
            this.cityService = cityService;
            this.knowledgeService = knowledgeService;
            this.userService = userService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<TrainingDTO> trainingDTO = trainingService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = trainingService.GetTable().Count() };

            var mapperTraining = new MapperConfiguration(cfg => cfg.CreateMap<TrainingDTO, TrainingViewModel>()).CreateMapper();
            var training = mapperTraining.Map<IEnumerable<TrainingDTO>, IEnumerable<TrainingViewModel>>(trainingDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IndexViewModel<TrainingViewModel, CityViewModel, KnowledgeViewModel, UserViewModel> ivm = new IndexViewModel<TrainingViewModel, CityViewModel, KnowledgeViewModel, UserViewModel>
            { ListOfViewModel = training, ListOfViewModel2 = city, ListOfViewModel3 = knowledge, ListOfViewModel4 = user, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TrainingViewModel model)
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
                    Resource = model.Resource,
                    Course = model.Course,
                    Duration = model.Duration,
                    FinalEvaluation = model.FinalEvaluation,
                    ProjectPhoto = model.ProjectPhoto,
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            trainingService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(TrainingViewModel model)
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
                Resource = model.Resource,
                Course = model.Course,
                Duration = model.Duration,
                FinalEvaluation = model.FinalEvaluation,
                ProjectPhoto = model.ProjectPhoto,
                CityId = model.CityId,
                KnowledgeId = model.KnowledgeId,
                UserId = model.UserId
            };

            trainingService.Update(trainingDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            trainingService.Dispose();
            cityService.Dispose();
            knowledgeService.Dispose();
            userService.Dispose();
            base.Dispose(disposing);
        }
    }
}