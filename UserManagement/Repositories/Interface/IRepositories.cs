using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Bases;

namespace UserManagement.Repositories.Interface
{
    public interface IRepositories<T> where T : class, IEntity
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Delete(int id);
    }
}
