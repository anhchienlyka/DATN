using DATN.DataAccessLayer.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);


        public async Task AddAsync(IEnumerable<T> entity) => await _dbSet.AddRangeAsync(entity);


        public void Delete(T entity) => _dbSet.Remove(entity);


        public void Delete(IEnumerable<T> entity) => _dbSet.RemoveRange(entity);


        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public Task<IEnumerable<T>> GetAllWithPaging(string fieldOrderBy, bool ascending, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(object id) => await _dbSet.FindAsync(id);


        public void Update(T entity) => _dbSet.Update(entity);


        public void Update(IEnumerable<T> entity) => _dbSet.UpdateRange(entity);

    }
}
