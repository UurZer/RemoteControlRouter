using Rcr.Data.Entity;
using IResult = Rcr.Utilities.Results.IResult;

namespace Rcr.Service.Abstract
{
    public interface IVehicleService
    {
        IResult SaveVehicle(Vehicle vehicle);
    }
}
