using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.MyDbContext;

namespace NLayerKSystem.WEB.Areas.Admin.Models.viewModel
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

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