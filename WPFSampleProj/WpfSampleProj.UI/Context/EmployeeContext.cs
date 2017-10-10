using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using WPFSampleProj.UI.Model;

namespace WPFSampleProj.UI.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("EmployeeData")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHours> EmployeeHoursList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);


            // Configure the primary key for Employee
            modelBuilder.Entity<Employee>().HasKey(t => t.EmployeeNumber);
            //specify no autogenerate the EmployeeNumber Column
            modelBuilder.Entity<Employee>().Property(b => b.EmployeeNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //one-to-many relationship 
            modelBuilder.Entity<EmployeeHours>().HasRequired(c => c.Employee)
                    .WithMany(s => s.EmployeeHours)
                    .HasForeignKey(c => c.EmployeeRefId);
        }
    }
}
