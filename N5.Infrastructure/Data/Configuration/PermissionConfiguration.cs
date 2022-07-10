using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infrastructure.Data.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("PERMISSION", "N5");

            builder.Property(e => e.Id).HasColumnName("PERM_ID_BI");

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("PERM_DATE_DT");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERM_LASTNAME_VC");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERM_NAME_VC");

            builder.Property(e => e.IdTypePermission).HasColumnName("PERM_TP_ID_BI");

            builder.HasOne(d => d.TypePermission)
                .WithMany(p => p.Permissions)
                .HasForeignKey(d => d.IdTypePermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERMISSION");
        }
    }
}
