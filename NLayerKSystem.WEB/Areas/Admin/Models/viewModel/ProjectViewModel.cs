using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string UseTechnology { get; set; }
        public int CountProgrammers { get; set; }

        public int? NominationId { get; set; }
        public Nomination Nomination { get; set; }
        public int? ExperienceId { get; set; }
        public Experience Experience { get; set; }

        public string NominationName
        {
            get
            {
                return Nomination?.Name ?? "";
            }
        }

        public IEnumerable<NominationViewModel> NominationViewModels { get; set; }

        public string ExperienceCompanyName
        {
            get
            {
                return Experience?.CompanyName ?? "";
            }
        }

        public IEnumerable<ExperienceViewModel> ExperienceViewModels { get; set; }

    }
}
