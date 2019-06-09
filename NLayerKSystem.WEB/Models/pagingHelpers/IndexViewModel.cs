using NLayerKSystem.WEB.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerKSystem.WEB.Models.pagingHelpers
{
    public class IndexViewModel
    {
        public int? EducationId { get; set; }

        public IEnumerable<EducationViewModel> EducationViewModels { get; set; }

        public int? ExperienceId { get; set; }

        public IEnumerable<ExperienceViewModel> ExperienceViewModels { get; set; }

        public int? TrainingId { get; set; }

        public IEnumerable<TrainingViewModel> TrainingViewModels { get; set; }

        public int? CertificationId { get; set; }

        public IEnumerable<CertificationViewModel> CertificationViewModels { get; set; }

        public int? SportProgrammingId { get; set; }

        public IEnumerable<SportProgrammingViewModel> SportProgrammingViewModels { get; set; }

        public int? KnowledgeId { get; set; }

        public IEnumerable<KnowledgeViewModel> KnowledgeViewModels { get; set; }

        public IEnumerable<SelectionJoinQueryResultViewModel> SelectionJoinQueryResultViewModels { get; set; }

        public Pager Pager { get; set; }
        
    }
    
    public class IndexViewModelCandidate
    {
        public UserViewModel UserViewModel { get; set; }

        public IEnumerable<UserViewModel> ListUserViewModel { get; set; }

        public IEnumerable<CityViewModel> ListOfViewModelCity { get; set; }

        public IEnumerable<EducationViewModel> ListOfViewModelEducation { get; set; }

        public IEnumerable<ExperienceViewModel> ListOfViewModelExperience { get; set; }

        public IEnumerable<TrainingViewModel> ListOfViewModelTraining { get; set; }

        public IEnumerable<CertificationViewModel> ListOfViewModelCertificationTest { get; set; }

        public IEnumerable<SportProgrammingViewModel> ListOfViewModelSportProgramming { get; set; }

        public IEnumerable<ReviewViewModel> ListofViewModelReview { get; set; }

        public IEnumerable<KnowledgeViewModel> ListofViewModelKnowledge { get; set; }
    }
    
    public class IndexViewModel<T, T2, T3>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public IEnumerable<T3> ListOfViewModel3 { get; set; }
    }

}