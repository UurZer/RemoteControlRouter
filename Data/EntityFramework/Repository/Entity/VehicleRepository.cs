using Rcr.Core.Repository;
using Rcr.Data.Entity;
using Rcr.DataAccess.Context;
using System.Linq;

namespace Rcr.Data.Repository
{
    public class VehicleRepository : EntityRepository<Vehicle, RcrDbContext>
    {
        public Vehicle GetVehicleById(Guid vehicleId)
        {
            return Get(x => x.Id == vehicleId && x.Status == true, y => y.Route);
        }
        public List<Vehicle> GetActiveVehicles()
        {
            return GetAll(x => x.Status == true, y=> y.Route);
        }
    }
}