using Microsoft.EntityFrameworkCore;
using N5.Core.DTOs;
using N5.Core.Entities;
using N5.Core.Interfaces;
using N5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infrastructure.Repositories
{
    public class PermissionRepository : BaseRepository<PermissionEntity>, IPermissionRepository
    {
        public PermissionRepository(N5_DBContext n5_DBContext) : base(n5_DBContext){}
        public async Task<IEnumerable<PermissionEntity>> FindAsync()
        {
            var permissionGet = await _entities.ToListAsync<PermissionEntity>();
            return permissionGet;
        }

    }
}
