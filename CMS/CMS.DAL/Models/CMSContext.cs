using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;

namespace CMS.DAL.Models
{
    public partial class CMSContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employments> Employments { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConString.GetValue());
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();
            });

            modelBuilder.Entity<Employments>(entity =>
            {
                entity.HasKey(e => e.EmploymentId);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_FK_CustomerEmployments");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.EmploymentName).IsRequired();

                entity.Property(e => e.MakingTime).HasColumnType("datetime");

                entity.Property(e => e.Price).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerEmployments");
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.Property(e => e.AllWorkTime).HasColumnType("datetime");

                entity.Property(e => e.EmploymentEmploymentId).HasColumnName("Employment_EmploymentId");

                entity.Property(e => e.EndWorkTime).HasColumnType("datetime");

                entity.Property(e => e.StartWorkTime).HasColumnType("datetime");

                entity.HasOne(d => d.EmploymentEmployment)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.EmploymentEmploymentId)
                    .HasConstraintName("FK_EmploymentsSchedules");
            });
        }
    }
}
