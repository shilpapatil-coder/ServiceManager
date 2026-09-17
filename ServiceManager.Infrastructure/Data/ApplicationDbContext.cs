using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceManager.Core.Entities;
using System;

namespace ServiceManager.Infrastructure.Data
{
    // We inherit from IdentityDbContext to get all the built-in ASP.NET Core Identity tables (Users, Roles, etc.)
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // These DbSets represent our tables in the SQL Database
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceAddress> ServiceAddresses { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Here we can configure specific database rules using the Fluent API if needed.
            // For example, ensuring that a Service Request has a default status:
            builder.Entity<ServiceRequest>()
                .Property(s => s.Status)
                .HasDefaultValue(ServiceRequestStatus.Raised);

            builder.Entity<ServiceRequest>()
                 .HasOne(s => s.ServiceAddress)
                 .WithMany()
                 .HasForeignKey(s => s.ServiceAddressId)
                 .OnDelete(DeleteBehavior.Restrict); // This prevents the multiple cascade path error
                                                     // FIX: Stop the cascade delete on the Customer -> ServiceRequest relationship just to be safe
            builder.Entity<ServiceRequest>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
