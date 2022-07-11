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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly N5_DBContext _n5_DBContext;
        private readonly IPermissionRepository _permissionRepository;
        public UnitOfWork(N5_DBContext n5_DBContext)
        {
            _n5_DBContext = n5_DBContext;
        }
        public IPermissionRepository PermissionRepository => _permissionRepository ?? new PermissionRepository(_n5_DBContext);
        public void Dispose()
        {
            if (_n5_DBContext != null)
            {
                _n5_DBContext.Dispose();
            }
        }
        public void SaveChanges()
        {
            _n5_DBContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _n5_DBContext.SaveChangesAsync();
        }
    }
}
