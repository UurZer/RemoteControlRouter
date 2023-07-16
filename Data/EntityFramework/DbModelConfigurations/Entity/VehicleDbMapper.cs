using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rcr.Data.Entity;

namespace Rcr.Data.DbModelConfiguration
{
    public class VehicleDbMapper : EntityTypeConfiguration<Vehicle>
    {
        public VehicleDbMapper()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.ToTable("Vehicle", "Rcr");
        }
    }
}
