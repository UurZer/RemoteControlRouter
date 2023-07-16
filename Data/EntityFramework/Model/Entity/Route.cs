using Rcr.Core.Entity;

namespace Rcr.Data.Entity
{
    public class VehicleRoute : EntityBase
    {
        public Guid VehicleId { get; set; }
        
        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }
    }
}
