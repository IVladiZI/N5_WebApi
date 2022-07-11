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
    public class TypePermissionConfiguration : IEntityTypeConfiguration<TypePermissionEntity>
    {
        public void Configure(EntityTypeBuilder<TypePermissionEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("TYPE_PERMISSION", "N5");

            builder.Property(e => e.Id).HasColumnName("TYPE_ID_BI");

            builder.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("TYPE_DESCRIPTION_VC");
        }
    }
}
