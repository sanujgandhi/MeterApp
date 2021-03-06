﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppEntity.Model
{
    public class Messages : BaseModel
    {
        [Key]
        public int MessageId { get; set; }
        public int ProjectId { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public string MessageType { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
