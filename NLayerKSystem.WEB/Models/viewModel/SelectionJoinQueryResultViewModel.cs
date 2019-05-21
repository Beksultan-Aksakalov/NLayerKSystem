using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class SelectionJoinQueryResultViewModel
    {
        public UserViewModel User { get; set; }

        public IEnumerable<EducationViewModel> Educations { get; set; }
        public string EducationsNameGpa => string.Join("/ ", Educations.Where(m => m != null).Select(n => $"{n.Name.Trim()} - {n.GPA.ToString()} "));
        
        public IEnumerable<ExperienceViewModel> Experiences { get; set; }
        public string ExperiencesName => string.Join("/ ", Experiences.Where(m => m != null).Select(m => m.CompanyName));
        
        public IEnumerable<TrainingViewModel> Trainings { get; set; }
        public string TrainingsResource => string.Join("/ ", Trainings.Where(m => m != null).Select(m => m.Resource));
        
        public IEnumerable<CertificationViewModel> CertificationTests { get; set; }
        public string CertificatioinTestsResource => string.Join("/ ", CertificationTests.Where(m => m != null).Select(m => m.Resource));
        
        public IEnumerable<SportProgrammingViewModel> SportProgrammings { get; set; }
        public string SportProgrammingsResource => string.Join("/ ", SportProgrammings.Where(m => m != null).Select(m => m.Resourse));
        
    }
}