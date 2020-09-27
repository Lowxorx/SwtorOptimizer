using System.Linq;
using System.Threading.Tasks;

namespace SwtorOptimizer.Business.Database
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity, bool saveChanges);

        Task<T> AddAsync(T entity, bool saveChanges);

        IQueryable<T> All();

        void Delete(object id);

        T Exists(object id);

        T Get(object id);

        void SaveChanges();

        Task SaveChangesAsync();

        T Update(object id, T entity, bool saveChanges);

        T Update(T entity);

        Task<T> UpdateAsync(object id, T entity, bool saveChanges);
    }
}