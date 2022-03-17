using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(16)]
        public string IpAddress { get; set; }
        [StringLength(30)]
        public string Site { get; set; }
        [StringLength(30)]
        public string Action { get; set; }
    }
}
