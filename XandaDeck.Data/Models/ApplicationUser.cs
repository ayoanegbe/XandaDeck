using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XandaDeck.Data.Entities;

namespace XandaDeck.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        : base()
        {
        }

        public ApplicationUser(string userName, string firstName, string lastName)
        : base(userName)
        {
            base.Email = userName;
            base.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool ChangePassword { get; set; } = false;

        public bool IsStaff { get; set; } = false;

        public bool IsAdmin { get; set; } = false;

        public bool Online { get; set; } = false;

        [StringLength(30)]
        public string Site { get; set; }

        public int? AccounId { get; set; }
        public bool DeviceLogin { get; set; } = false;

        public DateTimeOffset? LastLogin { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public string FullName => $"{this.FirstName} {this.LastName}";
        public string UserAlias => $"{this.FirstName}.{this.LastName}";

    }
}
