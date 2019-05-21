using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.MyDbContext;

namespace NLayerKSystem.BLL.DTO
{
    public class EducationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public string DiplomaPhoto { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
