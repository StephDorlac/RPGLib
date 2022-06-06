using RPGLibBusinessCore.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Context
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<CommonResult> AddAsync(T entity);
        Task<CommonResult> UpdateAsync(T entity);
        Task<CommonResult> DeleteAsync(T entity);
    }
}
