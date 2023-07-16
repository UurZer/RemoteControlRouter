using Rcr.Data.Entity;
using Rcr.Utilities.Results;

namespace Rcr.Service.Abstract
{
    public interface IRouteService
    {
        IDataResult<Coordinate> MoveVehicle(Guid vehicleId, string command);
    }
}
