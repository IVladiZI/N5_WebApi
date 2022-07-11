using N5.Core.Entities;
using System;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository PermissionRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
