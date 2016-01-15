using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class GlobalCode:BaseModel
    {
        [Key]
        public int GlobalCodeId { get; set; }
        public int GlobalCodeCategoryId { get; set; }
        public string GlobalCodeName { get; set; }
        public string Description { get; set; }//nullble
    }
}
