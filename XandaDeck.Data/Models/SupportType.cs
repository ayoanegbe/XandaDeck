using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public enum SupportType
    {
        [Display(Name = "Password Reset")]
        PasswordReset = 1,
        [Display(Name = "Faulty XandaBox")]
        FaultyXandaBox = 2,
        [Display(Name = "Inability To Login")]
        InabilityToLogin = 3,
        Others = 4
    }
}
