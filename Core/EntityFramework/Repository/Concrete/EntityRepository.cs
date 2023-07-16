using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rcr.Core.Entity;

namespace Rcr.Core.Repository
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable Pattern Implementation Of C#
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> include = null)
        {
            using (var context = new TContext())
            {
                if (include is null)
                return context.Set<TEntity>().SingleOrDefault(filter);

                return filter == null
                    ? context.Set<TEntity>().Include(include).SingleOrDefault()
                    : context.Set<TEntity>().Include(include).Where(filter).SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> include = null)
        {
            using (var context = new TContext())
            {
                if (include is null)
                    return filter == null
                      ? context.Set<TEntity>().ToList()
                      : context.Set<TEntity>().Where(filter).ToList();

                return filter == null
                    ? context.Set<TEntity>().Include(include).ToList()
                    : context.Set<TEntity>().Include(include).Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
