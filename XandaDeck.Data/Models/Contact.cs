using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Enums;

namespace XandaDeck.Data.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Full Names")]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Number Of Locations")]
        public int NumberOfLocations { get; set; }
        [Display(Name = "Inquiry Type")]
        public InquiryType InquiryType { get; set; } = InquiryType.SalesInquiry;
        [Required]
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
