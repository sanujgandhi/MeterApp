using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class FileUpload:BaseModel
    {
        [Key]
        public int FileUploadId { get; set; }
        public string ClientId { get; set; }
        public string DeveloperId { get; set; }
        public int ModuleId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }

    }
}
