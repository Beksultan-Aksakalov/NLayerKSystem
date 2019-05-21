using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerKSystem.WEB.Controllers
{
    [Authorize(Roles = "Programmer")]
    public class ProgrammerController : Controller
    {
        // GET: Programmer
        public ActionResult Index()
        {
            
            return View();
        }
    }
}