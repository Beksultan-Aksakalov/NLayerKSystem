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
    public class EducationController : Controller
    {
        IService<EducationDTO> educationService;
        IService<UserDTO> userService;
        IService<CityDTO> cityService;

        public EducationController(IService<EducationDTO> educationService, IService<UserDTO> userService, IService<CityDTO> cityService)
        {
            this.educationService = educationService;
            this.userService = userService;
            this.cityService = cityService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<EducationDTO> educationDTO = educationService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = educationService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var education = mapper.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IndexViewModel<EducationViewModel, UserViewModel, CityViewModel> ivm = new IndexViewModel<EducationViewModel, UserViewModel, CityViewModel> { ListOfViewModel = education, ListOfViewModel2 = user, ListOfViewModel3 = city, PageInfo = pageInfo, };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EducationViewModel model)
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
                    Name = model.Name,
                    GPA = model.GPA,
                    DiplomaPhoto = model.DiplomaPhoto,
                    CityId = model.CityId,
                    UserId = model.UserId
                };

                educationService.Create(educationDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            educationService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EducationViewModel model)
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
                Name = model.Name,
                GPA = model.GPA,
                DiplomaPhoto = model.DiplomaPhoto,
                CityId = model.CityId,
                UserId = model.UserId
            };

            educationService.Update(educationDTO);

            ModelState.Clear();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            educationService.Dispose();
            cityService.Dispose();
            base.Dispose(disposing);
        }
    }
}