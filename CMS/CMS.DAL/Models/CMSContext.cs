using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
namespace CMS.DAL.Models
{
    public partial class CMSContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employments> Employments { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public IConfiguration Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=tcp:vh.database.windows.net;Integrated Security=false;Initial Catalog=CMS;User id=vanhakobyan1996;Password=VAN606580$$;Encrypt=True;persist security info=True;");
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
                    .HasName("IX_FK_CustomerEmploymnets");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.MakingTime).HasColumnType("datetime");

                entity.Property(e => e.Price).IsRequired();

                entity.Property(e => e.ProductName).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerEmploymnets");
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.HasIndex(e => e.EmploymentEmploymentId)
                    .HasName("IX_FK_EmploymnetsSchedules");

                entity.Property(e => e.AllWorkTime).HasColumnType("datetime");

                entity.Property(e => e.EmploymentEmploymentId).HasColumnName("Employment_EmploymentId");

                entity.Property(e => e.EndWorkTime).HasColumnType("datetime");

                entity.Property(e => e.StartWorkTime).HasColumnType("datetime");

                entity.HasOne(d => d.EmploymentEmployment)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.EmploymentEmploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmploymnetsSchedules");
            });
        }
    }
}
