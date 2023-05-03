using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration()); 
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration()); 
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }
    }
}
