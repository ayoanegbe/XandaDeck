using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class SupportTicket
    {
        [Key]
        public int SupportId { get; set; }
        public string TicketId { get; set; }
        public DateTimeOffset DateAdded { get; set; } = DateTimeOffset.Now;
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Support Type")]
        public SupportType SupportType { get; set; } = SupportType.PasswordReset;
        [Required]
        public string Message { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
