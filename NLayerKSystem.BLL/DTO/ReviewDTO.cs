using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
