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
    public class CityController : Controller
    {
        IService<CityDTO> cityService;
        IService<CountryDTO> countryService;

        public CityController(IService<CityDTO> cityService, IService<CountryDTO> countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<CityDTO> cityDTO = cityService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = cityService.GetTable().Count() };

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, CityViewModel>()).CreateMapper();
            var city = mapper.Map<IEnumerable<CityDTO>, IEnumerable<CityViewModel>>(cityDTO);

            IEnumerable<CountryDTO> countryDTO = countryService.GetTable();
            var mapperCountry = new MapperConfiguration(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>()).CreateMapper();
            var country = mapperCountry.Map<IEnumerable<CountryDTO>, IEnumerable<CountryViewModel>>(countryDTO);

            IndexViewModel<CityViewModel, CountryViewModel> ivm = new IndexViewModel<CityViewModel, CountryViewModel> { ListOfViewModel = city, PageInfo = pageInfo, ListOfViewModel2 = country };
                        
            return View(ivm);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CityViewModel model)
        {
            if (model != null)
            {
                var cityDTO = new CityDTO
                {
                    Name = model.Name.Trim(),
                    CountryId = model.CountryId
                };

                cityService.Create(cityDTO);

                return RedirectToAction("Index");
            }

            return View();
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            cityService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CityViewModel model)
        {
            CityDTO city = new CityDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                CountryId = model.CountryId
            };

            cityService.Update(city);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            cityService.Dispose();
            countryService.Dispose();
            base.Dispose(disposing);
        }
    }
}