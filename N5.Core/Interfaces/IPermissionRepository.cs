using N5.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> Get();
        Task<Permission> Get(long Id);
        Task InsertPermissions(Permission Permission);
        Task<bool> UpdatePermissions(Permission Permission);
        Task<bool> DeletePermissions(long Id);
    }
}
