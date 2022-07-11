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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly N5_DBContext _n5_DBContext;
        protected DbSet<T> _entities;
        public BaseRepository(N5_DBContext n5_DBContext)
        {
            _n5_DBContext = n5_DBContext;
            _entities = n5_DBContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public async Task<T> GetById(long Id)
        {
            return await _entities.FindAsync(Id);
        }
        public async Task Insert(T Entity)
        {
           await _entities.AddAsync(Entity);
        }
        public void Update(T Entity)
        {
            _entities.Update(Entity);
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

    }
}
