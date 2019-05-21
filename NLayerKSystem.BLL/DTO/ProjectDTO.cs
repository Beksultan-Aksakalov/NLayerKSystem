using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string UseTechnology { get; set; }
        public int CountProgrammers { get; set; }

        public int? NominationId { get; set; }
        public Nomination Nomination { get; set; }
        public int? ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
