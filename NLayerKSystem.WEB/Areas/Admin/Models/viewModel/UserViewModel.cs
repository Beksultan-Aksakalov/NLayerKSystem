using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public bool isConfirmedEmail { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public string CityName
        {
            get
            {
                return City?.Name ?? "";
            }
        }

        public IEnumerable<CityViewModel> CityViewModels { get; set; }
        
        public string RoleName
        {
            get
            {
                return Role?.Name ?? "";
            }
        }

        public IEnumerable<RoleViewModel> RoleViewModels { get; set; }
    }
}