using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public string Resource { get; set; }
        public string Course { get; set; }
        public string Duration { get; set; }
        public double FinalEvaluation { get; set; }
        public string ProjectPhoto { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int? KnowledgeId { get; set; }
        public Knowledge Knowledge { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
