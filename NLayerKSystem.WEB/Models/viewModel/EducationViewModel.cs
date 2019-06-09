using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Models.viewModel
{
    public class EducationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }
        
        [Range(1, 4, ErrorMessage = "Please enter a value bigger than 0")]
        public double GPA { get; set; }

        public string DiplomaPhoto { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Photo is required")]
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