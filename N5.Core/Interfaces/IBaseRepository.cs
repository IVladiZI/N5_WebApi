using N5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(long Id);
        Task Insert(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
