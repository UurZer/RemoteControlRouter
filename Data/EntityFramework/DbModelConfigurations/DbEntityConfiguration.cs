using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rcr.Data.DbModelConfiguration
{
    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
