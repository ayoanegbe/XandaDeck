using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Enums;

namespace XandaDeck.Data.Models
{
    public class Layout
    {
        [Key]
        public int LayoutId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public LayoutStyle LayoutStyle { get; set; }
    }
}
