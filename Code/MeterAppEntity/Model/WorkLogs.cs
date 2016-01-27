using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class WorkLogs : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public string DeveloperId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ModuleId { get; set; }
        public string TaskToDo { get; set; }
        public string TaskDone { get; set; }
        public string Reason { get; set; }
    }
}
