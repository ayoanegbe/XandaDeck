using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
