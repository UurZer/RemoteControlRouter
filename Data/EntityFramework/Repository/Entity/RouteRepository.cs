using Rcr.Core.Repository;
using Rcr.Data.Entity;
using Rcr.DataAccess.Context;

namespace Rcr.Data.Repository
{
    public class RouteRepository : EntityRepository<VehicleRoute, RcrDbContext>
    {
        public VehicleRoute IsLocationSafe(int kx, int ky, Guid vehicleId)
        {
            return Get(e => e.X == kx && e.Y == ky && e.VehicleId != vehicleId);
        }

        public VehicleRoute GetVehicleRouteByVehicleId(Guid vehicleId)
        {
            return Get(e => e.VehicleId == vehicleId,null);
        }
    }
}
