using N5.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface ITypePermissionRepository
    {
        Task<IEnumerable<TypePermission>> Get();
    }
}
