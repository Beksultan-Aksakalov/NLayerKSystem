using AutoMapper;
using NLayerKSystem.BLL.DTO;
using NLayerKSystem.BLL.Interface;
using NLayerKSystem.WEB.Areas.Admin.Models.pagingHelpers;
using NLayerKSystem.WEB.Areas.Admin.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace NLayerKSystem.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        IService<RoleDTO> roleService;

        public RoleController(IService<RoleDTO> roleService)
        {
            this.roleService = roleService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<RoleDTO> roleDTO = roleService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = roleService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>()).CreateMapper();
            var role = mapper.Map<IEnumerable<RoleDTO>, IEnumerable<RoleViewModel>>(roleDTO);
            
            IndexViewModel<RoleViewModel> ivm = new IndexViewModel<RoleViewModel> { ListOfViewModel = role, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            if (model != null)
            {
                var roleDTO = new RoleDTO
                {
                    Name = model.Name
                };

                roleService.Create(roleDTO);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            roleService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel model)
        {
            RoleDTO role = new RoleDTO
            {
                Id = model.Id,
                Name = model.Name
            };

            roleService.Update(role);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            roleService.Dispose();
            base.Dispose(disposing);
        }
    }
}