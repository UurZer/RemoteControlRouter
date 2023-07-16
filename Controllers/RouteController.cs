using Microsoft.AspNetCore.Mvc;
using Rcr.Data.Entity;
using Rcr.Service.Abstract;
using Rcr.Service.Concrete;
using Rcr.Utilities.Results;

namespace Rcr.Controllers
{
    [ApiController]
    [Route("")]
    [Route("api")]
    public class RouteController : ControllerBase
    {
        
        private RouteService _RouteService = null;

        public RouteService RouteService
        {
            get
            {
                if(_RouteService is null)
                    _RouteService = new RouteService();
                return _RouteService;
            }
        }

        [HttpPost("Move/Vehicle/{vehicleId}")]
        public IDataResult<Coordinate> MoveVehicle(Guid vehicleId, string commands)
        {
            IDataResult<Coordinate> result = null;
            try
            {
                result = RouteService.MoveVehicle(vehicleId, commands);

                if(!result.Success)
                {
                    return new ErrorDataResult<Coordinate>(result.Message);
                }

                return new SuccessDataResult<Coordinate>(result.Data, "Ýþlem baþarýlý");
            }
            catch (Exception ex)
            {
                Exception innerException = ex;

                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                return new ErrorDataResult<Coordinate>(innerException.Message);
            }
        }
    }
}