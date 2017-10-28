using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CMS.DAL.Models
{
    public partial class CMSContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Products> Products { get; set; }

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

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_FK_CustomerProduct");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerProduct");
            });
        }
    }
}
