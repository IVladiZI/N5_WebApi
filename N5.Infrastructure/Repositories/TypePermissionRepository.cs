using Microsoft.EntityFrameworkCore;
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
    public class TypePermissionRepository : ITypePermissionRepository
    {
        private readonly N5_DBContext _n5_DBContext;
        public TypePermissionRepository(N5_DBContext n5_DBContext)
        {
            _n5_DBContext = n5_DBContext;
        }

        public async Task<IEnumerable<TypePermission>> Get()
        {
            var typePermissionGet = await _n5_DBContext.TypePermissions.ToListAsync();
            return typePermissionGet;
        }
    }
}
