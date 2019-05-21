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
    public class ReviewController : Controller
    {
        IService<ReviewDTO> reviewService;
        IService<UserDTO> userService;

        public ReviewController(IService<ReviewDTO> reviewService, IService<UserDTO> userService)
        {
            this.reviewService = reviewService;
            this.userService = userService;
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;

            IEnumerable<ReviewDTO> reviewDTO = reviewService.GetTable().OrderByDescending(m => m.Id).Skip((page - 1) * pageSize).Take(pageSize);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = reviewService.GetTable().Count() };

            var mapperReview = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>()).CreateMapper();
            var review = mapperReview.Map<IEnumerable<ReviewDTO>, IEnumerable<ReviewViewModel>>(reviewDTO);

            IEnumerable<UserDTO> userDTO = userService.GetTable();
            var mapperUser = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var user = mapperUser.Map<IEnumerable<UserDTO>, IEnumerable<UserViewModel>>(userDTO);

            IndexViewModel<ReviewViewModel, UserViewModel> ivm = new IndexViewModel<ReviewViewModel, UserViewModel> { ListOfViewModel = review, ListOfViewModel2 = user, PageInfo = pageInfo, };

            return View(ivm);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReviewViewModel model)
        {
            if (model != null)
            {
                var reviewDTO = new ReviewDTO
                {
                    Comment = model.Comment,
                    UserId = model.UserId
                };

                reviewService.Create(reviewDTO);

                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            reviewService.Delete(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index");

            return Json(new { Url = redirectUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ReviewViewModel model)
        {
            var reviewDTO = new ReviewDTO
            {
                Id = model.Id,
                Comment = model.Comment,
                UserId = model.UserId
            };

            reviewService.Update(reviewDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose();
            reviewService.Dispose();
            base.Dispose(disposing);
        }
    }
}