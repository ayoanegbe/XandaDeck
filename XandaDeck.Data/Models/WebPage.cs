using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class WebPage
    {
        [Key]
        public int WebPageId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Default Duration")]
        public int Duration { get; set; } = 20;
        public DateTimeOffset CreatedAt { get; set; }
        public string Address { get; set; }
        public string Preview { get; set; }
        public DateTimeOffset? PlayFrom { get; set; }
        public bool Always { get; set; } = true;
        public DateTimeOffset? PlayUntil { get; set; }
        public bool Forever { get; set; } = true;
        [Range(0, 100)]
        [Display(Name = "Zoom Factor (%)")]
        public double ZoomFactor { get; set; }
        [Display(Name = "Auto Adjust Zoom")]
        public bool AutoZoom { get; set; }
    }
}
