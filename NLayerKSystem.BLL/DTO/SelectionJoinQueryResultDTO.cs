using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.BLL.DTO
{
    public class SelectionJoinQueryResultDTO
    {
        public UserDTO User { get; set; }

        public IEnumerable<EducationDTO> Educations { get; set; }
        public IEnumerable<ExperienceDTO> Experiences { get; set; }
        public IEnumerable<TrainingDTO> Trainings { get; set; }
        public IEnumerable<CertificationTestDTO> CertificationTests { get; set; }
        public IEnumerable<SportProgrammingDTO> SportProgrammings { get; set; }
    }
}
