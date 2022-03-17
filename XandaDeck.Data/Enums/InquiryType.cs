using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Enums
{
    public enum InquiryType
    {
        [Display(Name = "Sales Inquiry")]
        SalesInquiry = 1,
        [Display(Name = "Enterprise Plan Inquiry")]
        EnterprisePlanInquiry = 2,
        [Display(Name = "Support Request")]
        SupportRequest = 3,
        Consultation = 4,
        Others
    }
}
