﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
