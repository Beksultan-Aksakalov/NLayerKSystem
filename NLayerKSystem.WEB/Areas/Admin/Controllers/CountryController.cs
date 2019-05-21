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
    public class CountryController : Controller
    {
        IService<CountryDTO> countryService;

        public CountryController(IService<CountryDTO> countryService)
        {
            this.countryService = countryService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<CountryDTO> countryDTO = countryService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = countryService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>()).CreateMapper();
            var country = mapper.Map<IEnumerable<CountryDTO>, IEnumerable<CountryViewModel>>(countryDTO);

            IndexViewModel<CountryViewModel> ivm = new IndexViewModel<CountryViewModel> { ListOfViewModel = country, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryViewModel model)
        {
            if (model != null)
            {
                var countryDTO = new CountryDTO
                {
                    Name = model.Name.Trim()
                };

                countryService.Create(countryDTO);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            countryService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CountryViewModel model)
        {
            CountryDTO country = new CountryDTO
            {
                Id = model.Id,
                Name = model.Name.Trim()
            };

            countryService.Update(country);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            countryService.Dispose();
            base.Dispose(disposing);
        }
    }
}