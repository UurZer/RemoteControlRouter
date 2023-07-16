using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rcr.Data.Entity;

namespace Rcr.Data.DbModelConfiguration
{
    internal class RouteDbMapper : DbEntityConfiguration<VehicleRoute>
    {
        public override void Configure(EntityTypeBuilder<VehicleRoute> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Direction).HasMaxLength(10).IsRequired();

            entity.ToTable("ROUTE", "Rcr");
        }
    }
}
