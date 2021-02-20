using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class WorkContext : DbContext
    {
        public WorkContext() : base("WorkContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Step> Steps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       //     modelBuilder.Entity<Project>()
       //.HasMany<Employee>(c => c.Employees).WithMany(i => i.Projects)
       //.Map(t => t.MapLeftKey("ProjectID")
       //    .MapRightKey("EmployeeID")
       //    .ToTable("Assignment"));
           

        }
    }
}