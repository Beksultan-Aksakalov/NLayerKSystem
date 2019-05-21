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
    
    public class IndexViewModelDetailCandidate
    {
        public IEnumerable<UserViewModel> ListOfViewModelUser { get; set; }

        public IEnumerable<EducationViewModel> listOfViewModelEducation { get; set; }

        public IEnumerable<ExperienceViewModel> listOfViewModelExperience { get; set; }

        public IEnumerable<TrainingViewModel> listOfViewModelTraining { get; set; }

        public IEnumerable<CertificationViewModel> listOfViewModelCertificationTest { get; set; }

        public IEnumerable<SportProgrammingViewModel> listOfViewModelSportProgramming { get; set; }

        public IEnumerable<ReviewViewModel> listofViewModelReview { get; set; }
    }

    public class IndexViewModel<T, T2, T3>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public IEnumerable<T3> ListOfViewModel3 { get; set; }
    }
}