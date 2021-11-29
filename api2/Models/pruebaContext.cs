using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace api2.Models
{
    public partial class pruebaContext : IdentityDbContext<ApplicationUser>
    {
        public pruebaContext(DbContextOptions<pruebaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=db_empresa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.user_id).HasName("pk_userid_23");
                entity.ToTable("Customer", "Accounts");
                entity.Property(e => e.rol_id).HasColumnName("rol_id");
                entity.Property(e => e.user_name).HasColumnName("user_name");
                entity.Property(e => e.user_lastname).HasColumnName("user_lastname");
                entity.Property(e => e.user_age).HasColumnName("user_age");
                entity.Property(e => e.user_phone).HasColumnName("user_phone");
                entity.Property(e => e.user_email).HasColumnName("user_email");
                entity.Property(e => e.user_password).HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<api2.Models.Customer> Customer { get; set; }
    }
}
