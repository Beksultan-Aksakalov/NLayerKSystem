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
    public class KnowledgeController : Controller
    {
        IService<KnowledgeDTO> knowledgeService;

        public KnowledgeController(IService<KnowledgeDTO> knowledgeService)
        {
            this.knowledgeService = knowledgeService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = knowledgeService.GetTable().Count() };

            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO2 = knowledgeService.GetTable();
            var mapperKnowledge2 = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge2 = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO2);

            IndexViewModel<KnowledgeViewModel, KnowledgeViewModel> ivm = new IndexViewModel<KnowledgeViewModel, KnowledgeViewModel> { ListOfViewModel = knowledge, ListOfViewModel2 = knowledge2, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KnowledgeViewModel model)
        {
            if (model != null)
            {
                var knowledgeDTO = new KnowledgeDTO
                {
                    Name = model.Name,
                    Description = model.Description,
                    ParentId = model.ParentId                    
                };

                knowledgeService.Create(knowledgeDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            knowledgeService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(KnowledgeViewModel model)
        {
            var knowledgeDTO = new KnowledgeDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                Description = model.Description,
                ParentId = model.ParentId
            };

            knowledgeService.Update(knowledgeDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            knowledgeService.Dispose();
            base.Dispose(disposing);
        }
    }
}