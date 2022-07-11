using N5.Core.DTOs;
using N5.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface IPermissionService
    {
        IEnumerable<PermissionEntity> Get();
        Task<PermissionEntity> Get(long Id);
        Task<IEnumerable<PermissionEntity>> Find(PermissionFindDto Name);
        Task InsertPermissions(PermissionEntity Permission);
        Task<bool> UpdatePermissions(PermissionEntity Permission);
        Task<bool> DeletePermissions(long Id);
    }
}