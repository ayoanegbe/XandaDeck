using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XandaDeck.Data.Models
{
    public class SmtpSetting
    {
        [Key]
        public int SmtpSettingId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Host { get; set; }
        [Display(Name = "Host IP")]
        public string HostIP { get; set; }
        [Display(Name = "Port Number")]
        public string PortNumber { get; set; }
        public string Password { get; set; }
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
    }
}
