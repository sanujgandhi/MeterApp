using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
  public  class Developer_Skill:BaseModel
    {
      [Key]
      [Column(Order = 0)]
      public string DeveloperId { get; set; }
      [Key]
      [Column(Order = 1)]
      public int SkillId { get; set; }
            
  }
}
