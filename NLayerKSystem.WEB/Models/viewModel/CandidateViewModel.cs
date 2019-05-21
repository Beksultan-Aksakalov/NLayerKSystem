using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class CandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public string CityName
        {
            get { return City?.Name ?? ""; }
        }

        public string CountryName
        {
            get { return City?.Country.Name ?? ""; }
        }
    }
}