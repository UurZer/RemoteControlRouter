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
    public class VehicleController : ControllerBase
    {
        
        private VehicleService _VehicleService = null;

        public VehicleService VehicleService
        {
            get
            {
                if(_VehicleService is null)
                    _VehicleService = new VehicleService();
                return _VehicleService;
            }
        }

        [HttpPost("Create/Vehicle")]
        public IDataResult<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            try   
            {
                VehicleService.SaveVehicle(vehicle);

                return new SuccessDataResult<Vehicle>(vehicle,"Vehicle Created");
            }
            catch (Exception ex )
            {
                Exception innerException = ex;

                while(innerException.InnerException != null )
                {
                    innerException = innerException.InnerException;
                }

                return new ErrorDataResult<Vehicle>(vehicle, innerException.Message);
            }
        }

        [HttpGet("Surface/Vehicles")]
        public IDataResult<List<Vehicle>> GetSurface()
        {
            IDataResult<List<Vehicle>> result = null;
            try
            {
                result = VehicleService.GetSurface();

                return result;
            }
            catch (Exception ex)
            {
                Exception innerException = ex;

                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                return new ErrorDataResult<List<Vehicle>>(innerException.Message);
            }
        }
    }
}