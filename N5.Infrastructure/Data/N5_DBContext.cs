using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using N5.Core.Entities;

#nullable disable

namespace N5.Infrastructure.Data
{
    public partial class N5_DBContext : DbContext
    {
        public N5_DBContext()
        {
        }

        public N5_DBContext(DbContextOptions<N5_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<TypePermission> TypePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("PERMISSION", "N5");

                entity.Property(e => e.Id).HasColumnName("PERM_ID_BI");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("PERM_DATE_DT");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERM_LASTNAME_VC");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERM_NAME_VC");

                entity.Property(e => e.IdTypePermission).HasColumnName("PERM_TP_ID_BI");

                entity.HasOne(d => d.TypePermission)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdTypePermission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION");
            });

            modelBuilder.Entity<TypePermission>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TYPE_PERMISSION", "N5");

                entity.Property(e => e.Id).HasColumnName("TYPE_ID_BI");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_DESCRIPTION_VC");
            });
        }
    }
}
