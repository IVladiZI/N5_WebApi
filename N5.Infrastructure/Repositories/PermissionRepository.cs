﻿using Microsoft.EntityFrameworkCore;
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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly N5_DBContext _n5_DBContext;
        public PermissionRepository(N5_DBContext n5_DBContext)
        {
            _n5_DBContext = n5_DBContext;
        }
        public async Task<IEnumerable<Permission>> Get()
        {
            var permissionGet = await _n5_DBContext.Permissions.ToListAsync();
            return permissionGet;
;       }
        public async Task<Permission> Get(long id)
        {
            var permissionGet = await _n5_DBContext.Permissions.FindAsync(id);
            return permissionGet;
        }
        public async Task InsertPermissions(Permission permission)
        {
            _n5_DBContext.Permissions.Add(permission);
            await _n5_DBContext.SaveChangesAsync();
        }
        public async Task<bool> UpdatePermissions(Permission Permission)
        {
            var currentPermission = await Get(Permission.Id);
            currentPermission.LastName = Permission.LastName;
            currentPermission.Name = Permission.Name;
            currentPermission.IdTypePermission = Permission.IdTypePermission;
            currentPermission.Date = Permission.Date;
            int rows=await _n5_DBContext.SaveChangesAsync();
            return rows > 0; 
        }
        public async Task<bool> DeletePermissions(long id)
        {
            var currentPermission = await Get(id);
            _n5_DBContext.Remove(currentPermission);
            int rows = await _n5_DBContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
