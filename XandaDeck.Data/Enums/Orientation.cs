using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Enums
{
    public enum Orientation
    {
        Normal = 1,
        [Display(Name = "Rotate Clock Wise")]
        RotateClockWise = 2,
        [Display(Name = "Rotate Anti Clock Wise")]
        RotateAntiClockWise = 3,
        [Display(Name = "Upside Down")]
        UpsideDown = 4
    }
}
