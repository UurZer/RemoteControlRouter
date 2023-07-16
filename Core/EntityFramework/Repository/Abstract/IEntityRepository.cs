using System.Linq.Expressions;
using Rcr.Core.Entity;

namespace Rcr.Core.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> include = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
