using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CountExperience { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge1 { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public string KnowledgeName
        {
            get
            {
                return Knowledge1?.Name ?? "";
            }
        }

        public IEnumerable<KnowledgeViewModel> KnowledgeViewModels { get; set; }

    }
}