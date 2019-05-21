using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class CertificationTestDTO
    {
        public int Id { get; set; }
        public string Resource { get; set; }
        public string Evaluation { get; set; }
        public string CertificationPhoto { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
