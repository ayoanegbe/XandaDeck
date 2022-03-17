using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tag Tags { get; set; }
        [Display(Name = "Default Duration")]
        public int Duration { get; set; } = 5;
        public DateTimeOffset UploadedOn { get; set; }
        public DateTimeOffset? PlayFrom { get; set; }
        public bool Always { get; set; } = true;
        public DateTimeOffset? PlayUntil { get; set; }
        public bool Forever { get; set; } = true;
        public string PreviewPath { get; set; }
        public string ImagePath { get; set; }
    }
}
