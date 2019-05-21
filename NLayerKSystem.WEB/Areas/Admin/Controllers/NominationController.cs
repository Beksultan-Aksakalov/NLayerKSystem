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
    public class NominationController : Controller
    {
        IService<NominationDTO> nominationService;

        public NominationController(IService<NominationDTO> nominationService)
        {
            this.nominationService = nominationService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<NominationDTO> nominationDTO = nominationService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = nominationService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NominationDTO, NominationViewModel>()).CreateMapper();
            var nomination = mapper.Map<IEnumerable<NominationDTO>, IEnumerable<NominationViewModel>>(nominationDTO);

            IndexViewModel<NominationViewModel> ivm = new IndexViewModel<NominationViewModel> { ListOfViewModel = nomination, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NominationViewModel model)
        {
            if (model != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.Photo = "~/Areas/production/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                var nominationDTO = new NominationDTO
                {
                    Name = model.Name.Trim(),
                    Description = model.Description.Trim(),
                    Photo = model.Photo.Trim()
                };

                nominationService.Create(nominationDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            nominationService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(NominationViewModel model)
        {
            var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            var extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.Photo = "~/Areas/production/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/production/images/"), fileName);
            model.ImageFile.SaveAs(fileName);

            NominationDTO nominationDTO = new NominationDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                Description = model.Description.Trim(),
                Photo = model.Photo.Trim()
            };

            nominationService.Update(nominationDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            nominationService.Dispose();
            base.Dispose(disposing);
        }
    }
}