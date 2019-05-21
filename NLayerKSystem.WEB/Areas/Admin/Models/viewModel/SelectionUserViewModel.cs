using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class SelectionUserViewModel
    {
        public int Id { get; set; }
        public int? SelectionId { get; set; }
        public virtual Selection Selection { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsSelected { get; set; }

        public IEnumerable<SelectionViewModel> SelectionViewModels { get; set; }
        public IEnumerable<EducationViewModel> EducationViewModels { get; set; }
        public IEnumerable<ExperienceViewModel> ExperienceViewModels { get; set; }
        public IEnumerable<TrainingViewModel> TrainingViewModels { get; set; }
        public IEnumerable<CertificationTestViewModel> CertificationTestViewModels { get; set; }
        public IEnumerable<SportProgrammingViewModel> SportProgrammingViewModels { get; set; }

        public string SelectionName
        {
            get
            {
                return Selection?.Name ?? "";
            }
        }

        public string SelectionEducationName
        {
            get
            {
                return Selection?.Education.Name ?? "";
            }
        }

        public string SelectionExpCompanyName
        {
            get
            {
                return Selection?.Experience.CompanyName ?? "";
            }
        }

        public string SelectionExpCountExp
        {
            get
            {
                return Selection?.Experience.CountExperience ?? "";
            }
        }

        public string SelectionTrainingResource
        {
            get
            {
                return Selection?.Training.Resource ?? "";
            }
        }

        public string SelectionCerTResource
        {
            get
            {
                return Selection?.CertificationTest.Resource ?? "";
            }
        }

        public string SelectionSportPResource
        {
            get
            {
                return Selection?.SportProgramming.Resourse ?? "";
            }
        }

        public string UserName
        {
            get
            {
                return User?.Name ?? "";
            }
        }

        public string UserRoleName
        {
            get
            {
                return User?.Role.Name ?? "";
            }
        }
    }
}