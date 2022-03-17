using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XandaDeck.Data.Models;

namespace XandaDeck.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleItem> ScheduleItems { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
        public DbSet<SmtpSetting> SmtpSettings { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
    }
}
