using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class ExperienceDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CountExperience { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
