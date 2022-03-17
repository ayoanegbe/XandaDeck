using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Enums;

namespace XandaDeck.Data.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTimeOffset UploadedOn { get; set; }
        public DateTimeOffset? PlayFrom { get; set; }
        public bool Always { get; set; } = true;
        public DateTimeOffset? PlayUntil { get; set; }
        public bool Forever { get; set; } = true;
        [Display(Name = "Rotate Video")]
        public bool RotateVideo { get; set; }
        [Display(Name = "Rotate by")]
        public RotateAngle RotateBy { get; set; } = RotateAngle.Zero;
        [Display(Name = "Crop Video")]
        public bool CropVideo { get; set; }
        [Range(0, 99.99)]
        public double Top { get; set; }
        [Range(0, 99.99)]
        public double Bottom { get; set; }
        [Range(0, 99.99)]
        public double Left { get; set; }
        [Range(0, 99.99)]
        public double Right { get; set; }
        [Display(Name = "Enable Subtitles")]
        public bool EnableSubtitles { get; set; }
    }
}
