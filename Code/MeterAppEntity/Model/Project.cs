using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class Project : BaseModel
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Target Date")]
        public DateTime? TargetDate { get; set; }
        [DisplayName("Closed Date")]
        public DateTime? ClosureDate { get; set; }
        [DisplayName("Project Url")]
        public string ProjectLink { get; set; }
        public bool Status { get; set; }
    }
}
