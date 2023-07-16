using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rcr.Data.Entity;

namespace Rcr.Data.DbModelConfiguration
{
    internal class VehicleDbMapper : DbEntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(255).IsRequired();

            entity.HasOne(x => x.Route);

            entity.ToTable("VEHICLE", "Rcr");
        }
    }
}
