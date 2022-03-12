using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DataAccessLayer.EF.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entity);
        void Update(T entity);
        void Update(IEnumerable<T> entity);
        Task<IEnumerable<T>> GetAllWithPaging(string fieldOrderBy, bool @ascending, int skip, int take);

    }
}
