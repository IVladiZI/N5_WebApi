using N5.Core.DTOs;
using N5.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface IPermissionRepository : IBaseRepository<PermissionEntity>
    {
        Task<IEnumerable<PermissionEntity>> FindAsync();
    }
}
