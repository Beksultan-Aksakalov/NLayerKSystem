using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Resource { get; set; }
        public string Course { get; set; }
        public string Duration { get; set; }
        public double FinalEvaluation { get; set; }
        public string ProjectPhoto { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge1 { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public string KnowLedgeName
        {
            get { return Knowledge1?.Name ?? "" ;  }
        }

        public IEnumerable<KnowledgeViewModel> KnowledegeViewModels { get; set; }
    }
}