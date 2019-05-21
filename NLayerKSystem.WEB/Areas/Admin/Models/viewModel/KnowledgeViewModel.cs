using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class KnowledgeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public Knowledge Knowledge2 { get; set; }

        public string KnowledgeName
        {
            get
            {
                return Knowledge2?.Name ?? "";
            }
        }

        public IEnumerable<KnowledgeViewModel> KnowledgeViewModels { get; set; }
    }
}