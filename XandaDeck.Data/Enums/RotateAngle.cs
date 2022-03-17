using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Enums
{
    public enum RotateAngle
    {
        [Display(Name = "😊 0°")]
        Zero = 1,
        [Display(Name = "😊 90°")]
        Ninety = 2,
        [Display(Name = "😊 180°")]
        OneEighty = 3,
        [Display(Name = "😊 270°")]
        TwoSeventy = 4
    }
}
