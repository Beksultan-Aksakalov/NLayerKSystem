using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountCredit { get; set; }
        public double Evaluation { get; set; }

        public int? EducationId { get; set; }
        public Education Education { get; set; }

        public int? NominationId { get; set; }
        public Nomination Nomination { get; set; }

        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }

        public string EducationName
        {
            get
            {
                return Education?.Name ?? "";
            }
        }

        public IEnumerable<EducationViewModel> EducationViewModels { get; set; }

        public string NominationName
        {
            get
            {
                return Nomination?.Name ?? "";
            }
        }

        public IEnumerable<NominationViewModel> NominationViewModels { get; set; }

        public string KnowledgeName
        {
            get
            {
                return Knowledge?.Name ?? "";
            }
        }

        public IEnumerable<KnowledgeViewModel> KnowledgeViewModels { get; set; }
    }
}