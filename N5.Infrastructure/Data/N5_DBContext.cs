using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using N5.Core.Entities;
using N5.Infrastructure.Data.Configuration;

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
        public virtual DbSet<PermissionEntity> Permissions { get; set; }
        public virtual DbSet<TypePermissionEntity> TypePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new TypePermissionConfiguration());
        }
    }
}
