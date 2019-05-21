using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class SelectionUserDTO
    {
        public int Id { get; set; }
        public int? SelectionId { get; set; }
        public virtual Selection Selection { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsSelected { get; set; }
    }
}
