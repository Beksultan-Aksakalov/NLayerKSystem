using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Недопустимая длина email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Недопустимая длина password")]
        public string Password { get; set; }

        public string Photo { get; set; }
        
        public bool isConfirmedEmail { get; set; }

        [Required(ErrorMessage = "Photo is required")]
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