using NLayerKSystem.BLL.DTO;
using NLayerKSystem.WEB.Areas.Admin.Models.pagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public class IndexViewModel<T, T2>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public PageInfo PageInfo { get; set; }

    }

    public class IndexViewModel<T, T2, T3>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public IEnumerable<T3> ListOfViewModel3 { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public class IndexViewModel<T, T2, T3, T4>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public IEnumerable<T3> ListOfViewModel3 { get; set; }

        public IEnumerable<T4> ListOfViewModel4 { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public class IndexViewModel<T, T2, T3, T4, T5, T6>
    {
        public IEnumerable<T> ListOfViewModel { get; set; }

        public IEnumerable<T2> ListOfViewModel2 { get; set; }

        public IEnumerable<T3> ListOfViewModel3 { get; set; }

        public IEnumerable<T4> ListOfViewModel4 { get; set; }

        public IEnumerable<T5> ListOfViewModel5 { get; set; }

        public IEnumerable<T6> ListOfViewModel6 { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public class IndexViewModelSelection
    {
        public IEnumerable<SelectionViewModel> listOfViewModelSelection { get; set; }

        public IEnumerable<EducationViewModel> listOfViewModelEducation { get; set; }

        public IEnumerable<ExperienceViewModel> listOfViewModelExperience { get; set; }

        public IEnumerable<TrainingViewModel> listOfViewModelTraining { get; set; }

        public IEnumerable<CertificationTestViewModel> listOfViewModelCertificationTest { get; set; }

        public IEnumerable<SportProgrammingViewModel> listOfViewModelSportProgramming { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}