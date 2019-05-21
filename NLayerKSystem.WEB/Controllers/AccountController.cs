using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Models.pagingHelpers;
using NLayerKSystem.WEB.Models.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NLayerKSystem.WEB.Controllers
{
    public class AccountController : Controller
    {
        IService<UserDTO> userService;
        IService<RoleDTO> roleService;
        IService<CityDTO> cityService;

        public AccountController(IService<UserDTO> userService, IService<RoleDTO> roleService, IService<CityDTO> cityService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.cityService = cityService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            var userDTOs = new UserDTO
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Photo = model.Photo,
                CityId = model.CityId,
                RoleId = model.RoleId
            };

            var userDTO = userService.CheckToExistUserEmailAndPassword(userDTOs);
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<UserDTO, UserViewModel>(userDTO);

            if (user != null)
            {
                if (user.Role.Id == 3)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (user.Role.Id == 2)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");

                } else if (user.Role.Id == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Programmer");
                }
                else
                {
                    TempData["error"] = "Пользователь с таким логином и паролем нет";
                }
            }

            return View(model);
        }

        public ActionResult Registration()
        {
            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IEnumerable<RoleDTO> roleDTO = roleService.GetTable();
            var mapperRole = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>()).CreateMapper();
            var role = mapperRole.Map<IEnumerable<RoleDTO>, IEnumerable<RoleViewModel>>(roleDTO);

            IEnumerable<CityDTO> cityDTO = cityService.GetTable();
            var mapperCity = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapperCity.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IndexViewModel<UserViewModel, RoleViewModel, CityViewModel> ivm = new IndexViewModel<UserViewModel, RoleViewModel, CityViewModel>
            {
                ListOfViewModel = user,
                ListOfViewModel2 = role,
                ListOfViewModel3 = city
            };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            var userDTOs = new UserDTO
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Photo = model.Photo,
                CityId = model.CityId,
                RoleId = model.RoleId
            };

            var userDTO = userService.CheckToExistUserEmail(userDTOs);
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<UserDTO, UserViewModel>(userDTO);

            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    model.Photo = "~/Areas/production/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                    model.ImageFile.SaveAs(fileName);

                    var u = new UserDTO
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Photo = model.Photo,
                        CityId = model.CityId,
                        RoleId = model.RoleId
                    };

                    userService.Create(u);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    if (user.Email.Trim() != model.Email.Trim())
                    {

                        var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        var extension = Path.GetExtension(model.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.Photo = "~/Areas/production/images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                        model.ImageFile.SaveAs(fileName);

                        var u = new UserDTO
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Password = model.Password,
                            Photo = model.Photo,
                            CityId = model.CityId,
                            RoleId = model.RoleId
                        };

                        userService.Create(u);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["data"] = "Пользователь с таким логином уже существует";
                        RedirectToAction("Registration");
                    }
                }
            }

            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}