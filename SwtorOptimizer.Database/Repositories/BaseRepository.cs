using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Database.Database;
using System.Linq;
using System.Threading.Tasks;

namespace SwtorOptimizer.Database.Repositories
{
    internal class BaseRespository<T> : IRepository<T> where T : class
    {
        private readonly SwtorOptimizerContext dbContext;

        internal BaseRespository(SwtorOptimizerContext dbContext) => this.dbContext = dbContext;

        public virtual T Add(T entity, bool saveChanges)
        {
            this.dbContext.Set<T>().Add(entity);
            if (saveChanges)
            {
                this.dbContext.SaveChanges();
            }

            return entity;
        }

        public async Task<T> AddAsync(T entity, bool saveChanges)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
            if (saveChanges)
            {
                await this.dbContext.SaveChangesAsync();
            }

            return entity;
        }

        public virtual IQueryable<T> All()
        {
            return this.dbContext.Set<T>();
        }

        public void Delete(object id)
        {
            var existing = this.dbContext.Set<T>().Find(id);
            this.dbContext.Set<T>().Remove(existing);
            this.dbContext.SaveChanges();
        }

        public virtual T Exists(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public virtual T Get(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public virtual T Reload(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            this.dbContext.Entry(entity).Reload();

            return entity;
        }

        public virtual void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public virtual T Update(object id, T entity, bool saveChanges)
        {
            if (entity == null)
            {
                return null;
            }

            var existing = this.Exists(id);

            if (existing == null)
            {
                return null;
            }

            this.dbContext.Entry(existing).CurrentValues.SetValues(entity);

            if (saveChanges)
            {
                this.dbContext.SaveChanges();
            }

            return existing;
        }

        public virtual T Update(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            this.dbContext.Entry(entity).CurrentValues.SetValues(entity);

            this.dbContext.SaveChanges();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(object id, T entity, bool saveChanges)
        {
            if (entity == null)
            {
                return null;
            }

            var existing = this.Exists(id);

            if (existing == null)
            {
                return null;
            }

            this.dbContext.Entry(existing).CurrentValues.SetValues(entity);

            if (saveChanges)
            {
                await this.dbContext.SaveChangesAsync();
            }

            return existing;
        }
    }
}