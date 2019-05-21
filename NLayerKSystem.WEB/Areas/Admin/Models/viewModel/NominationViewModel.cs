using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class NominationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}