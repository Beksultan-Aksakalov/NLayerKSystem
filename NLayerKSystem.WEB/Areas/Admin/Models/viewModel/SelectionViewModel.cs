using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class SelectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? EducationId { get; set; }
        public Education Education { get; set; }

        public int? ExperienceId { get; set; }
        public Experience Experience { get; set; }

        public int? TrainingId { get; set; }
        public Training Training { get; set; }

        public int? CertificationTestId { get; set; }
        public CertificationTest CertificationTest { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public int? SportProgrammingId { get; set; }
        public SportProgramming SportProgramming { get; set; }

        //public IEnumerable<SelectionViewModel> SelectionViewModels { get; set; }

        public string EducationName
        {
            get
            {
                return Education?.Name ?? "";
            }
        }

        public IEnumerable<EducationViewModel> EducationViewModels { get; set; }

        public string ExperienceCompanyName
        {
            get
            {
                return Experience?.CompanyName ?? "";
            }
        }

        public IEnumerable<ExperienceViewModel> ExperienceViewModels { get; set; }

        public string TrainingResource
        {
            get
            {
                return Training?.Resource ?? "";
            }
        }

        public IEnumerable<TrainingViewModel> TrainingViewModels { get; set; }

        public string CertificationResource
        {
            get
            {
                return CertificationTest?.Resource ?? "";
            }
        }

        public string CertificationPhoto
        {
            get
            {
                return CertificationTest?.CertificationPhoto ?? "";
            }
        }

        public IEnumerable<CertificationTestViewModel> CertificationTestViewModels { get; set; }

        public string SportProgrammingResource
        {
            get
            {
                return SportProgramming?.Resourse ?? "";
            }
        }

        public IEnumerable<SportProgrammingViewModel> SportProgrammingViewModels { get; set; }

    }
}