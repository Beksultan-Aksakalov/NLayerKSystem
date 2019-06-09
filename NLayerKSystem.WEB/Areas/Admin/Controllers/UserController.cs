using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.BLL.Service;
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
    public class UserController : Controller
    {
        IService<RoleDTO> roleService;
        IService<UserDTO> userService;
        IService<CityDTO> cityService;

        public UserController(IService<RoleDTO> roleService, IService<UserDTO> userService, IService<CityDTO> cityService)
        {
            this.roleService = roleService;
            this.userService = userService;
            this.cityService = cityService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<UserDTO> userDTO = userService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = userService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IEnumerable<RoleDTO> roleDTO = roleService.GetTable();
            var mapperRole = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>()).CreateMapper();
            var role = mapperRole.Map<IEnumerable<RoleDTO>, IEnumerable<RoleViewModel>>(roleDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IndexViewModel<UserViewModel, RoleViewModel, CityViewModel> ivm = new IndexViewModel<UserViewModel, RoleViewModel, CityViewModel> { ListOfViewModel = user, ListOfViewModel2 = role, ListOfViewModel3 = city, PageInfo = pageInfo, };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (model != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.Photo = "~/Areas/production/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                var userDTO = new UserDTO
                {
                    Name = model.Name.Trim(),
                    Email = model.Email.Trim(),
                    Password = model.Password.Trim(),
                    Photo = model.Photo.Trim(),
                    CityId = model.CityId,
                    RoleId = model.RoleId
                };

                userService.Create(userDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            userService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
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

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            roleService.Dispose();
            cityService.Dispose();
            base.Dispose(disposing);
        }
    }
}