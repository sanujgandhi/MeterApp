using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class Module : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int ModuleId { get; set; }
        public int ProjectId { get; set; }
        public int TechnologyId { get; set; }
        public string DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
