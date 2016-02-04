using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class ProjectAssignments : BaseModel
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int TechnologyId { get; set; }

        public int ModuleId { get; set; }

        public int DeveloperId { get; set; }
    }
}
