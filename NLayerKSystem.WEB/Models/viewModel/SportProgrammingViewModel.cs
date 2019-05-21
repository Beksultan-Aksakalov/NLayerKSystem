using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class SportProgrammingViewModel
    {
        public int Id { get; set; }
        public string Resourse { get; set; }
        public string Level { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? KnowledgeId { get; set; }
        public virtual Knowledge Knowledge1 { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        
        public string KnowLedgeName
        {
            get { return Knowledge1?.Name ?? ""; }
        }

        public IEnumerable<KnowledgeViewModel> KnowledegeViewModels { get; set; }
    }
}