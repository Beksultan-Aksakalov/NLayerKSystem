using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public string CountryName
        {
            get
            {
                return Country?.Name ?? "";
            }
        }

        public IEnumerable<CountryViewModel> CountryViewModels { get; set; }
    }
}