using System.Collections.Generic;
using System.Threading.Tasks;

namespace dal.apifinport.Interfaces
{
    public interface IBaseService<E, T> where T : class
    {
        Task<E> ReadOneAsync(int Id, string Name);
        Task<E> ReadAllAsync();
        Task<E> CreateAsync(T Entity);
        Task<E> CreateMultipleAsync(List<T> Data);
        Task<E> UpdateAsync(T Entity);
        Task<E> DeleteAsync(int Id);
        Task<E> ReadMultipleByIdAsync(int Id);
    }
}