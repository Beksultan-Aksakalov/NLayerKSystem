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
    public class SubjectController : Controller
    {
        IService<SubjectDTO> subjectService;
        IService<EducationDTO> educationService;
        IService<NominationDTO> nominationService;
        IService<KnowledgeDTO> knowledgeService;

        public SubjectController(IService<SubjectDTO> subjectService, IService<EducationDTO> educationService, IService<NominationDTO> nominationService, IService<KnowledgeDTO> knowledgeService)
        {
            this.subjectService = subjectService;
            this.educationService = educationService;
            this.nominationService = nominationService;
            this.knowledgeService = knowledgeService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<SubjectDTO> subjectDTO = subjectService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = subjectService.GetTable().Count() };

            var mapperSubject = new MapperConfiguration(cfg => cfg.CreateMap<SubjectDTO, SubjectViewModel>()).CreateMapper();
            var subject = mapperSubject.Map<IEnumerable<SubjectDTO>, IEnumerable<SubjectViewModel>>(subjectDTO);

            IEnumerable<EducationDTO> educationDTO = educationService.GetTable();
            var mapperEducation = new MapperConfiguration(cfg => cfg.CreateMap<EducationDTO, EducationViewModel>()).CreateMapper();
            var education = mapperEducation.Map<IEnumerable<EducationDTO>, IEnumerable<EducationViewModel>>(educationDTO);

            IEnumerable<NominationDTO> nominationDTO = nominationService.GetTable();
            var mapperNomination = new MapperConfiguration(cfg => cfg.CreateMap<NominationDTO, NominationViewModel>()).CreateMapper();
            var nomination = mapperNomination.Map<IEnumerable<NominationDTO>, IEnumerable<NominationViewModel>>(nominationDTO);

            IEnumerable<KnowledgeDTO> knowledgeDTO = knowledgeService.GetTable();
            var mapperKnowledge = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, KnowledgeViewModel>()).CreateMapper();
            var knowledge = mapperKnowledge.Map<IEnumerable<KnowledgeDTO>, IEnumerable<KnowledgeViewModel>>(knowledgeDTO);

            IndexViewModel<SubjectViewModel, EducationViewModel, NominationViewModel, KnowledgeViewModel> ivm = new IndexViewModel<SubjectViewModel, EducationViewModel, NominationViewModel, KnowledgeViewModel> { ListOfViewModel = subject, ListOfViewModel2 = education, ListOfViewModel3 = nomination, ListOfViewModel4 = knowledge, PageInfo = pageInfo };

            return View(ivm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectViewModel model)
        {
            if (model != null)
            {
                var subjectDTO = new SubjectDTO
                {
                    Name = model.Name.Trim(),
                    Description = model.Description.Trim(),
                    CountCredit = model.CountCredit,
                    Evaluation = model.Evaluation,
                    NominationId = model.NominationId,
                    EducationId = model.EducationId,
                    KnowledgeId = model.KnowledgeId
                };

                subjectService.Create(subjectDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            subjectService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SubjectViewModel model)
        {
            var subjectDTO = new SubjectDTO
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                Description = model.Description.Trim(),
                CountCredit = model.CountCredit,
                Evaluation = model.Evaluation,
                NominationId = model.NominationId,
                EducationId = model.EducationId,
                KnowledgeId = model.KnowledgeId
            };

            subjectService.Update(subjectDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            subjectService.Dispose();
            educationService.Dispose();
            nominationService.Dispose();
            knowledgeService.Dispose();
            base.Dispose(disposing);
        }
    }
}