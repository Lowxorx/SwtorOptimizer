using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Database.Database;
using System.Linq;
using System.Threading.Tasks;

namespace SwtorOptimizer.Database.Repositories
{
    internal class BaseRespository<T> : IRepository<T> where T : class
    {
        protected readonly SwtorOptimizerContext DbContext;

        internal BaseRespository(SwtorOptimizerContext dbContext) => this.DbContext = dbContext;

        public virtual T Add(T entity, bool saveChanges)
        {
            this.DbContext.Set<T>().Add(entity);
            if (saveChanges) this.DbContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity, bool saveChanges)
        {
            await this.DbContext.Set<T>().AddAsync(entity);
            if (saveChanges) await this.DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<T> All()
        {
            return this.DbContext.Set<T>();
        }

        public void Delete(object id)
        {
            var existing = this.DbContext.Set<T>().Find(id);
            this.DbContext.Set<T>().Remove(existing);
            this.DbContext.SaveChanges();
        }

        public virtual T Exists(object id)
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public virtual T Get(object id)
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public virtual void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }

        public virtual T Update(object id, T entity, bool saveChanges)
        {
            if (entity == null)
            {
                return null;
            }

            var existing = this.Exists(id);

            if (existing == null) return null;

            this.DbContext.Entry(existing).CurrentValues.SetValues(entity);

            if (saveChanges) this.DbContext.SaveChanges();

            return existing;
        }

        public virtual T Update(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            this.DbContext.Entry(entity).CurrentValues.SetValues(entity);

            this.DbContext.SaveChanges();

            return entity;
        }
    }
}