using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().Property(c => c.ProjectID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Step>().Property(c => c.StepID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}