using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class Screenshots : BaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int DeveloperId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ModuleId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenPath { get; set; }
        public string Comments { get; set; }

    }
}
