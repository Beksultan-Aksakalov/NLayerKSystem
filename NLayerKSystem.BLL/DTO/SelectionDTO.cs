using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class SelectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? EducationId { get; set; }
        public Education Education { get; set; }
        public int? ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public int? TrainingId { get; set; }
        public Training Training { get; set; }
        public int? CertificationTestId { get; set; }
        public CertificationTest CertificationTest { get; set; }
        public int? SportProgrammingId { get; set; }
        public SportProgramming SportProgramming { get; set; }
    }
}
