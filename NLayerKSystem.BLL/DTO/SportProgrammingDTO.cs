using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class SportProgrammingDTO
    {
        public int Id { get; set; }
        public string Resourse { get; set; }
        public string Level { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public int? KnowledgeId { get; set; }
        public virtual Knowledge Knowledge { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
