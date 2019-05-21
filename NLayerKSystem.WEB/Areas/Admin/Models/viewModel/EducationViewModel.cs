using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public string DiplomaPhoto { get; set; }
      
        public int? CityId { get; set; }
        public City City { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        
        public HttpPostedFileBase ImageFile { get; set; }

        public string CityName
        {
            get
            {
                return City?.Name ?? "";
            }
        }

        public IEnumerable<CityViewModel> CityViewModels { get; set; }

        public string UserName
        {
            get
            {
                return User?.Name ?? "";
            }
        }

        public IEnumerable<UserViewModel> UserViewModels { get; set; }
    }
}
