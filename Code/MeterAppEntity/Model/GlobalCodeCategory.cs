using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class GlobalCodeCategory : BaseModel
    {
        [Key]
        public int GlobalCodeCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }//nullable
    }
}
