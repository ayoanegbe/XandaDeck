﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XandaDeck.Data.Models
{
    public class EmailSettings
    {
        public string UserName { get; set; }
        public string Host { get; set; }
        public string HostIP { get; set; }
        public string PortNumber { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string CcEmail { get; set; }        
    }
}
